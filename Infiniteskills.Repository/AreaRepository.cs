using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infiniteskills.Infra.Data;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public interface IAreaRepository: IRepositoryBase<Area>
    {

    }
    public class AreaRepository : RepositoryBase<Area>, IAreaRepository
    {
        public AreaRepository(ApplicationDbContext applicationContext) 
            : base(applicationContext)
        {
        }

        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] {
            };
            return relatedEnties;
        }
        public override Expression<Func<Area, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Area>();
            
            return predicate;
        }

        public override List<Area> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
