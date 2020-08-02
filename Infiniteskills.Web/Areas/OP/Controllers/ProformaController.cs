using Infiniteskills.Common;
using Infiniteskills.Helpers;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.OP.Controllers
{
    public class ProformaController : AppController
    {
        private IOrdenService _pedidoService;
        private IOrdenItemService _pedidoItemService;
        private IFormaPagoService _formaPagoService;
        private IProveedorService _clienteService;
        private IDocumentoComercialService _docComercialService;
        private IBienServicioService _productoService;
        private ITipoOperacionService _tipoOperacionService;
        private IMonedaService _monedaService;
        private IProveedorService _proveedorService;
        private IAlmacenService _almacenService;
        private ITipoPrecioService _tipoPrecioService;
        private IImpuestoService _impuestoService;
        public ProformaController(IOrdenService pedidoService, IOrdenItemService pedidoItemService,
            IBienServicioService productoService, IFormaPagoService formaPagoService,
            IProveedorService clienteService, IDocumentoComercialService docComercialService,
            ITipoOperacionService tipoOperacionService, IUsuarioService usuarioService, IImpuestoService impuestoService,
            IMonedaService monedaService, IProveedorService proveedorService, ITipoPrecioService tipoPrecioService,
            IAlmacenService almacenService)
            : base(usuarioService)
        {
            _pedidoService = pedidoService;
            _pedidoItemService = pedidoItemService;
            _formaPagoService = formaPagoService;
            _clienteService = clienteService;
            _docComercialService = docComercialService;
            _productoService = productoService;
            _tipoOperacionService = tipoOperacionService;
            _monedaService = monedaService;
            _proveedorService = proveedorService;
            _almacenService = almacenService;
            _tipoPrecioService = tipoPrecioService;
            _impuestoService = impuestoService;
        }

        public ActionResult Bandeja()
        {
            PopulateDropList();
            return PartialView();
        }

        [HttpPost]
        public ActionResult ListarBandeja(string codigo, string fechaPedido, string razonSocial, string docComercialId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrEmpty(codigo))
                    parameters.Add("codigo", codigo);

                if (!string.IsNullOrEmpty(fechaPedido))
                    parameters.Add("fechaPedido", fechaPedido);

                if (!string.IsNullOrEmpty(razonSocial))
                    parameters.Add("razonSocial", razonSocial);

                if (!string.IsNullOrEmpty(docComercialId))
                    parameters.Add("docComercialId", docComercialId);


                IEnumerable<OrdenDTO> pedidoDTOList = _pedidoService.ListarCotizacion(parameters);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = pedidoDTOList.Count(),
                    rows = from f in pedidoDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   f.OrdenId,
                                   f.Codigo,
                                   Documento = f.DocumentoComercialDTO.Nombre,
                                   TipoOperacion = f.TipoOperacionDTO.Nombre,
                                   FormaPago = f.FormaPagoDTO == null ? string.Empty : f.FormaPagoDTO.Nombre,
                                   FechaOrden = f.FechaOrden.ToString("dd/M/yyyy"),
                                   Cliente = f.ProveedorDTO == null ? string.Empty : f.ProveedorDTO.RazonSocial,
                                   f.Cantidad,
                                   f.TotalPedido
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
        public ActionResult ListarDetalle(string ordenId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrEmpty(ordenId))
                    parameters.Add("ordenId", ordenId);

                List<OrdenItemDTO> pedidoItemDTOList = _pedidoItemService.SearchFor(parameters, string.Empty).Cast<OrdenItemDTO>().ToList();
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = pedidoItemDTOList.Count,
                    rows = from f in pedidoItemDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   f.OrdenItemId,
                                   f.BienServicioDTO.Codigo,
                                   f.BienServicioDTO.Descripcion,
                                   CantidadProducto = f.Cantidad,
                                   f.ValorUnitario,
                                   SubTotal = f.Cantidad * f.ValorUnitario
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
        public ActionResult ListarItem(string ordenId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrEmpty(ordenId))
                    parameters.Add("ordenId", ordenId);

                List<OrdenItemDTO> pedidoItemDTOList = _pedidoItemService.SearchFor(parameters, string.Empty).Cast<OrdenItemDTO>().ToList();
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = pedidoItemDTOList.Count,
                    rows = from f in pedidoItemDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   f.OrdenItemId,
                                   f.OrdenId,
                                   f.BienServicioDTO.Codigo,
                                   f.BienServicioId,
                                   BienServicio = f.BienServicioDTO.Descripcion,
                                   f.Cantidad,
                                   f.PesoNeto,
                                   f.PesoBruto,
                                   f.ValorUnitario,
                                   SubTotal = f.Cantidad * f.ValorUnitario
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
        public ActionResult ListarProducto(string codigo, string marca, string descripcion)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrEmpty(codigo))
                    parameters.Add("codigo", codigo);

                if (!string.IsNullOrEmpty(marca))
                    parameters.Add("marca", marca);

                if (!string.IsNullOrEmpty(descripcion))
                    parameters.Add("descripcion", descripcion);

                List<BienServicioDTO> productoDTOList = _productoService.SearchFor(parameters, string.Empty).Cast<BienServicioDTO>().ToList();
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = productoDTOList.Count,
                    rows = from f in productoDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   f.BienServicioId,
                                   f.Codigo,
                                   BienServicio = f.Descripcion,
                                   Marca = f.MarcaDTO.Nombre,
                                   UnidadMedida = f.UnidadMedidaDTO.Abreaviatura,
                                  // f.PrecioCompra,
                                   f.PrecioUnitario,
                                 //  f.PrecioVenta
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
        public async Task<ActionResult> Create(string editAction, string ordenId)
        {
            OrdenDTO pedidoDTO = new OrdenDTO();
            try
            {
                PopulateDropList();
                switch (editAction)
                {
                    case EditActionConstant.NEW:
                        ViewBag.Title = "Nueva Cotizacion";
                        pedidoDTO.FechaOrden = DateTime.Now;
                        pedidoDTO.EditAction = editAction;
                        break;
                    case EditActionConstant.EDIT:
                        ViewBag.Title = "Editar Cotizacion";
                        pedidoDTO = await _pedidoService.BuscarPedidos(Convert.ToInt32(ordenId));
                        pedidoDTO.NumeroRuc = pedidoDTO.ProveedorDTO.NumeroDocumento;
                        pedidoDTO.Direccion = pedidoDTO.ProveedorDTO.NombreDireccion;
                        pedidoDTO.EditAction = editAction;
                        this.listarCliente((int)pedidoDTO.ProveedorId);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return PartialView(pedidoDTO);
        }

        private void listarCliente(int id)
        {
            IEnumerable<ProveedorDTO> proveedorList = _proveedorService.BuscarPorCodigo(id);
            ViewBag.ListarCliente = WebHelper.ToSelectListItem<ProveedorDTO>(proveedorList
                , x => x.ProveedorId.ToString(), x => x.RazonSocial, SelectListFirstElementType.Select, string.Empty);
        }

        [HttpGet]
        public ActionResult ClienteEdit()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult ProductoEdit()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<JsonResult> GetCliente(string query)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {

                IEnumerable<ProveedorDTO> clienteList = await _clienteService.ListarProveedor(query);

                var jsonData = from f in clienteList
                               select new
                               {
                                   f.ProveedorId,
                                   f.RazonSocial
                               };

                jsonResultMessage.data = jsonData;
                return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        public async Task<JsonResult> BuscarPorRuc(string numeroRuc)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {

                IEnumerable<ProveedorDTO> clienteList = await _clienteService.BuscarPorRuc(numeroRuc);

                var jsonData = from f in clienteList
                               select new
                               {
                                   f.ProveedorId,
                                   f.NumeroDocumento,
                                   f.RazonSocial,
                                   f.NombreDireccion
                               };

                jsonResultMessage.data = jsonData.FirstOrDefault();
                return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<JsonResult> BuscarPorId(int id)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {

                IEnumerable<ProveedorDTO> clienteList = await _clienteService.ListarProveedor(id);
                var jsonData = from f in clienteList
                               select new
                               {
                                   f.ProveedorId,
                                   f.NumeroDocumento,
                                   f.RazonSocial,
                                   f.NombreDireccion
                               };

                jsonResultMessage.data = jsonData.FirstOrDefault();
                return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public JsonResult GetProducto(string codigo)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrEmpty(codigo))
                    parameters.Add("codigo", codigo);

                BienServicioDTO productoDTO = _productoService.SearchFor(parameters);
                if (productoDTO != null)
                {
                    var data = new
                    {
                        BienServicioId = productoDTO.BienServicioId,
                        Codigo = productoDTO.Codigo.Trim(),
                        Descripcion = productoDTO.Descripcion.Trim(),
                        //PrecioVenta = productoDTO.PrecioVenta
                    };

                    jsonResultMessage.data = data;
                }
                else
                {
                    jsonResultMessage.success = false;
                    jsonResultMessage.message = "El producto que ingreso no existe";
                }
                return Json(jsonResultMessage);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void PopulateDropList()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            List<FormaPagoDTO> formaPagoDTOList = _formaPagoService.SearchFor(parameters, string.Empty).Cast<FormaPagoDTO>().ToList();
            ViewBag.FormaPago = WebHelper.ToSelectListItem<FormaPagoDTO>(formaPagoDTOList
                , x => x.FormaPagoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            List<DocumentoComercialDTO> documentoComercialDTOList = _docComercialService.SearchFor(parameters, string.Empty)
                .Cast<DocumentoComercialDTO>().ToList();
            ViewBag.DocComerciaList = WebHelper.ToSelectListItem<DocumentoComercialDTO>(documentoComercialDTOList
                , x => x.DocumentoComercialId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


            List<AlmacenDTO> almacenDTOList = _almacenService.SearchFor(parameters, string.Empty).Cast<AlmacenDTO>().ToList();

            ViewBag.almacenList = WebHelper.ToSelectListItem<AlmacenDTO>(almacenDTOList
                , x => x.AlmacenId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


            List<TipoOperacionDTO> tipoOperacionDTOList = _tipoOperacionService.SearchFor(parameters, string.Empty).Cast<TipoOperacionDTO>().ToList();
            ViewBag.TipoOperacionList = WebHelper.ToSelectListItem<TipoOperacionDTO>(tipoOperacionDTOList
                , x => x.Codigo.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            List<MonedaDTO> monedaDTOList = _monedaService.SearchFor(parameters, string.Empty).Cast<MonedaDTO>().ToList();
            ViewBag.MonedaList = WebHelper.ToSelectListItem<MonedaDTO>(monedaDTOList
                , x => x.MonedaId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


            List<TipoPrecioDTO> tipoPrecioDTOList = _tipoPrecioService.SearchFor(parameters, string.Empty).Cast<TipoPrecioDTO>().ToList();
            ViewBag.TipoPrecioList = WebHelper.ToSelectListItem<TipoPrecioDTO>(tipoPrecioDTOList
                , x => x.TipoPrecioId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


            List<ImpuestoDTO> impuestoDTOList = _impuestoService.SearchFor(parameters, string.Empty).Cast<ImpuestoDTO>().ToList();
            ViewBag.ImpuestoList = WebHelper.ToSelectListItem<ImpuestoDTO>(impuestoDTOList
                , x => x.ImpuestoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JsonHeader collection)
        {

            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            OrdenDTO pedidoDTO = new OrdenDTO();
            try
            {
                pedidoDTO = cargarPedidoDTO(collection);
                pedidoDTO.OrderItemList = listPedidoItem(collection);
                switch (collection.EditAction)
                {
                    case EditActionConstant.NEW:
                        _pedidoService.InsertIventarioItem(pedidoDTO);
                        jsonResultMessage.message = "Iventario grabado satisfactoriamente.";
                        break;
                    case EditActionConstant.EDIT:
                        _pedidoService.UpdateInventarioItem(pedidoDTO);
                        jsonResultMessage.message = "Iventario actualizado satisfactoriamente.";
                        break;
                }


            }
            catch (Exception ex)
            {
                jsonResultMessage.success = false;
                jsonResultMessage.message = ex.Message;
            }
            return Json(jsonResultMessage);
        }

        private OrdenDTO cargarPedidoDTO(JsonHeader collection)
        {
            OrdenDTO pedidoDTO = new OrdenDTO();
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Header);
            Dictionary<string, string> detailDictionary = WebHelper.JsonToDictionary(collection.Detail);
            if (collection.EditAction == EditActionConstant.EDIT)
                pedidoDTO.OrdenId = Convert.ToInt32(headerDictionary["OrdenId"]);

            pedidoDTO.Codigo = headerDictionary["Codigo"].ToString();
            pedidoDTO.AlmacenId = Convert.ToInt32(headerDictionary["AlmacenId"]);
            pedidoDTO.FechaOrden = Convert.ToDateTime(headerDictionary["FechaOrden"]);
            pedidoDTO.PeriodoEmpresaId = this.GetPeriodoEmpresaId();
            pedidoDTO.DocumentoComercialId = Convert.ToInt32(headerDictionary["DocumentoComercialId"]);
            pedidoDTO.FormaPagoId = Convert.ToInt32(headerDictionary["FormaPagoId"]);
            pedidoDTO.ProveedorId = Convert.ToInt32(headerDictionary["ProveedorId"]);
            pedidoDTO.TipoOperacionId = tipoOperacion(headerDictionary["TipoOperacionId"]);
            pedidoDTO.MonedaId = Convert.ToInt32(headerDictionary["MonedaId"]);
            pedidoDTO.PersonalId = this.GetPersonalUsuarioId();
            pedidoDTO.Cantidad = 0;
            pedidoDTO.Observacion = headerDictionary["Observacion"].ToString().Trim();
            pedidoDTO.Descuento = Convert.ToDecimal(detailDictionary["Descuento"]);
            pedidoDTO.Anulado = EstadoConstante.ACTIVO;

            return pedidoDTO;
        }

        private List<OrdenItemDTO> listPedidoItem(JsonHeader collection)
        {
            List<OrdenItemDTO> listPedido = new List<OrdenItemDTO>();
            Dictionary<string, string>[] rowDictionary = WebHelper.JsonToArrayDictionary(collection.Row);
            foreach (Dictionary<string, string> dictionary in rowDictionary)
            {
                OrdenItemDTO pedidoItemDTO = new OrdenItemDTO();
                pedidoItemDTO.OrdenItemId = Convert.ToInt32(dictionary["OrdenItemId"]);
                pedidoItemDTO.OrdenId = Convert.ToInt32(dictionary["OrdenId"]);
                pedidoItemDTO.BienServicioId = Convert.ToInt32(dictionary["BienServicioId"]);
                pedidoItemDTO.Cantidad = Convert.ToDecimal(dictionary["Cantidad"]);
                pedidoItemDTO.PesoNeto = Convert.ToDecimal(dictionary["PesoNeto"]);
                pedidoItemDTO.PesoBruto = Convert.ToDecimal(dictionary["PesoBruto"]);
                pedidoItemDTO.ValorUnitario = Convert.ToDecimal(dictionary["ValorUnitario"]);
                pedidoItemDTO.Estado = EstadoConstante.ACTIVO;
                listPedido.Add(pedidoItemDTO);
            }

            return listPedido;
        }

        [HttpPost]
        public ActionResult GrabarDatos(JsonHeader collection)
        {
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Header);
            Dictionary<string, string> detailDictionary = WebHelper.JsonToDictionary(collection.Detail);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            OrdenItemDTO pedidoItemDTO = new OrdenItemDTO();
            try
            {
                pedidoItemDTO.OrdenId = Convert.ToInt32(headerDictionary["OrdenId"]);
                pedidoItemDTO.BienServicioId = Convert.ToInt32(detailDictionary["BienServicioId"]);
                pedidoItemDTO.Cantidad = Convert.ToDecimal(detailDictionary["CantidadCesta"]);
                pedidoItemDTO.ValorUnitario = 0;
                pedidoItemDTO.Estado = EstadoConstante.ACTIVO;
                pedidoItemDTO.UsuarioCreacionId = 1;
                pedidoItemDTO.FechaCreacion = DateTime.Now;
                pedidoItemDTO.UsuarioModificacionId = null;
                pedidoItemDTO.FechaModificacion = null;
                _pedidoItemService.Create(pedidoItemDTO);
                jsonResultMessage.message = "Proveedor grabado satisfactoriamente.";

            }
            catch (Exception ex)
            {
                jsonResultMessage.success = false;
                jsonResultMessage.message = ex.Message;
            }
            return Json(jsonResultMessage);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            return Json(string.Empty);
        }

        private int tipoOperacion(string codigo)
        {
            TipoOperacionDTO tipoOperacionDTO = _tipoOperacionService.GetTipoOperacion(codigo);
            return tipoOperacionDTO.TipoOperacionId;
        }
    }
}
