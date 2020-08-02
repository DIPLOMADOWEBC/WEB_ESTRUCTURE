
using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using Infiniteskills.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public interface IProvinciaRepository : IRepositoryBase<Provincia>
    {
    }
    public class ProvinciaRepository : RepositoryBase<Provincia>, IProvinciaRepository
    {
        public ProvinciaRepository(ApplicationDbContext ApplicationDbContext) 
            : base(ApplicationDbContext)
        {
        }
        public override string[] IncludeEntity()
        {
            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }
        public override Expression<Func<Provincia, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Provincia>();
            if (parameterList.ContainsKey("departamentoId"))
            {
                int value = Convert.ToInt32(parameterList["departamentoId"]);
                predicate = predicate.And(x => x.DepartamentoId == value);
            }
            return predicate;
        }
     
        public override List<Provincia> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(),BuildWhere(parameterList), orderBy);
        }
    }
}
