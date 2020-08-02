using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using Infiniteskills.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public interface IPeriodoRepository : IRepositoryBase<Periodo>
    {

    }
    public class PeriodoRepository : RepositoryBase<Periodo>, IPeriodoRepository
    {
        public PeriodoRepository(ApplicationDbContext ApplicationDbContext) 
            : base(ApplicationDbContext)
        {
        }

        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }
        public override Expression<Func<Periodo, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Periodo>();
          
            return predicate;
        }

        public override List<Periodo> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
