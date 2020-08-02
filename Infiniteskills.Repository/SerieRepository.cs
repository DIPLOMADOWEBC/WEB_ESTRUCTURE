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
    public interface ISerieRepository:IRepositoryBase<Serie>
    {

    }
    public class SerieRepository : RepositoryBase<Serie>, ISerieRepository
    {
        public SerieRepository(ApplicationDbContext applicationContext) 
            : base(applicationContext)
        {
        }

        public override string[] IncludeEntity()
        {
            string[] relatedEnties = new string[] {
            };
            return relatedEnties;
        }
        public override Expression<Func<Serie, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Serie>();
            if (parameterList.ContainsKey("almacenId"))
            {
                int value = Convert.ToInt32(parameterList["almacenId"]);
                predicate = predicate.And(x => x.AlmacenId == value);
            }
            return predicate;
        }

        public override List<Serie> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
