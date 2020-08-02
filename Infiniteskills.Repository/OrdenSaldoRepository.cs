using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infiniteskills.Repository
{
    public interface IOrdenSaldoRepository : IRepositoryBase<OrdenSaldo>
    {
        List<OrdenSaldo> ListarKardexProducto();
    }
    public class OrdenSaldoRepository : RepositoryBase<OrdenSaldo>, IOrdenSaldoRepository
    {
        public OrdenSaldoRepository(ApplicationDbContext applicationContext) 
            : base(applicationContext)
        {
        }

        public List<OrdenSaldo> ListarKardexProducto()
        {
            var query = _applicationDbContext.OrdenSaldo.ToList();
            return query;
        }
    }
}
