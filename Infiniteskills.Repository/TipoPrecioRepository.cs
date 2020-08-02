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
    public interface ITipoPrecioRepository: IRepositoryBase<TipoPrecio>
    {

    }
    public class TipoPrecioRepository : RepositoryBase<TipoPrecio>, ITipoPrecioRepository
    {
        public TipoPrecioRepository(ApplicationDbContext applicationContext)
            : base(applicationContext)
        {
        }

        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }
        public override Expression<Func<TipoPrecio, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<TipoPrecio>();
            if (parameterList.ContainsKey("nombre"))
            {
                string value = Convert.ToString(parameterList["nombre"]);
                predicate = predicate.And(x => x.Nombre.Contains(value));
            }
            return predicate;
        }

        public override List<TipoPrecio> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
