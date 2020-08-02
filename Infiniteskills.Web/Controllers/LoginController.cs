using Infiniteskills.Common;
using Infiniteskills.Helpers;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using Infiniteskills.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Web.Controllers
{
    public class LoginController : BaseController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IUsuarioService _usuarioService;
        private IAlmacenService _almacenService;
        private IEmpresaService empresaService;
        private ISucursalService sucursalService;
        private IPeriodoService periodoService;
        public UserManager UserManager { get; private set; }
        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        public LoginController(IUsuarioService usuarioService,
            ISucursalService sucursalService, IAlmacenService almacenService,
            IEmpresaService empresaService, IPeriodoService periodoService)
          : this(new UserManager(usuarioService))
        {
            _usuarioService = usuarioService;
            _almacenService = almacenService;
            this.empresaService = empresaService;
            this.sucursalService = sucursalService;
            this.periodoService = periodoService;
        }

        public LoginController(UserManager userManager)
        {
            this.UserManager = userManager;
        }


        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO
            {
                UserName = "admin",
                Password = "123456",
                Nombre = "ADMIN  PAUCAR CARDENAS",
                PersonalId = 1
            };
            // _usuarioService.CreateUser(usuarioDTO);

            return View(new LoginViewModel());
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            logger.Info("LoginValidate :: Start Execution");
            logger.Info("LoginValidate :: Parameters : [returnUrl=" + returnUrl + "]");

            try
            {
                if (!ModelState.IsValid)
                {
                    var user = await UserManager.FindAsync(model.UserName, model.Password);
                    if (user != null)
                    {
                        await SignInAsync(user, model.RememberMe);
                        Session[VariableSesionConstante.USUARIO_NOMBRE] = "ADMIN";
                        Session[VariableSesionConstante.USUARIO_LOGON] = "admin";
                        Session[VariableSesionConstante.PERIODO] = "1";
                        Session[VariableSesionConstante.PERIODO_EMPRESA] = "2020";
                        Session[VariableSesionConstante.PERIODO_NOMBRE] ="2020";
                        Session[VariableSesionConstante.USUARIO_EMPRESA] = "EMPRESA";
                        Session[VariableSesionConstante.USUARIO_SUCURSAL] = "SUCURSAL";
                        Session[VariableSesionConstante.USUARIO_ALMACEN_ID] = 1;
                        Session[VariableSesionConstante.USUARIO_ALMACEN] = "ALMACEN";

                        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                        return RedirectToAction("Index", "Home");

                        //return View("Create", modelview);
                    }
                    else
                    {

                        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                        return RedirectToAction("Index", "Login");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
            return View(model);
        }

      

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {


                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult ListarSucursal(string empresaId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                parameters.Add("empresaId",empresaId);
                List<SucursalDTO> sucursalDTOList = sucursalService.SearchFor(parameters, string.Empty);
                jsonResultMessage.data = WebHelper.ToSelectListItem<SucursalDTO>(
                  sucursalDTOList, x => x.SucursalId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

                return Json(jsonResultMessage,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public JsonResult ListarAlmacen(string sucursalId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                parameters.Add("sucursalId", sucursalId);
                List<AlmacenDTO> almacenDTOList = _almacenService.SearchFor(parameters, string.Empty);

                jsonResultMessage.data = WebHelper.ToSelectListItem<AlmacenDTO>(
                almacenDTOList, x => x.AlmacenId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

                return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Login");
        }

        private async Task SignInAsync(Service.ApplicationUser user, bool isPersistent)
        {

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private string redirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Url.Content(returnUrl);
            }
            else
            {
                return Url.Action("Index", "Home");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.UserManager != null)
            {
                this.UserManager.Dispose();
                this.UserManager = null;
            }
            base.Dispose(disposing);
        }
    }
}