using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infiniteskills.Infra.Data;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Infiniteskills.Repository
{
    public interface IAlmacenRepository:IRepositoryBase<Almacen>
    {
        IEnumerable<Almacen> ListarAlmacen(int sucursalId);
    }
    public class AlmacenRepository : RepositoryBase<Almacen>, IAlmacenRepository
    {
        protected DbSet<Almacen> _DbSetAlmacen;
        public AlmacenRepository(ApplicationDbContext applicationContext) 
            : base(applicationContext)
        {
            _DbSetAlmacen = _applicationDbContext.Set<Almacen>();
        }

        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] {
             "Sucursal.Empresa"
            };
            return relatedEnties;
        }
        public override Expression<Func<Almacen, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Almacen>();
            if (parameterList.ContainsKey("nombre"))
            {
                string value = Convert.ToString(parameterList["nombre"]);
                predicate = predicate.And(x => x.Nombre.Contains(value));
            }

            if (parameterList.ContainsKey("sucursalId"))
            {
                int value = Convert.ToInt32(parameterList["sucursalId"]);
                predicate = predicate.And(x => x.SucursalId == value);
            }

            if (parameterList.ContainsKey("sucursal"))
            {
                string value = Convert.ToString(parameterList["sucursal"]);
                predicate = predicate.And(x => x.Sucursal.Nombre.Contains(value));
            }
            return predicate;
        }

        public override List<Almacen> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }

        public IEnumerable<Almacen> ListarAlmacen(int sucursalId)
        {
            var query = _DbSetAlmacen.Include(x => x.Sucursal).ToList();
            return query;
        }
    }
}
