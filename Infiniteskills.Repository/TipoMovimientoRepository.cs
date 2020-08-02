using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Repository
{
    public interface ITipoMovimientoRepository : IRepositoryBase<TipoMovimiento>
    {

    }
    public class TipoMovimientoRepository:RepositoryBase<TipoMovimiento>, ITipoMovimientoRepository
    {
        public TipoMovimientoRepository(ApplicationDbContext applicationDbContext)
          : base(applicationDbContext)
        {
        }

        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] {
            };
            return relatedEnties;
        }
        public override Expression<Func<TipoMovimiento, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<TipoMovimiento>();
            if (parameterList.ContainsKey("nombre"))
            {
                string value = Convert.ToString(parameterList["nombre"]);
                predicate = predicate.And(x => x.Nombre.Contains(value));
            }
            return predicate;
        }

        public override List<TipoMovimiento> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
