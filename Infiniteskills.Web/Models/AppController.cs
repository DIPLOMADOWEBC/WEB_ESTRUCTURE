using Infiniteskills.Common;
using Infiniteskills.Transport;
using Infiniteskills.Service;
using System.Collections.Generic;
using System.Web.Mvc;
using System;

namespace Infiniteskills.Web
{
    public class AppController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public AppController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public string UserNameLogin()
        {
            return User.Identity.Name;
        }

        public string NombreUsuario(string nombreUsuario)
        {
            if (Session[VariableSesionConstante.USUARIO_ID] == null)
            {
                UsuarioDTO usuarioDTO = new UsuarioDTO();
                usuarioDTO = _usuarioService.FindByUser(nombreUsuario);

                Session[VariableSesionConstante.USUARIO_NOMBRE] = usuarioDTO.Nombre;
                ObtenerUsuarioId(usuarioDTO.Nombre);
                return usuarioDTO.Nombre;
            }
            else
                return (string)Session[VariableSesionConstante.USUARIO_NOMBRE];
        }
        public int ObtenerUsuarioId()
        {
            string usuarioLogon = (string)Session[VariableSesionConstante.USUARIO_LOGON];
            return ObtenerUsuarioId(usuarioLogon);
        }
        public int GetPeriodoEmpresaId()
        {
            return Convert.ToInt32(Session[VariableSesionConstante.PERIODO_EMPRESA]);
        }

        public int GetPeriodoId()
        {
            return Convert.ToInt32(Session[VariableSesionConstante.PERIODO_EMPRESA]);
        }

        public int UsuarioAlmacenId()
        {
            return Convert.ToInt32(Session[VariableSesionConstante.USUARIO_ALMACEN_ID]);
        }

        public int GetUsuarioId()
        {
            return Convert.ToInt32(Session[VariableSesionConstante.USUARIO_ID]);
        }

        public int GetPersonalUsuarioId()
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO();

            usuarioDTO = _usuarioService.FindByUser(this.UserNameLogin());
            return usuarioDTO.PersonalId;
        }

        public int ObtenerUsuarioId(string usuarioLogon)
        {

            if (Session[VariableSesionConstante.USUARIO_ID] == null)
            {

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                UsuarioDTO usuarioDTO = new UsuarioDTO();
                usuarioDTO = _usuarioService.FindByUser(this.UserNameLogin());

                Session[VariableSesionConstante.USUARIO_ID] = usuarioDTO.UsuarioId;
                return usuarioDTO.UsuarioId;
            }
            else
                return (int)Session[VariableSesionConstante.USUARIO_ID];
        }

        public bool EsAdministrador()
        {
            // List<string> rolList = this.ObtenerRoles();

            //if (rolList.Contains(RolSistemaConstante.SYSADMIN))
            //    return true;

            return true;
        }
    }
}