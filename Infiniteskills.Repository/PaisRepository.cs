using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Repository;
using Infiniteskills.Infra.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace Infiniteskills.Repository
{
    public interface IPaisRepository : IRepositoryBase<Pais>
    {

    }
    public class PaisRepository : RepositoryBase<Pais>, IPaisRepository
    {
        public PaisRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }
        public override string[] IncludeEntity()
        {
            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }
      
        public override List<Pais> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(),BuildWhere(parameterList), orderBy);
        }

        public override Expression<Func<Pais, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Pais>();
            return predicate;
        }
    }
}
