using Infiniteskills.Common;
using Infiniteskills.Transport;
using Infiniteskills.Service;
using Infiniteskills.Web.Models;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Web.Controllers
{
    public class MenuController : AppController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IMenuService _menuService;
        public MenuController(IMenuService menuService, IUsuarioService usuarioService)
            :base(usuarioService)
        {
            _menuService = menuService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetMenu()
        {
            logger.Info("ObtenerMenuAsignado :: Start Execution");

            List<MenuDTO> menuList = new List<MenuDTO>();

            if (this.EsAdministrador())
            {
                logger.Info("ObtenerMenuAsignado :: EsAdministrador");
         
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("estado", EstadoConstante.ACTIVO);

                menuList = _menuService.SearchFor(parameters, string.Empty).Cast<MenuDTO>().ToList();
            }
            else
            {
                //IServiceBase rolMenuService = WCFHelper.GetObject<IServiceBase>(typeof(RolMenuService));
                //Dictionary<string, object> parameters = new Dictionary<string, object>();
                //parameters.Add("rolList", this.ObtenerRoles());
                //parameters.Add("lectura", HabilitadoConstante.HABILITADO);

                //List<RolMenuDTO> rolMenuList = rolMenuService.SearchFor(parameters, String.Empty).Cast<RolMenuDTO>().ToList();
                //foreach (RolMenuDTO rolMenuDTO in rolMenuList)
                //{
                //    if (menuList.Count > 0)
                //    {
                //        if (menuList.SingleOrDefault(m => m.MenuId == rolMenuDTO.MenuDTO.MenuId) == null)
                //            menuList.Add(rolMenuDTO.MenuDTO);
                //    }
                //    else
                //        menuList.Add(rolMenuDTO.MenuDTO);
                //}
            }

            List<MenuTreeNode> menuNodeList = ObtenerArbol(menuList.Distinct().OrderBy(x => x.MenuId).ToList(), null);

            var a = JsonConvert.SerializeObject(menuNodeList);

            logger.Info("ObtenerMenuAsignado :: Execution finished!");
            return Json(menuNodeList, JsonRequestBehavior.AllowGet);
        }
        public List<MenuTreeNode> ObtenerArbol(List<MenuDTO> list, int? parent)
        {
            return list.Where(x => x.MenuPadreId == parent).Select(x => new MenuTreeNode
            {
                Id = x.MenuId.ToString(),
                Text = x.Nombre,
                Icon = x.RutaImagen,
                Url = obtenerURL(x),
                Nodes = ObtenerArbol(list, x.MenuId),
                Order = x.Orden,
            }).OrderBy(x => x.Order).ToList();
        }
        private string obtenerURL(MenuDTO menuDTO)
        {
            string parameters = string.Empty;
            string url = string.Empty;

            if (String.IsNullOrEmpty(menuDTO.Url))
                url = string.Empty;
            else
            {
                string actionName = menuDTO.Url.Split('/')[1];
                string controllerName = menuDTO.Url.Split('/')[0];
                if (actionName.IndexOf('?') > 0)
                {
                    parameters = string.Concat("?", actionName.Split('?')[1]);
                    actionName = actionName.Split('?')[0];
              }
                url = Url.Action(actionName, controllerName, new { area = menuDTO.Area.Trim() });
            }
            return string.Concat(url, parameters);
        }
    }
}