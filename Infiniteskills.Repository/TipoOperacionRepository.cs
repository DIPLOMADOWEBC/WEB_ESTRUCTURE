using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public interface ITipoOperacionRepository : IRepositoryBase<TipoOperacion>
    {
        TipoOperacion GetTipoOperacion(string codigo);
    }
    public class TipoOperacionRepository : RepositoryBase<TipoOperacion>, ITipoOperacionRepository
    {
        public TipoOperacionRepository(ApplicationDbContext applicationContext) 
            : base(applicationContext)
        {
        }
        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }
        public override Expression<Func<TipoOperacion, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<TipoOperacion>();
            //if (parameterList.ContainsKey("tipoMovimientoId"))
            //{
            //    int value = Convert.ToInt32(parameterList["tipoMovimientoId"]);
            //    predicate = predicate.And(x => x.TipoMovimientoId == value);
            //}
            if (parameterList.ContainsKey("codigo"))
            {
                string value = Convert.ToString(parameterList["codigo"]);
                predicate = predicate.And(x => x.Codigo == value);
            }
            return predicate;
        }

        public override List<TipoOperacion> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }

        public TipoOperacion GetTipoOperacion(string codigo)
        {
            var query = _applicationDbContext.TipoOperacion.Where(x=>x.Codigo==codigo).First();
            return query;
        }
    }
}
