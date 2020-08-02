using Infiniteskills.Common;
using Infiniteskills.Helpers;
using Infiniteskills.Transport;
using Infiniteskills.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.AM.Controllers
{
    public class AlmacenController : Controller
    {
        private IAlmacenService almacenService;
        private IEmpresaService empresaService;
        private ISucursalService sucursalService;
        private ISerieService serieService;
        private IDocumentoComercialService documentoComercialService;
        public AlmacenController(IAlmacenService almacenService,
            IEmpresaService empresaService, ISucursalService sucursalService,
            ISerieService serieService, IDocumentoComercialService documentoComercialService)
        {
            this.almacenService = almacenService;
            this.empresaService = empresaService;
            this.sucursalService = sucursalService;
            this.serieService = serieService;
            this.documentoComercialService = documentoComercialService;
        }

        // GET: AM/Almacen
        [HttpGet]
        public ActionResult Bandeja()
        {


            return PartialView();
        }


        [HttpPost]
        public ActionResult ListarBandeja(string nombre, string empresa, string sucursal)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrEmpty(nombre))
                    parameters.Add("nombre", nombre);

                if (!string.IsNullOrEmpty(empresa))
                    parameters.Add("empresa", empresa);

                if (!string.IsNullOrEmpty(sucursal))
                    parameters.Add("sucursal", sucursal);


                List<AlmacenDTO> empresaDTOList = almacenService.SearchFor(parameters, string.Empty).Cast<AlmacenDTO>().ToList();
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
                                   AlmacenId = f.AlmacenId,
                                   Nombre = f.Nombre,
                                   Direccion = f.Direccion,
                                   Telefono = f.Telefono,
                                   Empresa = f.SucursalDTO.EmpresaDTO.Nombre,
                                   Sucursal = f.SucursalDTO.Nombre
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
        public ActionResult ListarSerie(string almacenId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {

                parameters.Add("almacenId", almacenId);
                List<SerieDTO> serieDTOList = serieService.SearchFor(parameters, string.Empty).Cast<SerieDTO>().ToList();
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = serieDTOList.Count,
                    rows = from f in serieDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   SerieId = f.SerieId,
                                   NumeroSerie = f.NumeroSerie,
                                   NumeroLinea = f.NumeroLinea,
                                   FormatoDocumento = f.FormatoDocumento,
                                   Observacion = f.Observacion
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


        [HttpGet]
        public ActionResult Create(string editAction, string almacenId)
        {
            AlmacenDTO almacenDTO = new AlmacenDTO();
            try
            {
                switch (editAction)
                {
                    case EditActionConstant.NEW:
                        ViewBag.Title = "Nuevo Almacen";
                        almacenDTO.EditAction = editAction;
                        break;
                    case EditActionConstant.EDIT:
                        ViewBag.Title = "Editar Almacen";
                        almacenDTO = almacenService.GetById(Convert.ToInt32(almacenId));
                        if (almacenDTO.StockSn == "S")
                            almacenDTO.StockSn = "1";
                        else
                            almacenDTO.StockSn = "0";

                        almacenDTO.EditAction = editAction;
                        break;
                }
                listDropList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return PartialView(almacenDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JsonHeader collection)
        {
            AlmacenDTO almacenDTO = new AlmacenDTO();
            Dictionary<string, string> editDictionary = WebHelper.JsonToDictionary(collection.Header);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                if (collection.EditAction == EditActionConstant.EDIT)
                    almacenDTO.AlmacenId = Convert.ToInt32(editDictionary["AlmacenId"]);

                //almacenDTO.EmpresaId = Convert.ToInt32(editDictionary["EmpresaId"]);
                almacenDTO.SucursalId = Convert.ToInt32(editDictionary["SucursalId"]);

                almacenDTO.Nombre = editDictionary["Nombre"].ToString();
                almacenDTO.Direccion = editDictionary["Direccion"].ToString();
                almacenDTO.Nombre = editDictionary["Nombre"].ToString();
                almacenDTO.Telefono = editDictionary["Telefono"].ToString();
                if (editDictionary.ContainsKey("StockSn"))
                    almacenDTO.StockSn = "S";
                else
                    almacenDTO.StockSn = "N";

                almacenDTO.Estado = EstadoConstante.ACTIVO;
                almacenDTO.UsuarioCreacionId = 1;
                almacenDTO.FechaCreacion = DateTime.Now;

                if (collection.EditAction == EditActionConstant.NEW)
                    almacenService.Create(almacenDTO);
                else
                    almacenService.Update(almacenDTO);

                jsonResultMessage.message = "Almacen grabado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                jsonResultMessage.success = false;
                jsonResultMessage.message = ex.Message;
            }
            return Json(jsonResultMessage);
        }

        [HttpGet]
        public ActionResult SerieEdit(string serieId, string editAction)
        {
            SerieDTO serieDTO = new SerieDTO();

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            List<DocumentoComercialDTO> documentoComercialDTOList = documentoComercialService.SearchFor(parameters, string.Empty);
            ViewBag.DocumentoList = WebHelper.ToSelectListItem<DocumentoComercialDTO>(
                documentoComercialDTOList, x => x.DocumentoComercialId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            switch (editAction)
            {
                case EditActionConstant.NEW:
                    break;
                case EditActionConstant.EDIT:
                    serieDTO = serieService.GetById(Convert.ToInt32(serieId));
                    break;
            }

            return PartialView(serieDTO);
        }


        [HttpPost]
        public ActionResult GrabarSerie(JsonHeader collection)
        {
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Header);
            Dictionary<string, string> detailDictionary = WebHelper.JsonToDictionary(collection.Detail);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                SerieDTO serieDTO = new SerieDTO();
                serieDTO.SerieId = Convert.ToInt32(detailDictionary["SerieId"]);
                serieDTO.AlmacenId = Convert.ToInt32(headerDictionary["AlmacenId"]);
                serieDTO.DocumentoComercialId = Convert.ToInt32(detailDictionary["DocumentoComercialId"]);
                serieDTO.NumeroSerie = Convert.ToString(detailDictionary["NumeroSerie"]);
                serieDTO.NumeroLinea = Convert.ToInt32(detailDictionary["NumeroLinea"]);
                serieDTO.FormatoDocumento = Convert.ToString(detailDictionary["FormatoDocumento"]);
                serieDTO.IgvSn = Convert.ToString(detailDictionary["IgvSn"]);
                serieDTO.Observacion = Convert.ToString(detailDictionary["Observacion"]);
                serieDTO.Estado = EstadoConstante.ACTIVO;
                serieDTO.UsuarioCreacionId = 1;
                serieDTO.FechaCreacion = DateTime.Now;

                if (collection.EditAction != EditActionConstant.EDIT)
                    serieService.Create(serieDTO);
                else
                    serieService.Update(serieDTO);


                jsonResultMessage.message = "Numero serie para esta almacen grabado satisfactoriamente.";
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Json(jsonResultMessage);
        }

        private void listDropList()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            List<EmpresaDTO> empresaDTOList = empresaService.SearchFor(parameters, string.Empty);
            ViewBag.EmpresaList = WebHelper.ToSelectListItem<EmpresaDTO>(
                empresaDTOList, x => x.EmpresaId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


            List<SucursalDTO> sucursalDTOList = sucursalService.SearchFor(parameters, string.Empty);
            ViewBag.SucursalList = WebHelper.ToSelectListItem<SucursalDTO>(
                sucursalDTOList, x => x.SucursalId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

        }
    }
}