using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface IOrdenService : IEntityServiceBase<OrdenDTO>
    {
        void InsertPedidoItem(OrdenDTO pedidoDTO);
        void UpdatePedidoItem(OrdenDTO pedidoDTO);
        Task InsertIventarioItem(OrdenDTO pedidoDTO);
        void UpdateInventarioItem(OrdenDTO pedidoDTO);
        Task InsertarMovimiento(OrdenDTO orden);
        Task InsertarCompra(OrdenDTO orden);
        Task InsertarTransferencia(OrdenDTO orden);
        List<OrdenDTO> ListarInventario(Dictionary<string, object> parameters);
        List<OrdenDTO> ListarCompra(Dictionary<string, object> parameters);
        List<OrdenDTO> ListarPedido(Dictionary<string, object> parameters);
        IEnumerable<OrdenDTO> ListarMovimiento(Dictionary<string, object> parameters);
        IEnumerable<OrdenDTO> ListarCotizacion(Dictionary<string, object> parameters);
        IEnumerable<OrdenDTO> ListarGuiaRemision(Dictionary<string, object> parameters);
        IEnumerable<OrdenDTO> BuscarOrdenCompra(string codigo);
        Task<OrdenDTO> BuscarPedidos(int id);
        Task<OrdenDTO> BuscarInventarioInicial(int id);
        Task<OrdenDTO> BuscarMovimientoAsync(int id);
    }
}
