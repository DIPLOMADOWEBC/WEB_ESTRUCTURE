using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using Infiniteskills.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public interface IDepartamentoRepository : IRepositoryBase<Departamento>
    {
    }
    public class DepartamentoRepository : RepositoryBase<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }
        public override string[] IncludeEntity()
        {
            string[] relatedEnties = new string[] {

            };
            return relatedEnties;
        }
      
        public override List<Departamento> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(),BuildWhere(parameterList), orderBy);
        }
        public override Expression<Func<Departamento, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Departamento>();
            if (parameterList.ContainsKey("paisId"))
            {
                int value =Convert.ToInt32(parameterList["paisId"]);
                predicate = predicate.And(x => x.PaisId == value);
            }
            return predicate;
        }
    }
}
