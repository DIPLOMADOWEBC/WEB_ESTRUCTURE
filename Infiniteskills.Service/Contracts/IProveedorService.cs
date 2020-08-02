using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface IProveedorService : IEntityServiceBase<ProveedorDTO>
    {
        Task<IEnumerable<ProveedorDTO>> ListarProveedor(string query);
        Task<IEnumerable<ProveedorDTO>> ListarProveedor(int id);
        IEnumerable<ProveedorDTO> BuscarPorCodigo(int id);
        Task<IEnumerable<ProveedorDTO>> BuscarPorRuc(string ruc);
        Task<ProveedorDTO> BuscarProveedor(int id);
        void InsertarCliente(ProveedorDTO proveedor);
        void ActualizarCliente(ProveedorDTO proveedor);
    }
}
