using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using Infiniteskills.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public interface ITablaRepository : IRepositoryBase<Tabla>
    {

    }
    public class TablaRepository : RepositoryBase<Tabla>, ITablaRepository
    {
        public TablaRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }

        public override Expression<Func<Tabla, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Tabla>();
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

        public override List<Tabla> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
