using Infiniteskills.Infra.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
namespace Infiniteskills.Infra.Core
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ApplicationDbContext _applicationDbContext;

        protected DbSet<TEntity> _DbSet;

        private bool disposed = false;

        public RepositoryBase(ApplicationDbContext applicationContext)
        {
            _applicationDbContext = applicationContext;
            _DbSet = _applicationDbContext.Set<TEntity>();
        }
        public void Insert(TEntity entity)
        {
            try
            {
                _applicationDbContext.Set<TEntity>().Add(entity);
                _applicationDbContext.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                string entityValidationError = GetEntityValidationErrorMessage(ex);
                throw new Exception(entityValidationError);
            }
        }
        public void Update(TEntity entity)
        {
            try
            {
                _DbSet.Attach(entity);
                _applicationDbContext.Entry(entity).State = EntityState.Modified;
                _applicationDbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string entityValidationError = GetEntityValidationErrorMessage(ex);
                throw new Exception(entityValidationError);
            }

        }
        public string GetEntityValidationErrorMessage(DbEntityValidationException e)
        {

            string entityValidationError = string.Empty;
            foreach (var eve in e.EntityValidationErrors)
            {
                entityValidationError = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                foreach (var ve in eve.ValidationErrors)
                {
                    entityValidationError = string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                }
            }

            return entityValidationError;
        }
        public void Delete(TEntity entity)
        {
            try
            {
                _applicationDbContext.Set<TEntity>().Remove(entity);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _applicationDbContext.Set<TEntity>().ToList();
        }
        public virtual string[] IncludeEntity()
        {
            return null;
        }
        public TEntity GetById(int id)
        {
            try
            {
                ObjectContext objectContext = ((IObjectContextAdapter)_applicationDbContext).ObjectContext;
                ObjectSet<TEntity> set = objectContext.CreateObjectSet<TEntity>();
                List<string> keyNames = set.EntitySet.ElementType
                                                            .KeyMembers
                                                            .Select(k => k.Name).ToList();

                DbQuery<TEntity> query = _DbSet;

                string[] entityList = this.IncludeEntity();
                if (entityList != null)
                    foreach (string str in entityList)
                        query = query.Include(str);

                ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "x");
                MemberExpression property = Expression.Property(parameter, keyNames[0]);
                var equalsTo = Expression.Constant(id);
                var equality = Expression.Equal(property, equalsTo);
                Expression<Func<TEntity, bool>> expression =
                    Expression.Lambda<Func<TEntity, bool>>(equality, new[] { parameter });

                return query.Where(expression).FirstOrDefault<TEntity>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public TEntity SearchFor(Dictionary<string, object> parametersList)
        {
            throw new NotImplementedException();
        }
        public virtual List<TEntity> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            return null;
        }
        public virtual Expression<Func<TEntity, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            return null;
        }
        public List<TEntity> ExecuteSearch(string[] entityList, Expression<Func<TEntity, bool>> predicate, string orderBy)
        {
            return ExecuteSearch(entityList, predicate, 0, orderBy);
        }
        public List<TEntity> ExecuteSearch(Expression<Func<TEntity, bool>> predicate, string orderBy)
        {
            return ExecuteSearch(null, predicate, orderBy);
        }
        public List<TEntity> ExecuteSearch(Expression<Func<TEntity, bool>> predicate, string orderBy, int pageSize)
        {
            return ExecuteSearch(null, predicate, orderBy);
        }
        public List<TEntity> ExecuteSearch(string[] entityList, Expression<Func<TEntity, bool>> predicate, int pageSize, string orderBy)
        {
            IQueryable<TEntity> query = _DbSet;

            if (entityList != null)
                foreach (string str in entityList)
                    query = query.Include(str);

            return buildAndApplyOrderBy(query.Where(predicate), pageSize, orderBy).ToList<TEntity>();
        }
        private IQueryable<TEntity> buildAndApplyOrderBy(IQueryable<TEntity> query, int pageSize, string orderBy)
        {

            if (String.IsNullOrEmpty(orderBy))
                return applyMaxReturnItems(query, pageSize);

            string[] orderedItemsList = orderBy.Split(',');
            if (orderedItemsList.Length == 0)
                return applyMaxReturnItems(query, pageSize);

            MethodCallExpression mce = null;
            for (int index = 0; index < orderedItemsList.Length; index++)
            {
                bool orderByDesc = false;
                string[] fieldAndOrder = orderedItemsList[index].Split(' ');
                if (fieldAndOrder.Length == 2)
                    orderByDesc = fieldAndOrder[1].ToLower().Contains("desc") ? true : false;

                var param = Expression.Parameter(typeof(TEntity), "p");
                var prop = Expression.Property(param, fieldAndOrder[0]);
                var exp = Expression.Lambda(prop, param);
                string method = "";
                if (index == 0)
                    method = orderByDesc ? "OrderByDescending" : "OrderBy";
                else
                    method = orderByDesc ? "ThenByDescending" : "ThenBy";
                Type[] types = new Type[] { query.ElementType, exp.Body.Type };

                if (index == 0)
                    mce = Expression.Call(typeof(Queryable), method, types, query.Expression, exp);
                else
                    mce = Expression.Call(typeof(Queryable), method, types, mce, exp);
            }

            if (mce != null)
                return applyMaxReturnItems((query.Provider.CreateQuery(mce) as IQueryable<TEntity>), pageSize);

            return applyMaxReturnItems(query, pageSize);
        }
        private IQueryable<TEntity> applyMaxReturnItems(IQueryable<TEntity> query, int pageSize)
        {
            if (pageSize <= 0)
                return query.AsNoTracking();

            return query.Take(pageSize).AsNoTracking();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _applicationDbContext.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       
    }
}
