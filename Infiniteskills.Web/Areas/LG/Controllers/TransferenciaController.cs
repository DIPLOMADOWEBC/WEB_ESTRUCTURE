using Infiniteskills.Common;
using Infiniteskills.Helpers;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.LG.Controllers
{
    public class TransferenciaController :AppController
    {

        private IOrdenService _pedidoService;
        private IOrdenItemService _pedidoItemService;
        private IDocumentoComercialService _docComercialService;
        private IBienServicioService _productoService;
        private ITipoOperacionService _tipoOperacionService;
        private IMonedaService _monedaService;
        private IAlmacenService _almacenService;
        private ITipoMovimientoService _tipoMovimientoService;
        private IImpuestoService _impuestoService;
        private IProveedorService _proveedorService;
        public TransferenciaController(IOrdenService pedidoService, IOrdenItemService pedidoItemService,
            IBienServicioService productoService, IDocumentoComercialService docComercialService,
            ITipoOperacionService tipoOperacionService, IUsuarioService usuarioService,
            IMonedaService monedaService, ITipoMovimientoService tipoMovimientoService,
            IAlmacenService almacenService, IImpuestoService impuestoService,
            IProveedorService proveedorService)
            : base(usuarioService)
        {
            _pedidoService = pedidoService;
            _pedidoItemService = pedidoItemService;
            _docComercialService = docComercialService;
            _productoService = productoService;
            _tipoOperacionService = tipoOperacionService;
            _monedaService = monedaService;
            _almacenService = almacenService;
            _tipoMovimientoService = tipoMovimientoService;
            _impuestoService = impuestoService;
            _proveedorService = proveedorService;
        }

        public ActionResult Bandeja()
        {
            PopulateDropList();
            return PartialView();
        }

        [HttpPost]
        public ActionResult ListarBandeja(string codigo, string fechaPedido, string almacenId, string docComercialId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrEmpty(codigo))
                    parameters.Add("codigo", codigo);

                if (!string.IsNullOrEmpty(fechaPedido))
                    parameters.Add("fechaPedido", fechaPedido);

                if (!string.IsNullOrEmpty(almacenId))
                    parameters.Add("almacenId", almacenId);
                else
                    parameters.Add("almacenId", this.UsuarioAlmacenId());

                if (!string.IsNullOrEmpty(docComercialId))
                    parameters.Add("docComercialId", docComercialId);

            
                IEnumerable<OrdenDTO> pedidoDTOList = _pedidoService.ListarMovimiento(parameters);
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
                                   TipoMovimiento = f.TipoOperacionDTO.TipoMovimientoDTO.Nombre,
                                   TipoOperacion = f.TipoOperacionDTO.Nombre,
                                   FechaOrden = f.FechaOrden.ToString("dd/M/yyyy"),
                                   f.Cantidad,
                                   f.Impuesto,
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

                IEnumerable<OrdenItemDTO> pedidoItemDTOList = _pedidoItemService.ListarOrdenItem(parameters);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = pedidoItemDTOList.Count(),
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

                IEnumerable<OrdenItemDTO> pedidoItemDTOList = _pedidoItemService.ListarOrdenItem(parameters);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = pedidoItemDTOList.Count(),
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
                                   f.BienServicioDTO.UnidadMedidaDTO.Abreaviatura,
                                   f.Cantidad,
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
                                  // f.PrecioVenta
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
                        ViewBag.Title = "Nueva transferencia";
                        pedidoDTO.FechaOrden = DateTime.Now;
                        pedidoDTO.EditAction = editAction;
                        break;
                    case EditActionConstant.EDIT:
                        ViewBag.IsNew = false;
                        ViewBag.Title = "Editar transferencia";
                        pedidoDTO = await _pedidoService.BuscarMovimientoAsync(Convert.ToInt32(ordenId));
                        pedidoDTO.Direccion = pedidoDTO.ProveedorDTO.NombreDireccion;
                        pedidoDTO.EditAction = editAction;
                        ListarTipoOperacion(pedidoDTO.TipoOperacionDTO.TipoMovimientoId);
                        this.ListarCliente(Convert.ToInt32(pedidoDTO.ProveedorId));
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
                       // productoDTO.PrecioVenta
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
                , x => x.TipoMovimientoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


            ViewBag.TipoOperacionList = WebHelper.ToSelectListItem<TipoOperacionDTO>(SelectListFirstElementType.Select);

            List<MonedaDTO> monedaDTOList = _monedaService.SearchFor(parameters, string.Empty).Cast<MonedaDTO>().ToList();
            ViewBag.MonedaList = WebHelper.ToSelectListItem<MonedaDTO>(monedaDTOList
                , x => x.MonedaId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);



            List<ImpuestoDTO> impuestoDTOList = _impuestoService.SearchFor(parameters, string.Empty).Cast<ImpuestoDTO>().ToList();
            ViewBag.ImpuestoList = WebHelper.ToSelectListItem<ImpuestoDTO>(impuestoDTOList
                , x => x.ImpuestoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);
        }

        private void ListarTipoOperacion(int tipoMovimientoId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "tipoMovimientoId", tipoMovimientoId }
            };
            List<TipoOperacionDTO> tipoOperacionDTOList = _tipoOperacionService.SearchFor(parameters, string.Empty).Cast<TipoOperacionDTO>().ToList();
            ViewBag.TipoOperacionList = WebHelper.ToSelectListItem<TipoOperacionDTO>(tipoOperacionDTOList
            , x => x.TipoOperacionId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(JsonHeader collection)
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
                        await _pedidoService.InsertarTransferencia(pedidoDTO);
                        jsonResultMessage.message = "Inventario grabado satisfactoriamente.";
                        break;
                    case EditActionConstant.EDIT:
                        //_pedidoService.UpdateInventarioItem(pedidoDTO);
                        jsonResultMessage.message = "Inventario actualizado satisfactoriamente.";
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

        private OrdenDTO CargarPedidoDTO(JsonHeader collection)
        {

            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Header);
            
            OrdenDTO ordenDTO = new OrdenDTO();
            if (collection.EditAction == EditActionConstant.EDIT)
                ordenDTO.OrdenId = Convert.ToInt32(headerDictionary["OrdenId"]);

            ordenDTO.Codigo = headerDictionary["Codigo"].ToString();
            ordenDTO.FechaOrden = Convert.ToDateTime(headerDictionary["FechaOrden"]);
            ordenDTO.DocumentoComercialId = Convert.ToInt32(headerDictionary["DocumentoComercialId"]);
            ordenDTO.MonedaId = Convert.ToInt32(headerDictionary["MonedaId"]);
            ordenDTO.NumeroDocumento = headerDictionary["NumeroDocumento"].ToString();
            ordenDTO.ImpuestoId = Convert.ToInt32(headerDictionary["ImpuestoId"]);
            ordenDTO.AlmacenId = Convert.ToInt32(headerDictionary["AlmacenId"]);
            ordenDTO.AlmacenDestinoId = Convert.ToInt32(headerDictionary["AlmacenDestinoId"]);
            ordenDTO.ProveedorId = Convert.ToInt32(headerDictionary["ProveedorId"]);
            ordenDTO.TipoOperacionId = TipoOperacion(headerDictionary["TipoOperacionId"]);
            ordenDTO.Observacion = headerDictionary["Observacion"].ToString().Trim();
            ordenDTO.Operacion = OperacionConstant.SALIDA;
            ordenDTO.Anulado = EstadoConstante.ACTIVO;
            ordenDTO.PeriodoEmpresaId = this.GetPeriodoEmpresaId();
            ordenDTO.PersonalId = this.GetPersonalUsuarioId();
            ordenDTO.VehiculoId = null;
            ordenDTO.FormaPagoId = null;
            ordenDTO.Descuento = 0;
            return ordenDTO;
        }

        private List<OrdenItemDTO> ListPedidoItem(JsonHeader collection)
        {
            List<OrdenItemDTO> listPedido = new List<OrdenItemDTO>();
            Dictionary<string, string>[] rowDictionary = WebHelper.JsonToArrayDictionary(collection.Row);
            foreach (Dictionary<string, string> dictionary in rowDictionary)
            {
                var pedidoItemDTO = new OrdenItemDTO
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

        [HttpPost]
        public JsonResult Delete(int id)
        {
            return Json(string.Empty);
        }

        private int TipoOperacion(string codigo)
        {
            TipoOperacionDTO tipoOperacionDTO = _tipoOperacionService.GetTipoOperacion(codigo);
            return tipoOperacionDTO.TipoOperacionId;
        }

        [HttpPost]
        public JsonResult GetTipoOperacion(int tipoMovimientoId)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "tipoMovimientoId", tipoMovimientoId }
                };

                List<TipoOperacionDTO> tipoOperacionDTOList = _tipoOperacionService.SearchFor(parameters, string.Empty)
              .Cast<TipoOperacionDTO>().ToList();

                jsonResultMessage.data = WebHelper.ToSelectListItem<TipoOperacionDTO>(tipoOperacionDTOList
                    , x => x.TipoOperacionId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);
            }
            catch (Exception ex)
            {
                jsonResultMessage.message = ex.Message;
                jsonResultMessage.success = false;
            }
            return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> GetCliente(string query)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {

                IEnumerable<ProveedorDTO> clienteList = await _proveedorService.ListarProveedor(query);

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

                IEnumerable<ProveedorDTO> clienteList = await _proveedorService.BuscarPorRuc(numeroRuc);

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

                IEnumerable<ProveedorDTO> clienteList = await _proveedorService.ListarProveedor(id);
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
    }
}
