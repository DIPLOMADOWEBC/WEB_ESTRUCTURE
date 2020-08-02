
using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using Infiniteskills.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public interface IFormaPagoRepository : IRepositoryBase<FormaPago>
    {

    }
    public class FormaPagoRepository : RepositoryBase<FormaPago>, IFormaPagoRepository
    {
        public FormaPagoRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }
        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }
        public override Expression<Func<FormaPago, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<FormaPago>();
            return predicate;
        }

        public override List<FormaPago> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
