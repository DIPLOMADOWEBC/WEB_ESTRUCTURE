using Infiniteskills.Common;
using Infiniteskills.Helpers;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.CG.Controllers
{
    public class PeriodoController : Controller
    {
        private IPeriodoService periodoService;
        private IPeriodoEmpresaService periodoEmpresaService;
        private ITablaService tablaService;
        private IPeriodoCorrelativoService periodoCorrelativoService;
        private ISucursalService sucursalService;
        public PeriodoController(IPeriodoService periodoService,
            IPeriodoEmpresaService periodoEmpresaService, ITablaService tablaService,
            IPeriodoCorrelativoService periodoCorrelativoService, ISucursalService sucursalService)
        {
            this.periodoService = periodoService;
            this.periodoEmpresaService = periodoEmpresaService;
            this.tablaService = tablaService;
            this.periodoCorrelativoService = periodoCorrelativoService;
            this.sucursalService = sucursalService;

        }
        public ActionResult Bandeja()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ListarPeriodo()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                List<PeriodoDTO> periodoDTOList = periodoService.SearchFor(parameters, string.Empty);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = periodoDTOList.Count,
                    rows = from f in periodoDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   PeriodoId = f.PeriodoId,
                                   Periodo = f.PeriodoEjucion,
                                   Nombre = f.Nombre
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

        [HttpPost]
        public ActionResult ListarPeriodoEmpresa()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                List<PeriodoEmpresaDTO> periodoEmpresaList = periodoEmpresaService.SearchFor(parameters, string.Empty);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = periodoEmpresaList.Count,
                    rows = from f in periodoEmpresaList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   PeriodoEmpresaId = f.PeriodoEmpresaId,
                                   Periodo = f.PeriodoDTO.PeriodoEjucion,
                                   Nombre = f.SucursalDTO.Nombre
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

        [HttpPost]
        public ActionResult ListarTabla()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                List<TablaDTO> tablaList = tablaService.SearchFor(parameters, string.Empty);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = tablaList.Count,
                    rows = from f in tablaList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   TablaId = f.TablaId,
                                   Codigo = f.Codigo,
                                   Nombre = f.Nombre,
                                   Formato = f.Formato
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

        [HttpPost]
        public ActionResult ListarPeriodoCorrelativo()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                List<PeriodoCorrelativoDTO> tablaList = periodoCorrelativoService.SearchFor(parameters, string.Empty);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = tablaList.Count,
                    rows = from f in tablaList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   PeriodoCorrelativoId = f.PeriodoCorrelativoId,
                                   PeriodoEjucion = f.PeriodoEmpresaDTO.PeriodoDTO.PeriodoEjucion,
                                   PeriodoEmpresa = f.PeriodoEmpresaDTO.SucursalDTO.Nombre,
                                   Tabla = f.TablaDTO.Nombre,
                                   Correlativo = f.Correlativo
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


        // GET: CG/Periodo/Details/5
        [HttpGet]
        public ActionResult PeriodoEdit(string editAction,
            string periodoId)
        {
            PeriodoDTO periodoDTO = new PeriodoDTO();
            switch (editAction)
            {
                case EditActionConstant.NEW:
                    break;
                case EditActionConstant.EDIT:
                    periodoDTO = periodoService.GetById(Convert.ToInt32(periodoId));
                    break;
            }
      
            return PartialView(periodoDTO);
        }

  

        [HttpPost]
        public ActionResult PeriodoGuardar(JsonHeader collection)
        {
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Header);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            PeriodoDTO periodoDTO = new PeriodoDTO();
            try
            {
                periodoDTO.PeriodoId= Convert.ToInt32(headerDictionary["PeriodoId"]);
                periodoDTO.PeriodoEjucion = Convert.ToInt32(headerDictionary["PeriodoEjucion"]);
                periodoDTO.Nombre = Convert.ToString(headerDictionary["Nombre"]);
                periodoDTO.Estado = EstadoConstante.ACTIVO;
                if (collection.EditAction == EditActionConstant.NEW)
                    periodoService.Create(periodoDTO);
                else
                    periodoService.Update(periodoDTO);

                jsonResultMessage.message = "Periodo grabado satisfactoriamente.";
                return Json(jsonResultMessage);
            }
            catch (Exception ex)
            {

                throw ex;
            };
        }

        [HttpPost]
        public ActionResult PeriodoEmpresaGuardar(JsonHeader collection)
        {
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Header);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            PeriodoEmpresaDTO periodoDTO = new PeriodoEmpresaDTO();
            try
            {
                periodoDTO.PeriodoEmpresaId = Convert.ToInt32(headerDictionary["PeriodoEmpresaId"]);
                periodoDTO.PeriodoId = Convert.ToInt32(headerDictionary["PeriodoId"]);
                periodoDTO.SucursalId = Convert.ToInt32(headerDictionary["SucursalId"]);
                periodoDTO.Estado = EstadoConstante.ACTIVO;
                if (collection.EditAction == EditActionConstant.NEW)
                    periodoEmpresaService.Create(periodoDTO);
                else
                    periodoEmpresaService.Update(periodoDTO);

                jsonResultMessage.message = "Periodo empresa grabado satisfactoriamente.";
                return Json(jsonResultMessage);
            }
            catch (Exception ex)
            {

                throw ex;
            };
        }

        // GET: CG/Periodo/Create

        [HttpGet]
        public ActionResult PeriodoEmpresaEdit(string editAction,
            string periodoEmpresaId)
        {
            PeriodoEmpresaDTO periodoDTO = new PeriodoEmpresaDTO();
            switch (editAction)
            {
                case EditActionConstant.NEW:
                    break;
                case EditActionConstant.EDIT:
                    periodoDTO = periodoEmpresaService.GetById(Convert.ToInt32(periodoEmpresaId));
                    break;
            }
            periodoEmpresa();
            return PartialView(periodoDTO);
        }
        private void periodoEmpresa()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            List<PeriodoDTO> periodoDTOList = periodoService.SearchFor(parameters, string.Empty);
            ViewBag.ListarPeriodo = WebHelper
                .ToSelectListItem<PeriodoDTO>(periodoDTOList, x => x.PeriodoId.ToString(), x => x.PeriodoEjucion.ToString(),
                SelectListFirstElementType.Select, string.Empty);


            List<SucursalDTO> sucursalDTOList = sucursalService.SearchFor(parameters, string.Empty);
            ViewBag.SucursalList = WebHelper.ToSelectListItem<SucursalDTO>(sucursalDTOList, x => x.SucursalId.ToString(), x => x.Nombre.ToString(),
                SelectListFirstElementType.Select, string.Empty);
        }

    }
}
