using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Repository
{
    public interface IProveedorRepository : IRepositoryBase<Proveedor>
    {
        Task<IEnumerable<Proveedor>> ListarProveedor(string query);
        Task<IEnumerable<Proveedor>> ListarProveedor(int id);
        IEnumerable<Proveedor> BuscarPorCodigo(int id);
        Task<IEnumerable<Proveedor>> BuscarPorRuc(string ruc);
        Task<Proveedor> BuscarProveedor(int id);
        void InsertarCliente(Proveedor proveedor, IEnumerable<Contacto> contacto);
        void ActualizarCliente(Proveedor proveedor);
    }
}
