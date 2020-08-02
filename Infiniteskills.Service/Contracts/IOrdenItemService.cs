using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface IOrdenItemService : IEntityServiceBase<OrdenItemDTO>
    {
        IEnumerable<OrdenItemDTO> ListarFactura(int id);
        IEnumerable<OrdenItemDTO> ListarInventario(Dictionary<string, object> parameters);
        IEnumerable<KardexProductoDTO> ListarKardex(Dictionary<string, object> parameters);
        IEnumerable<OrdenItemDTO> ListarOrdenItem(Dictionary<string, object> parameters);
    }
}
