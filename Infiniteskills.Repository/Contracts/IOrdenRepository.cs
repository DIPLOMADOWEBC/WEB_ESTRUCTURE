using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infiniteskills.Repository
{
    public interface IOrdenRepository : IRepositoryBase<Orden>
    {
        void InsertPedidoItem(Orden orden);
        Task UpdatePedidoItem(Orden orden);
        Task InsertIventarioItem(Orden orden);
        Task UpdateInventarioItem(Orden orden);
        Task InsertarCompra(Orden orden);
        Task InsertarMovimiento(Orden orden);
        Task InsertarTransferencia(Orden orden);
        IEnumerable<Orden> BuscarOrdenCompra(string codigo);
        Task<Orden> BuscarPedidos(int id);
        Task<Orden> BuscarInventarioInicial(int id);
        Task<Orden> BuscarMovimiento(int id);
        decimal VerificarSaldo(OrdenSaldo saldo);
        List<Orden> ListarInventario(Dictionary<string, object> parameters);
        List<Orden> ListarPedidos(Dictionary<string, object> parameters);
        List<Orden> ListarCompra(Dictionary<string, object> parameters);
        IEnumerable<Orden> ListarMovimiento(Dictionary<string, object> parameters);
        IEnumerable<Orden> ListarCotizacion(Dictionary<string, object> parameters);
        IEnumerable<Orden> ListarGuiaRemision(Dictionary<string, object> parameters);
    }
}
