using Infiniteskills.Common;
using Infiniteskills.Helpers;
using Infiniteskills.Infra.Base;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.OP.Controllers
{

    public class PedidoController : AppController
    {
        private IOrdenService _pedidoService;
        private IOrdenItemService _pedidoItemService;
        private IFormaPagoService _formaPagoService;
        private IProveedorService _clienteService;
        private IDocumentoComercialService _docComercialService;
        private IBienServicioService _productoService;
        private ITipoOperacionService _tipoOperacionService;
        private ITipoMovimientoService _tipoMovimientoService;
        private IMonedaService _monedaService;
        private IServiceClient _serviceClient;
        private IProveedorService _proveedorService;
        private IAlmacenService _almacenService;
        private IImpuestoService _impuestoService;
        public PedidoController(IOrdenService pedidoService, IOrdenItemService pedidoItemService,
            IBienServicioService productoService, IFormaPagoService formaPagoService,
            IProveedorService clienteService, IDocumentoComercialService docComercialService,
            ITipoOperacionService tipoOperacionService, IUsuarioService usuarioService, IImpuestoService impuestoService,
            IMonedaService monedaService, IServiceClient serviceClient, ITipoMovimientoService tipoMovimientoService,
            IProveedorService proveedorService, IAlmacenService almacenService)
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
            _serviceClient = serviceClient;
            _proveedorService = proveedorService;
            _almacenService = almacenService;
            _impuestoService = impuestoService;
            _tipoMovimientoService = tipoMovimientoService;
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

                parameters.Add("operacion", LetraConstante.P);
                List<OrdenDTO> pedidoDTOList = _pedidoService.ListarPedido(parameters).ToList();
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = pedidoDTOList.Count,
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
                                   FormaPago = f.FormaPagoDTO== null ? string.Empty : f.FormaPagoDTO.Nombre,
                                   FechaOrden = f.FechaOrden.ToString("dd/M/yyyy"),
                                   Cliente = f.ProveedorDTO== null ? string.Empty : f.ProveedorDTO.RazonSocial,
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
                                   f.BienServicioDTO.Descripcion,
                                   f.Cantidad,
                                   f.ValorUnitario,
                                   //SubTotal = f.Cantidad * f.BienServicioDTO.PrecioVenta,

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
                ViewBag.IsNew = true;
                PopulateDropList();
                switch (editAction)
                {
                    case EditActionConstant.NEW:
                        ViewBag.Title = "Nuevo Pedido";
                        pedidoDTO.FechaOrden = DateTime.Now;
                        pedidoDTO.EditAction = editAction;
                        break;
                    case EditActionConstant.EDIT:
                        ViewBag.IsNew = false;
                        ViewBag.Title = "Editar Pedido";
                        pedidoDTO = await _pedidoService.BuscarPedidos(Convert.ToInt32(ordenId));
                        pedidoDTO.NumeroRuc = pedidoDTO.ProveedorDTO.NumeroDocumento;
                        pedidoDTO.Direccion = pedidoDTO.ProveedorDTO.NombreDireccion;
                        pedidoDTO.EditAction = editAction;
                        this.ListarCliente((int)pedidoDTO.ProveedorId);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return PartialView(pedidoDTO);
        }

        private void ListarCliente(int id)
        {
            IEnumerable<ProveedorDTO> proveedorList = _proveedorService.BuscarPorCodigo(id);
            ViewBag.ListarCliente = WebHelper.ToSelectListItem<ProveedorDTO>(proveedorList
                , x => x.ProveedorId.ToString(), x => x.RazonSocial, SelectListFirstElementType.Select, string.Empty);
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
                        productoDTO.BienServicioId,
                        Codigo = productoDTO.Codigo.Trim(),
                        Descripcion = productoDTO.Descripcion.Trim(),
                        //productoDTO.PrecioVenta
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


            List<TipoMovimientoDTO> tipoMovimientoDTOList = _tipoMovimientoService.SearchFor(parameters, string.Empty)
           .Cast<TipoMovimientoDTO>().ToList();

            ViewBag.TipoMovimimentoList = WebHelper.ToSelectListItem<TipoMovimientoDTO>(tipoMovimientoDTOList
            , x => x.Codigo.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            List<TipoOperacionDTO> tipoOperacionDTOList = _tipoOperacionService.SearchFor(parameters, string.Empty)
          .Cast<TipoOperacionDTO>().ToList();

            ViewBag.TipoOperacionList = WebHelper.ToSelectListItem<TipoOperacionDTO>(tipoOperacionDTOList
                , x => x.TipoOperacionId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            List<MonedaDTO> monedaDTOList = _monedaService.SearchFor(parameters, string.Empty).Cast<MonedaDTO>().ToList();
            ViewBag.MonedaList = WebHelper.ToSelectListItem<MonedaDTO>(monedaDTOList
                , x => x.MonedaId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


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
                pedidoDTO = CargarPedidoDTO(collection);
                pedidoDTO.OrderItemList = ListPedidoItem(collection);
                switch (collection.EditAction)
                {
                    case EditActionConstant.NEW:
                        _pedidoService.InsertPedidoItem(pedidoDTO);
                        jsonResultMessage.message = "Pedido grabado satisfactoriamente.";
                        break;
                    case EditActionConstant.EDIT:
                        jsonResultMessage.message = "Pedido actualizado satisfactoriamente.";
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


        private List<OrdenItemDTO> ListPedidoItem(JsonHeader collection)
        {
            List<OrdenItemDTO> listPedido = new List<OrdenItemDTO>();
            Dictionary<string, string>[] rowDictionary = WebHelper.JsonToArrayDictionary(collection.Row);
            foreach (Dictionary<string, string> dictionary in rowDictionary)
            {
                OrdenItemDTO pedidoItemDTO = new OrdenItemDTO
                {
                    OrdenItemId = Convert.ToInt32(dictionary["OrdenItemId"]),
                    OrdenId = Convert.ToInt32(dictionary["OrdenId"]),
                    BienServicioId = Convert.ToInt32(dictionary["BienServicioId"]),
                    Cantidad = Convert.ToDecimal(dictionary["Cantidad"]),
                    ValorUnitario = Convert.ToDecimal(dictionary["ValorUnitario"]),
                    Estado = EstadoConstante.ACTIVO
                };
                listPedido.Add(pedidoItemDTO);
            }

            return listPedido;
        }

        private OrdenDTO CargarPedidoDTO(JsonHeader collection)
        {
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Header);

            OrdenDTO ordenDTO = new OrdenDTO();
            if (collection.EditAction == EditActionConstant.EDIT)
                ordenDTO.OrdenId = Convert.ToInt32(headerDictionary["OrdenId"]);

            ordenDTO.Codigo = headerDictionary["Codigo"].ToString();
            ordenDTO.ProveedorId = Convert.ToInt32(headerDictionary["ProveedorId"]);
            ordenDTO.AlmacenId = Convert.ToInt32(headerDictionary["AlmacenId"]);
            ordenDTO.FechaOrden = Convert.ToDateTime(headerDictionary["FechaOrden"]);
            ordenDTO.DocumentoComercialId = Convert.ToInt32(headerDictionary["DocumentoComercialId"]);
            ordenDTO.TipoOperacionId = Convert.ToInt32(headerDictionary["TipoOperacionId"]);
            ordenDTO.MonedaId = Convert.ToInt32(headerDictionary["MonedaId"]);
            ordenDTO.FormaPagoId = Convert.ToInt32(headerDictionary["FormaPagoId"]);
            ordenDTO.Observacion = headerDictionary["Observacion"].ToString().Trim();
            ordenDTO.PeriodoEmpresaId = 1;
            ordenDTO.PersonalId = 1;
            ordenDTO.Anulado = EstadoConstante.ACTIVO;
            ordenDTO.Operacion = LetraConstante.P;
            ordenDTO.NumeroDocumento = string.Empty;
            ordenDTO.ImpuestoId = null;
            ordenDTO.VehiculoId = null;
            ordenDTO.TipoPrecioId = null;
            ordenDTO.Descuento = 0;
            ordenDTO.TotalExonerado = 0;
            ordenDTO.TotalInafecto = 0;

            return ordenDTO;
        }

        private int TipoOperacion(string codigo)
        {
            TipoOperacionDTO tipoOperacionDTO = _tipoOperacionService.GetTipoOperacion(codigo);
            return tipoOperacionDTO.TipoOperacionId;
        }



        [HttpPost]
        public JsonResult Delete(int id)
        {
            return Json(string.Empty);
        }


        [HttpPost]
        public JsonResult GetTipoOperacion(string codigo)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "codigo", codigo }
                };

                List<TipoOperacionDTO> tipoOperacionDTOList = _tipoOperacionService.SearchFor(parameters, string.Empty)
                    .Cast<TipoOperacionDTO>().ToList();

                jsonResultMessage.data = WebHelper.ToSelectListItem<TipoOperacionDTO>(tipoOperacionDTOList
                    , x => x.Codigo.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);
            }
            catch (Exception ex)
            {
                jsonResultMessage.message = ex.Message;
                jsonResultMessage.success = false;
            }
            return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Factura()
        {
            IEnumerable<OrdenItemDTO> ordenItemDTOList = new List<OrdenItemDTO>();

            ordenItemDTOList = _pedidoItemService.ListarFactura(4093);
      
    
            return View();
        }

      
    }
}