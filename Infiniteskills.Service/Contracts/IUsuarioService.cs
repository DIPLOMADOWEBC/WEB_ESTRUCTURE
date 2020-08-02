using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface IUsuarioService : IEntityServiceBase<UsuarioDTO>
    {
        UsuarioDTO FindByUser(string userName);
        UsuarioDTO FindByUserAlmacen(string userName);
        UsuarioDTO UsuarioAlmacen(int usuarioId);
        bool ValidateUser(int usuarioId, string password);
        UsuarioSucursalDTO GetUsuarioSucursal(int usuarioId);
        UsuarioSucursalDTO GetUsuarioPeriodoEmpresa(Dictionary<string, object> parameters);
        List<UsuarioDTO> ListarUsuario(Dictionary<string, object> parameters);
        void CreateUser(UsuarioDTO usuarioDTO);
    }
}
