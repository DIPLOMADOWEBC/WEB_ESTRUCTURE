
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
    public interface IParametroSistemaRepository : IRepositoryBase<ParametroSistema>
    {

    }
    public class ParametroSistemaRepository : RepositoryBase<ParametroSistema>, IParametroSistemaRepository
    {
        public ParametroSistemaRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public override Expression<Func<ParametroSistema, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<ParametroSistema>();

            if (parameterList.ContainsKey("codigo"))
            {
                string value = Convert.ToString(parameterList["codigo"]);
                predicate = predicate.And(x => x.Codigo.Contains(value));
            }

            if (parameterList.ContainsKey("nombre"))
            {
                string value = Convert.ToString(parameterList["nombre"]);
                predicate = predicate.And(x => x.Nombre.Contains(value));
            }
            return predicate;
        }

        public override List<ParametroSistema> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
