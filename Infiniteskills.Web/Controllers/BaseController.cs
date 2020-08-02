using Infiniteskills.Common;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Web.Controllers
{
    public class BaseController : Controller
    {
        public int GetPeriodoEmpresaId()
        {
            return Convert.ToInt32(Session[VariableSesionConstante.PERIODO_EMPRESA]);
        }

        public  int GetPeriodoId()
        {
            return Convert.ToInt32(Session[VariableSesionConstante.PERIODO_EMPRESA]);
        }

        public int GetUsuarioId()
        {
            return Convert.ToInt32(Session[VariableSesionConstante.USUARIO_ID]);
        }

        public int ObtenerUsuarioId(string usuarioLogon)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO();

            if (Session[VariableSesionConstante.USUARIO_ID] == null)
            {
               
                Session[VariableSesionConstante.USUARIO_ID] = 0;
                return usuarioDTO.UsuarioId;
            }
            else
                return (int)Session[VariableSesionConstante.USUARIO_ID];
        }
    }
}