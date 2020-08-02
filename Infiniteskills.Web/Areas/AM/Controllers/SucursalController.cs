using System;
using System.Collections.Generic;
using System.Linq;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using Infiniteskills.Helpers;
using System.Web.Mvc;
using Infiniteskills.Common;

namespace Infiniteskills.Web.Areas.AM.Controllers
{

    public class SucursalController : Controller
    {
        private ISucursalService sucursalService;
        private IEmpresaService empresaService;
        private IPaisService paisService;
        private IDepartamentoService departamentoService;
        private IProvinciaService provinciaService;
        private IDistritoService distritoService;

        public SucursalController(ISucursalService sucursalService,
            IEmpresaService empresaService, IPaisService paisService,
            IDepartamentoService departamentoService, 
            IProvinciaService provinciaService,
            IDistritoService distritoService)
        {
            this.sucursalService = sucursalService;
            this.empresaService = empresaService;
            this.paisService = paisService;
            this.departamentoService = departamentoService;
            this.provinciaService = provinciaService;
            this.distritoService = distritoService;
        }
        // GET: Almacen
        public ActionResult Bandeja()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ListarBandeja(string codigo, string nombre, string empresa)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrEmpty(codigo))
                    parameters.Add("codigo", codigo);

                if (!string.IsNullOrEmpty(nombre))
                    parameters.Add("nombre", nombre);

                if (!string.IsNullOrEmpty(empresa))
                    parameters.Add("empresa", empresa);

                List<SucursalDTO> empresaDTOList = sucursalService.SearchFor(parameters, string.Empty).Cast<SucursalDTO>().ToList();
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = empresaDTOList.Count,
                    rows = from f in empresaDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   SucursalId = f.SucursalId,
                                   Empresa = f.EmpresaDTO.Nombre,
                                   Nombre = f.Nombre,
                                   Telefono = f.Telefono,
                                   Direccion = f.Direccion,
                                   Capacidad = f.Capacidad,

                               }
                           }
                };

                return Json(jsonData);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: Almacen/Create
        public ActionResult Create(string editAction, string sucursalId)
        {
            SucursalDTO sucursalDTO = new SucursalDTO();
            try
            {
                ViewBag.IsNew = true;
                switch (editAction)
                {
                    case EditActionConstant.NEW:
                        ListarUbigeo();
                        ViewBag.Title = "Nuevo Sucursal";
                        sucursalDTO.EditAction = editAction;
                        break;
                    case EditActionConstant.EDIT:
                        ViewBag.IsNew = false;
                        ViewBag.Title = "Editar Sucursal";
                        sucursalDTO = sucursalService.GetById(Convert.ToInt32(sucursalId));
                        sucursalDTO.EditAction = editAction;
                        ListarUbigeo(sucursalDTO.DistritoDTO.ProvinciaDTO.DepartamentoDTO.PaisId);
                        break;
                }

                Dictionary<string, object> parameters = new Dictionary<string, object>();

                List<EmpresaDTO> empresaDTOList = empresaService.SearchFor(parameters, string.Empty).Cast<EmpresaDTO>().ToList();
                ViewBag.ListEmpresa = WebHelper.ToSelectListItem<EmpresaDTO>(empresaDTOList,
                    x => x.EmpresaId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return PartialView(sucursalDTO);
        }

  

        private void ListarUbigeo()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            List<PaisDTO> paisDTOList = paisService.SearchFor(parameters, string.Empty);
            ViewBag.PaisList = WebHelper.ToSelectListItem<PaisDTO>(
                paisDTOList, x => x.PaisId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            parameters.Add("paisId", paisDTOList.FirstOrDefault().PaisId);
            List<DepartamentoDTO> departamentoDTOList = departamentoService.SearchFor(parameters, string.Empty);
            ViewBag.DepartamentoList = WebHelper.ToSelectListItem<DepartamentoDTO>(
                departamentoDTOList, x => x.DepartamentoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            parameters.Add("departamentoId", departamentoDTOList.FirstOrDefault().DepartamentoId);
            List<ProvinciaDTO> provinciaDTOList = provinciaService.SearchFor(parameters, string.Empty);
            ViewBag.ProvinciaList = WebHelper.ToSelectListItem<ProvinciaDTO>(
                provinciaDTOList, x => x.ProvinciaId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            parameters.Add("provinciaId", provinciaDTOList.FirstOrDefault().ProvinciaId);
            List<DistritoDTO> distritoDTOList = distritoService.SearchFor(parameters, string.Empty);
            ViewBag.DistritoList = WebHelper.ToSelectListItem<DistritoDTO>(
                distritoDTOList, x => x.DistritoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


        }

        private void ListarUbigeo(int paisId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            List<PaisDTO> paisDTOList = paisService.SearchFor(parameters, string.Empty);
            ViewBag.PaisList = WebHelper.ToSelectListItem<PaisDTO>(
                paisDTOList, x => x.PaisId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            parameters.Add("paisId", paisDTOList.FirstOrDefault().PaisId);
            List<DepartamentoDTO> departamentoDTOList = departamentoService.SearchFor(parameters, string.Empty);
            ViewBag.DepartamentoList = WebHelper.ToSelectListItem<DepartamentoDTO>(
                departamentoDTOList, x => x.DepartamentoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            parameters.Add("departamentoId", departamentoDTOList.FirstOrDefault().DepartamentoId);
            List<ProvinciaDTO> provinciaDTOList = provinciaService.SearchFor(parameters, string.Empty);
            ViewBag.ProvinciaList = WebHelper.ToSelectListItem<ProvinciaDTO>(
                provinciaDTOList, x => x.ProvinciaId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            parameters.Add("provinciaId", provinciaDTOList.FirstOrDefault().ProvinciaId);
            List<DistritoDTO> distritoDTOList = distritoService.SearchFor(parameters, string.Empty);
            ViewBag.DistritoList = WebHelper.ToSelectListItem<DistritoDTO>(
                distritoDTOList, x => x.DistritoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JsonHeader collection)
        {
            Dictionary<string, string> editDictionary = WebHelper.JsonToDictionary(collection.Header);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            SucursalDTO sucursalDTO = new SucursalDTO();
            try
            {
                if (collection.EditAction == EditActionConstant.EDIT)
                    sucursalDTO.SucursalId = Convert.ToInt32(editDictionary["SucursalId"]);

                sucursalDTO.EmpresaId = Convert.ToInt32(editDictionary["EmpresaId"]);
                sucursalDTO.Nombre = editDictionary["Nombre"].ToString();
                sucursalDTO.Direccion = editDictionary["Direccion"].ToString();
                sucursalDTO.Telefono = editDictionary["Telefono"].ToString();
                sucursalDTO.Capacidad = editDictionary["Capacidad"].ToString();
                sucursalDTO.DistritoId = Convert.ToInt32(editDictionary["DistritoId"]);
                sucursalDTO.Estado = EstadoConstante.ACTIVO;
               

                if (collection.EditAction == EditActionConstant.NEW)
                    sucursalService.Create(sucursalDTO);
                else
                    sucursalService.Update(sucursalDTO);

                jsonResultMessage.message = "Sucursal grabado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                jsonResultMessage.success = false;
                jsonResultMessage.message = ex.Message;
            }
            return Json(jsonResultMessage);
        }



        [HttpPost]
        public JsonResult GetDepartamento(int paisId)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "paisId", paisId }
                };

                List<DepartamentoDTO> departamentoDTOList = departamentoService.SearchFor(parameters, string.Empty);
                jsonResultMessage.data = WebHelper.ToSelectListItem<DepartamentoDTO>(
                   departamentoDTOList, x => x.DepartamentoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);
            }
            catch (Exception ex)
            {
                jsonResultMessage.message = ex.Message;
                jsonResultMessage.success = false;
            }
            return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetProvincia(int departamentoId)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "departamentoId", departamentoId }
                };
                List<ProvinciaDTO> provinciaDTOList = provinciaService.SearchFor(parameters, string.Empty);
                jsonResultMessage.data = WebHelper.ToSelectListItem<ProvinciaDTO>(
                provinciaDTOList, x => x.ProvinciaId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDistrito(int provinciaId)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "provinciaId", provinciaId }
                };
                List<DistritoDTO> distritoDTOList = distritoService.SearchFor(parameters, string.Empty);
                jsonResultMessage.data = WebHelper.ToSelectListItem<DistritoDTO>(
             distritoDTOList, x => x.DistritoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
        }



    }
}