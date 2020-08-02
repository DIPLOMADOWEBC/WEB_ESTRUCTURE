using Infiniteskills.Common;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infiniteskills.Repository
{
   
    public class PersonalRepository : RepositoryBase<Personal>, IPersonalRepository
    {
        protected DbSet<Personal> _DbPersonal;
        public PersonalRepository(ApplicationDbContext ApplicationDbContext)
            : base(ApplicationDbContext)
        {
            _DbPersonal = _applicationDbContext.Set<Personal>();
        }
        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] {};
            return relatedEnties;
        }
        public override Expression<Func<Personal, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Personal>();
            if (parameterList.ContainsKey("documento"))
            {
                string value = Convert.ToString(parameterList["documento"]);
                predicate = predicate.And(x => x.NumeroDocumento.Contains(value));
            }
            if (parameterList.ContainsKey("nombre"))
            {
                string value = Convert.ToString(parameterList["nombre"]);
                predicate = predicate.And(x => x.Nombres.Contains(value));
            }
            return predicate;
        }

        public override List<Personal> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }

        public async Task<IEnumerable<Personal>> ListarPersonal(string nombre)
        {
            var query = _applicationDbContext
                .Personal.Where(x => x.Nombres.Contains(nombre))
                .Take(50).ToListAsync();
            return await query;
        }

        public void InsertarUsuario(Personal personal)
        {
            using (var transaction = _applicationDbContext.Database.BeginTransaction())
            {
                try
                {
                    Cryptor cryptor = new Cryptor();
                    Guid guid = Guid.NewGuid();
                    personal.Usuario.First().PasswordHash = guid.ToByteArray();
                    personal.Usuario.First().Password = cryptor.Encrypt(personal.Usuario.First().Password, personal.Usuario.First().PasswordHash);

                    // _applicationDbContext.Personal.Add(personal);

                    _applicationDbContext.Usuario.AddRange(personal.Usuario);
                    _applicationDbContext.SaveChanges();

                    transaction.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    transaction.Rollback();
                    string entityValidationError = GetEntityValidationErrorMessage(ex);
                    throw new Exception(entityValidationError);
                }

            }
        }

        public Personal GetPersonalId(int id)
        {

            Personal personal = _DbPersonal
               .Include(x => x.SucursalUsuario)
               .Where(x => x.PersonalId == id).FirstOrDefault();

            return personal;
        }

        public IEnumerable<Personal> ListarPersonal(int id)
        {
            var query = _applicationDbContext
                .Personal.Where(x => x.PersonalId == id).ToList();

            return query;
        }
    }
}
