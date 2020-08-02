using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public interface ILineaRepository : IRepositoryBase<Linea>
    {
    }
    public class LineaRepository: RepositoryBase<Linea>, ILineaRepository
    {
        public LineaRepository(ApplicationDbContext applicationDbContext)
          : base(applicationDbContext)
        {
        }

        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] {
            };
            return relatedEnties;
        }
        public override Expression<Func<Linea, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Linea>();

            return predicate;
        }

        public override List<Linea> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
