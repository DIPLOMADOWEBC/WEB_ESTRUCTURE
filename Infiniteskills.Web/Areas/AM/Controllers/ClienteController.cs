using System;
using System.Collections.Generic;
using System.Linq;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using Infiniteskills.Helpers;
using System.Web.Mvc;
using Infiniteskills.Common;
using System.Threading.Tasks;
using Infiniteskills.Infra.Base;
using Newtonsoft.Json;
using Infiniteskills.Web.Models;
using System.Configuration;

namespace Infiniteskills.Web.Areas.AM.Controllers
{

    //[CustomAuthorize]
    public class ClienteController : Controller
    {
        private IProveedorService _clienteService;
        private IContactoService _contactoService;
        private IDireccionService _direccionService;
        private IProveedorContactoService _proveedorContactoService;
        private IDocumentoIdentidadService _docIdentidadService;
        private IPaisService _paisService;
        private IDepartamentoService _departamentoService;
        private IProvinciaService _provinciaService;
        private IDistritoService _distritoService;
        private ITipoProveedorService _tipoProveedorService;
        private IFormaVentaService _formaVentaService;
        private IPersonalService _personalService;
        private IMonedaService _monedaService;
        private ITipoPrecioService _tipoPrecioService;
        private ISunatClient sunatClient;
        private IAreaService areaService;
        public ClienteController(IProveedorService clienteService,
            IDocumentoIdentidadService docIdentidadService, ITipoProveedorService tipoProveedorService,
              IPaisService paisService, IDepartamentoService departamentoService,
            IProvinciaService provinciaService, IDistritoService distritoService,
              IFormaVentaService formaVentaService, IContactoService contactoService,
              IProveedorContactoService proveedoContactoService, IDireccionService direccionService,
              IPersonalService personalService, IMonedaService monedaService, ISunatClient sunatClient,
              ITipoPrecioService tipoPrecioService, IAreaService areaService)
        {
            _clienteService = clienteService;
            _docIdentidadService = docIdentidadService;
            _tipoProveedorService = tipoProveedorService;
            _paisService = paisService;
            _departamentoService = departamentoService;
            _provinciaService = provinciaService;
            _distritoService = distritoService;
            _formaVentaService = formaVentaService;
            _contactoService = contactoService;
            _proveedorContactoService = proveedoContactoService;
            _direccionService = direccionService;
            _personalService = personalService;
            _monedaService = monedaService;
            _tipoPrecioService = tipoPrecioService;
            this.sunatClient = sunatClient;
            this.areaService = areaService;

        }
        // GET: Cliente
        public ActionResult Bandeja()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ListarBandeja(string numeroDocumento,
            string razonSocial, string nombre)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {

                if (!string.IsNullOrEmpty(numeroDocumento))
                    parameters.Add("numeroDocumento", numeroDocumento);

                if (!string.IsNullOrEmpty(razonSocial))
                    parameters.Add("razonSocial", razonSocial);

                if (!string.IsNullOrEmpty(nombre))
                    parameters.Add("nombre", nombre);


                List<ProveedorDTO> clienteDTOList = _clienteService.SearchFor(parameters, string.Empty).Cast<ProveedorDTO>().ToList();
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = clienteDTOList.Count,
                    rows = from f in clienteDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   f.ProveedorId,
                                   TipoProveedor = f.TipoProveedorDTO.Nombre,
                                   f.NumeroDocumento,
                                   f.RazonSocial,
                                   f.Nombres,
                                   Telefono = string.Concat(f.Telefono.Trim(), " / ", f.Celular.Trim())
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
        public ActionResult ListarContacto(string proveedorId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                parameters.Add("proveedorId", proveedorId);
                List<ProveedorContactoDTO> proveedorContactoDTOList = _proveedorContactoService.SearchFor(parameters, string.Empty)
                    .Cast<ProveedorContactoDTO>().ToList();

                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = proveedorContactoDTOList.Count,
                    rows = from f in proveedorContactoDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   f.ContactoId,
                                   f.ContactoDTO.ProveedorId,
                                   f.ContactoDTO.AreaId,
                                   Area = f.ContactoDTO.AreaDTO.Nombre,
                                   f.ContactoDTO.NombreContacto,
                                   f.ContactoDTO.NumeroDocumentoContacto,
                                   f.ContactoDTO.TelefonoContacto,
                                   f.ContactoDTO.CelularContacto,
                                   f.ContactoDTO.EmailContacto,
                                   f.ContactoDTO.DireccionContacto,
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
        public ActionResult ListarDireccion(string proveedorId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                parameters.Add("proveedorId", proveedorId);

                List<DireccionProveedorDTO> direccionDTOList = _direccionService.SearchFor(parameters, string.Empty)
                    .Cast<DireccionProveedorDTO>().ToList();

                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = direccionDTOList.Count,
                    rows = from f in direccionDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   f.DireccionId,
                                   f.NombreDireccion,
                                   f.Referencia,
                                   f.DistritoId,
                                   Pais = f.DistritoDTO.ProvinciaDTO.DepartamentoDTO.PaisDTO.Nombre,
                                   Departamento = f.DistritoDTO.ProvinciaDTO.DepartamentoDTO.Nombre,
                                   Provincia = f.DistritoDTO.ProvinciaDTO.Nombre,
                                   Distrito = f.DistritoDTO.Nombre
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

        // GET: Cliente/Create
        [HttpGet]
        public ActionResult Create(string editAction, string proveedorId)
        {
            ProveedorDTO clienteDTO = new ProveedorDTO();
            switch (editAction)
            {
                case EditActionConstant.NEW:
                    ViewBag.IsNew = true;
                    ViewBag.Title = "Nuevo Cliente";
                    clienteDTO.EditAction = editAction;
                    ListarUbigeo();
                    break;
                case EditActionConstant.EDIT:
                    ViewBag.IsNew = false;
                    ViewBag.Title = "Editar Cliente";
                    clienteDTO = _clienteService.GetById(Convert.ToInt32(proveedorId));
                    clienteDTO.EditAction = editAction;
                    ListarUbigeo(clienteDTO);
                    break;
            }

            PopulateDropList();
            return PartialView(clienteDTO);
        }

        private void PopulateDropList()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            List<TipoProveedorDTO> tipoProveedorList = _tipoProveedorService.SearchFor(parameters, string.Empty);
            ViewBag.TipoProvList = WebHelper.ToSelectListItem<TipoProveedorDTO>(
                tipoProveedorList, x => x.TipoProveedorId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


            List<DocumentoIdentidadDTO> docIdentidadDTOList = _docIdentidadService.SearchFor(parameters, string.Empty)
                .Cast<DocumentoIdentidadDTO>().ToList();
            ViewBag.ListaDocIdenti = WebHelper.ToSelectListItem<DocumentoIdentidadDTO>(docIdentidadDTOList,
                x => x.DocumentoIdentidadId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            List<PaisDTO> paisDTOList = _paisService.SearchFor(parameters, string.Empty);
            ViewBag.PaisList = WebHelper.ToSelectListItem<PaisDTO>(
                paisDTOList, x => x.PaisId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            List<FormaVentaDTO> formaVentaDTOList = _formaVentaService.SearchFor(parameters, string.Empty);
            ViewBag.FormaVentaList = WebHelper.ToSelectListItem<FormaVentaDTO>(
                formaVentaDTOList, x => x.FormaVentaId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


            List<PersonalDTO> personalDTOList = _personalService.SearchFor(parameters, string.Empty);
            ViewBag.ListarPersonal = WebHelper.ToSelectListItem<PersonalDTO>(
                personalDTOList, x => x.PersonalId.ToString(), x => string.Concat(x.Nombres, " ", x.Apellidos), SelectListFirstElementType.Select, string.Empty);

            List<MonedaDTO> monedaDTOList = _monedaService.SearchFor(parameters, string.Empty);
            ViewBag.MonedaList = WebHelper.ToSelectListItem<MonedaDTO>(
                monedaDTOList, x => x.MonedaId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


            List<TipoPrecioDTO> tipoPrecioDTOList = _tipoPrecioService.SearchFor(parameters, string.Empty);
            ViewBag.TipoPrecioList = WebHelper.ToSelectListItem<TipoPrecioDTO>(
                tipoPrecioDTOList, x => x.TipoPrecioId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);
        }

        private void ListarUbigeo()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();


            List<PaisDTO> paisDTOList = _paisService.SearchFor(parameters, string.Empty);
            ViewBag.PaisList = WebHelper.ToSelectListItem<PaisDTO>(
                paisDTOList, x => x.PaisId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            parameters.Add("paisId", paisDTOList.FirstOrDefault().PaisId);
            List<DepartamentoDTO> departamentoDTOList = _departamentoService.SearchFor(parameters, string.Empty);
            ViewBag.DepartamentoList = WebHelper.ToSelectListItem<DepartamentoDTO>(
                departamentoDTOList, x => x.DepartamentoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            parameters.Add("departamentoId", departamentoDTOList.FirstOrDefault().DepartamentoId);
            List<ProvinciaDTO> provinciaDTOList = _provinciaService.SearchFor(parameters, string.Empty);
            ViewBag.ProvinciaList = WebHelper.ToSelectListItem<ProvinciaDTO>(
                provinciaDTOList, x => x.ProvinciaId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            parameters.Add("provinciaId", provinciaDTOList.FirstOrDefault().ProvinciaId);
            List<DistritoDTO> distritoDTOList = _distritoService.SearchFor(parameters, string.Empty);
            ViewBag.DistritoList = WebHelper.ToSelectListItem<DistritoDTO>(
                distritoDTOList, x => x.DistritoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


        }

        private void ListarUbigeo(ProveedorDTO proveedor)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            List<PaisDTO> paisDTOList = _paisService.SearchFor(parameters, string.Empty);
            ViewBag.PaisList = WebHelper.ToSelectListItem<PaisDTO>(
                paisDTOList, x => x.PaisId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            parameters.Add("paisId", proveedor.DistritoDTO.ProvinciaDTO.DepartamentoDTO.PaisId);
            List<DepartamentoDTO> departamentoDTOList = _departamentoService.SearchFor(parameters, string.Empty);
            ViewBag.DepartamentoList = WebHelper.ToSelectListItem<DepartamentoDTO>(
                departamentoDTOList, x => x.DepartamentoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            parameters.Add("departamentoId", proveedor.DistritoDTO.ProvinciaDTO.DepartamentoId);
            List<ProvinciaDTO> provinciaDTOList = _provinciaService.SearchFor(parameters, string.Empty);
            ViewBag.ProvinciaList = WebHelper.ToSelectListItem<ProvinciaDTO>(
                provinciaDTOList, x => x.ProvinciaId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            parameters.Add("provinciaId", proveedor.DistritoDTO.ProvinciaId);
            List<DistritoDTO> distritoDTOList = _distritoService.SearchFor(parameters, string.Empty);
            ViewBag.DistritoList = WebHelper.ToSelectListItem<DistritoDTO>(
                distritoDTOList, x => x.DistritoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JsonHeader collection)
        {
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Header);
            Dictionary<string, string>[] rowDictionary = WebHelper.JsonToArrayDictionary(collection.Row);
            Dictionary<string, string>[] detailDictionary = WebHelper.JsonToArrayDictionary(collection.Detail);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            ProveedorDTO proveedorDTO = new ProveedorDTO();
            try
            {
                if (collection.EditAction == EditActionConstant.EDIT)
                    proveedorDTO.ProveedorId = Convert.ToInt32(headerDictionary["ProveedorId"]);

                proveedorDTO.PersonalId = Convert.ToInt32(headerDictionary["PersonalId"]);
                if (!string.IsNullOrEmpty(headerDictionary["TipoPrecioId"]))
                    proveedorDTO.TipoPrecioId = Convert.ToInt32(headerDictionary["TipoPrecioId"]);
                else
                    proveedorDTO.TipoPrecioId = null;

                if (!string.IsNullOrEmpty(headerDictionary["MonedaId"]))
                    proveedorDTO.MonedaId = Convert.ToInt32(headerDictionary["MonedaId"]);
                else
                    proveedorDTO.MonedaId = null;

                proveedorDTO.RazonSocial = headerDictionary["RazonSocial"].ToUpper().ToString().Trim();
                proveedorDTO.Nombres = headerDictionary["Nombres"].ToUpper().ToString().Trim();
                proveedorDTO.NombreDireccion = headerDictionary["NombreDireccion"].ToUpper().ToString().Trim();
                proveedorDTO.TipoProveedorId = Convert.ToInt32(headerDictionary["TipoProveedorId"]);
                proveedorDTO.DistritoId = Convert.ToInt32(headerDictionary["DistritoId"]);
                proveedorDTO.DocumentoIdentidadId = Convert.ToInt32(headerDictionary["DocumentoIdentidadId"]);
                proveedorDTO.NumeroDocumento = headerDictionary["NumeroDocumento"].ToString().Trim();
                proveedorDTO.Telefono = headerDictionary["Telefono"].ToString().Trim();
                proveedorDTO.Celular = headerDictionary["Celular"].ToString().Trim();
                proveedorDTO.CorreoUno = headerDictionary["CorreoUno"].ToString().Trim();
                proveedorDTO.CorreoDos = headerDictionary["CorreoDos"].ToString().Trim();
                proveedorDTO.PaginaWeb = headerDictionary["PaginaWeb"].ToString().Trim();
                proveedorDTO.TipoCliente = TipoProveedorConstant.CLIENTE;
                if (!string.IsNullOrEmpty(headerDictionary["FormaVentaId"]))
                    proveedorDTO.FormaVentaId = Convert.ToInt32(headerDictionary["FormaVentaId"]);
                else
                    proveedorDTO.FormaVentaId = null;

                proveedorDTO.Estado = EstadoConstante.ACTIVO;
                proveedorDTO.ContactoDTOList = rowDictionary.
                    Select(dictionary => new ContactoDTO()
                    {
                        ProveedorId = proveedorDTO.ProveedorId,
                        ContactoId = Convert.ToInt32(dictionary["ContactoId"]),
                        AreaId = Convert.ToInt32(dictionary["AreaId"]),
                        NombreContacto = dictionary["NombreContacto"].ToString(),
                        NumeroDocumentoContacto = dictionary["NumeroDocumentoContacto"].ToString(),
                        TelefonoContacto = dictionary["TelefonoContacto"].ToString(),
                        CelularContacto = dictionary["CelularContacto"].ToString(),
                        EmailContacto = dictionary["EmailContacto"].ToString(),
                        DireccionContacto = dictionary["DireccionContacto"].ToString(),
                        Estado = EstadoConstante.ACTIVO

                    }).ToList();

                proveedorDTO.DireccionDTOList = detailDictionary.
                    Select(dictionary => new DireccionProveedorDTO()
                    {
                        ProveedorId = proveedorDTO.ProveedorId,
                        DireccionId = Convert.ToInt32(dictionary["DireccionId"]),
                        NombreDireccion = dictionary["NombreDireccion"].ToString(),
                        Referencia = dictionary["Referencia"].ToString(),
                        Fiscal = "0",
                        DistritoId = Convert.ToInt32(headerDictionary["DistritoId"]),
                        Estado = EstadoConstante.ACTIVO

                    }).ToList();

                if (collection.EditAction == EditActionConstant.NEW)
                    _clienteService.InsertarCliente(proveedorDTO);
                else
                    _clienteService.ActualizarCliente(proveedorDTO);

                jsonResultMessage.message = "Cliente grabado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                jsonResultMessage.success = false;
                jsonResultMessage.message = ex.Message;
            }
            return Json(jsonResultMessage);
        }

        [HttpGet]
        public ActionResult ContactoEdit(string editAction,
            string contactoId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            ContactoDTO contactoDTO = new ContactoDTO();
            switch (editAction)
            {
                case EditActionConstant.NEW:

                    break;
                case EditActionConstant.EDIT:
                    contactoDTO = _contactoService.GetById(Convert.ToInt32(contactoId));
                    break;
            }
            List<AreaDTO> areaDTOList = areaService.SearchFor(parameters, string.Empty);
            ViewBag.AreaList = WebHelper.ToSelectListItem<AreaDTO>(
                areaDTOList, x => x.AreaId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            List<ContactoDTO> contactoDTOList = _contactoService.SearchFor(parameters, string.Empty);
            ViewBag.ContactoList = WebHelper.ToSelectListItem<ContactoDTO>(
                contactoDTOList, x => x.ContactoId.ToString(), x => x.NombreContacto, SelectListFirstElementType.Select, string.Empty);
            return PartialView(contactoDTO);
        }

        [HttpGet]
        public ActionResult DireccionEdit(string editAction,
            string direccionId)
        {
            DireccionProveedorDTO direccionDTO = new DireccionProveedorDTO();
            switch (editAction)
            {
                case EditActionConstant.NEW:
                    ViewBag.IsNew = true;
                    break;
                case EditActionConstant.EDIT:
                    ViewBag.IsNew = false;
                    direccionDTO = _direccionService.GetById(Convert.ToInt32(direccionId));
                    direccionDTO.Fiscal = direccionDTO.Fiscal.Trim();
                    break;
            }
            ListarUbigeo();
            return PartialView(direccionDTO);
        }

        [HttpPost]
        public ActionResult ContactoGuardar(JsonHeader collection)
        {
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Header);
            Dictionary<string, string> detailDictionary = WebHelper.JsonToDictionary(collection.Detail);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            ContactoDTO contactoDTO = new ContactoDTO();
            try
            {
                contactoDTO.ContactoId = Convert.ToInt32(detailDictionary["ContactoId"]);
                contactoDTO.ProveedorId = Convert.ToInt32(headerDictionary["ProveedorId"]);
                contactoDTO.AreaId = Convert.ToInt32(detailDictionary["AreaId"]);
                contactoDTO.NombreContacto = detailDictionary["NombreContacto"].ToUpper().ToString();
                contactoDTO.NumeroDocumentoContacto = detailDictionary["NumeroDocumentoContacto"].ToString().Trim();
                contactoDTO.TelefonoContacto = detailDictionary["TelefonoContacto"].Trim();
                contactoDTO.CelularContacto = detailDictionary["CelularContacto"].Trim();
                contactoDTO.DireccionContacto = detailDictionary["DireccionContacto"].Trim();
                contactoDTO.EmailContacto = detailDictionary["EmailContacto"].Trim();
                contactoDTO.Estado = EstadoConstante.ACTIVO;
                if (collection.EditAction == EditActionConstant.NEW)
                    _contactoService.InsertarContacto(contactoDTO);
                else
                    _contactoService.Update(contactoDTO);


                jsonResultMessage.message = "Contacto grabado satisfactoriamente.";
                return Json(jsonResultMessage);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult DireccionGuardar(JsonHeader collection)
        {
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Header);
            Dictionary<string, string> detailDictionary = WebHelper.JsonToDictionary(collection.Detail);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            DireccionProveedorDTO direccionDTO = new DireccionProveedorDTO();
            try
            {
                direccionDTO.DireccionId = Convert.ToInt32(detailDictionary["DireccionId"]);
                direccionDTO.ProveedorId = Convert.ToInt32(headerDictionary["ProveedorId"]);
                direccionDTO.NombreDireccion = detailDictionary["NombreDireccion"].ToUpper().ToString();
                direccionDTO.Referencia = detailDictionary["Referencia"].Trim();
                direccionDTO.DistritoId = Convert.ToInt32(detailDictionary["DistritoContactoId"]);
                direccionDTO.Estado = EstadoConstante.ACTIVO;
                if (detailDictionary.ContainsKey("Fiscal"))
                    direccionDTO.Fiscal = detailDictionary["Fiscal"].Trim();
                else
                    direccionDTO.Fiscal = "0";


                if (collection.EditAction == EditActionConstant.NEW)
                    _direccionService.Create(direccionDTO);
                else
                    _direccionService.Update(direccionDTO);



                jsonResultMessage.message = "Direccion grabado satisfactoriamente.";
                return Json(jsonResultMessage);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        public async Task<JsonResult> GetPersonal(string query)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                IEnumerable<PersonalDTO> personalDTOList = await _personalService.ListarPersonal(query);
                var jsonData = from f in personalDTOList.AsEnumerable()
                               select new
                               {

                                   f.PersonalId,
                                   f.Nombres
                               };
                jsonResultMessage.data = jsonData;

            }
            catch (Exception ex)
            {
                jsonResultMessage.message = ex.Message;
                jsonResultMessage.success = false;
            }
            return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public async Task<JsonResult> GetContacto(string query)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                IEnumerable<ContactoDTO> contactoDTOList = await _contactoService.ListarContacto(query);
                var jsonData = from f in contactoDTOList.AsEnumerable()
                               select new
                               {

                                   f.ContactoId,
                                   Nombre = f.NombreContacto
                               };
                jsonResultMessage.data = jsonData;

            }
            catch (Exception ex)
            {
                jsonResultMessage.message = ex.Message;
                jsonResultMessage.success = false;
            }
            return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public async Task<JsonResult> GetContactoById(int id)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                IEnumerable<ContactoDTO> contactoDTOList = await _contactoService.ListarContacto(id);
                var jsonData = from f in contactoDTOList.AsEnumerable()
                               select new
                               {

                                   f.ContactoId,
                                   f.NombreContacto,
                                   f.AreaId,
                                   f.NumeroDocumentoContacto,
                                   f.TelefonoContacto,
                                   f.CelularContacto,
                                   f.EmailContacto,
                                   f.DireccionContacto
                               };
                jsonResultMessage.data = jsonData.FirstOrDefault();

            }
            catch (Exception ex)
            {
                jsonResultMessage.message = ex.Message;
                jsonResultMessage.success = false;
            }
            return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
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

                List<DepartamentoDTO> departamentoDTOList = _departamentoService.SearchFor(parameters, string.Empty);
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
                List<ProvinciaDTO> provinciaDTOList = _provinciaService.SearchFor(parameters, string.Empty);
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
                List<DistritoDTO> distritoDTOList = _distritoService.SearchFor(parameters, string.Empty);
                jsonResultMessage.data = WebHelper.ToSelectListItem<DistritoDTO>(
             distritoDTOList, x => x.DistritoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public async Task<JsonResult> GetClienteSunat(string numeroruc)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            AccessTokenSunat accessToken = new AccessTokenSunat();
            try
            {

                accessToken.token = ConfigurationManager.AppSettings["KeyApiRuc"];
                accessToken.ruc = numeroruc;
                var response = await sunatClient.PostAsJsonAsync("/api/v1/ruc", accessToken);
                var respuesta = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<ProveedorSunatViewModel>(respuesta);
                if (data.codigo_de_zona != null)
                {
                    IEnumerable<DistritoDTO> distrito = _distritoService.Ubigeo(data.ubigeo);

                    var jsonData = new
                    {
                        RazonSocial = data.nombre_o_razon_social,
                        NumeroDocumento = data.ruc,
                        Direccion = data.direccion,
                        distrito.FirstOrDefault().ProvinciaDTO.DepartamentoDTO.PaisId,
                        distrito.FirstOrDefault().ProvinciaDTO.DepartamentoId,
                        PronvinciaId = distrito.FirstOrDefault().ProvinciaId,
                        distrito.FirstOrDefault().DistritoId,
                    };
                    jsonResultMessage.data = jsonData;
                    return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
                }
                jsonResultMessage.success = false;
                jsonResultMessage.data = respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
        }


    }
}