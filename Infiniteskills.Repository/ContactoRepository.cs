using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using System;
using System.Collections.Generic;
using Infiniteskills.Infra.Data;
using System.Linq.Expressions;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Infiniteskills.Common;

namespace Infiniteskills.Repository
{
    public interface IContactoRepository : IRepositoryBase<Contacto>
    {
        void InsertarContacto(Contacto contacto);
        Task<IEnumerable<Contacto>> ListarContacto(string query);
        Task<IEnumerable<Contacto>> ListarContacto(int id);
    }
    public class ContactoRepository : RepositoryBase<Contacto>, IContactoRepository
    {
        public ContactoRepository(ApplicationDbContext applicationContext)
            : base(applicationContext)
        {
        }

        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }
        public override Expression<Func<Contacto, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Contacto>();

            if (parameterList.ContainsKey("nombre"))
            {
                string value = Convert.ToString(parameterList["nombre"]);
                predicate = predicate.And(x => x.NombreContacto.Contains(value));
            }
            if (parameterList.ContainsKey("numDocumento"))
            {
                string value = Convert.ToString(parameterList["numDocumento"]);
                predicate = predicate.And(x => x.NumeroDocumentoContacto.Contains(value));
            }
            return predicate;
        }

        public override List<Contacto> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }

        public void InsertarContacto(Contacto contacto)
        {
            using (var transaction = _applicationDbContext.Database.BeginTransaction())
            {
                try
                {
                    _applicationDbContext.Contacto.Add(contacto);
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

        public async Task<IEnumerable<Contacto>> ListarContacto(string query)
        {
            var sqlQuery = _applicationDbContext
                 .Contacto.Where(x => x.NombreContacto.Contains(query)
                 || x.NumeroDocumentoContacto.Contains(query))
                 .Take(50).ToListAsync();
            return await sqlQuery;
        }

        public async Task<IEnumerable<Contacto>> ListarContacto(int id)
        {
            var sqlQuery = _applicationDbContext
                  .Contacto.Where(x => x.ContactoId == id
                  && x.Estado == EstadoConstante.ACTIVO).ToListAsync();
            return await sqlQuery;
        }
    }
}
