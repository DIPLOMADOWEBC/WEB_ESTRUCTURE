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
    public interface IProveedorContactoRepository: IRepositoryBase<ProveedorContacto>
    {

    }
    public class ProveedorContactoRepository : RepositoryBase<ProveedorContacto>, IProveedorContactoRepository
    {
        public ProveedorContactoRepository(ApplicationDbContext applicationContext) 
            : base(applicationContext)
        {
        }

        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] {
            "Contacto.Area"
            };
            return relatedEnties;
        }
        public override Expression<Func<ProveedorContacto, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<ProveedorContacto>();
            if (parameterList.ContainsKey("proveedorId"))
            {
                int value = Convert.ToInt32(parameterList["proveedorId"]);
                predicate = predicate.And(x => x.ProveedorId == value);
            }
           
            return predicate;
        }

        public override List<ProveedorContacto> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
