using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Repository;
using Infiniteskills.Infra.Data;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;

namespace Infiniteskills.Repository
{
    public interface ITipoProveedorRepository : IRepositoryBase<TipoProveedor>
    {

    }

public class TipoProveedorRepository : RepositoryBase<TipoProveedor>, ITipoProveedorRepository
    {
        public TipoProveedorRepository(ApplicationDbContext ApplicationDbContext)
            : base(ApplicationDbContext)
        {
        }
        public override string[] IncludeEntity()
        {
            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }
        public override List<TipoProveedor> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
          
            return ExecuteSearch(IncludeEntity(),BuildWhere(parameterList), orderBy);
        }
        public override Expression<Func<TipoProveedor, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<TipoProveedor>();
            if (parameterList.ContainsKey("codigo"))
            {
                string value = Convert.ToString(parameterList["codigo"]);
                predicate = predicate.And(x => x.Codigo.Contains(value));
            }
            if (parameterList.ContainsKey("nombre"))
            {
                string value = Convert.ToString(parameterList["nombre"]);
                predicate = predicate.And(x => x.Nombre.Contains(value));
            }
            return predicate;
        }

    }
}
