using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using Infiniteskills.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
  
    public class UnidadMedidaRepository : RepositoryBase<UnidadMedida>, IUnidadMedidaRepository
    {
        public UnidadMedidaRepository(ApplicationDbContext ApplicationDbContext) 
            : base(ApplicationDbContext)
        {
        }
        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }
        public override Expression<Func<UnidadMedida, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<UnidadMedida>();
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

        public override List<UnidadMedida> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
