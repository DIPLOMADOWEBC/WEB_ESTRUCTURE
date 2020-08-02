using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using System.Collections.Generic;
namespace Infiniteskills.Repository
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario FindByUser(string userName);
        Usuario FindByUserAlmacen(string userName);
        bool ValidateUser(int usuarioId, string password);
        Usuario UsuarioAlmacen(int usuarioId);
        IEnumerable<UsuarioSucursal> GetUsuarioSucursal(int usuarioId);
        IEnumerable<UsuarioSucursal> GetUsuarioPeriodoEmpresa(Dictionary<string, object> parameters);
        List<Usuario> ListarUsuario(Dictionary<string, object> parameters);
        void CreateUser(Usuario usuario);
    }
}
