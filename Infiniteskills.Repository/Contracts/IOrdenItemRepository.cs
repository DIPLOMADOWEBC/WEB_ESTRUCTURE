using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Repository
{
    public interface IOrdenItemRepository : IRepositoryBase<OrdenItem>
    {
        IEnumerable<OrdenItem> ListarInventario(Dictionary<string, object> parameters);
        IEnumerable<KardexProducto> ListarKardex(Dictionary<string, object> parameters);
        IEnumerable<OrdenItem> ListarOrdenItem(Dictionary<string, object> parameters);
        IEnumerable<OrdenItem> ListarFactura(int id);
    }
}
