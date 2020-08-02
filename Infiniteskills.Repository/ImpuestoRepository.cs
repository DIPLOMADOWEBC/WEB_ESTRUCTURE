using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public class ImpuestoRepository : RepositoryBase<Impuesto>, IImpuestoRepository
    {
        public ImpuestoRepository(ApplicationDbContext applicationContext)
            : base(applicationContext)
        {
        }

        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] {
            };
            return relatedEnties;
        }
        public override Expression<Func<Impuesto, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Impuesto>();
          
            return predicate;
        }

        public override List<Impuesto> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
