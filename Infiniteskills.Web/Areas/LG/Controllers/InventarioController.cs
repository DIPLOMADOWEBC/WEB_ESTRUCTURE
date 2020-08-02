using Infiniteskills.Common;
using Infiniteskills.Helpers;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.LG.Controllers
{
    public class InventarioController : AppController
    {
        private IOrdenService _pedidoService;
        private IOrdenItemService _pedidoItemService;
        private IDocumentoComercialService _docComercialService;
        private IBienServicioService _productoService;
        private ITipoOperacionService _tipoOperacionService;
        private IMonedaService _monedaService;
        private IAlmacenService _almacenService;
        private ITipoMovimientoService _tipoMovimientoService;
        public InventarioController(IOrdenService pedidoService, IOrdenItemService pedidoItemService,
            IBienServicioService productoService, IDocumentoComercialService docComercialService,
            ITipoOperacionService tipoOperacionService, IUsuarioService usuarioService,
            IMonedaService monedaService, ITipoMovimientoService tipoMovimientoService,
            IAlmacenService almacenService)
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


                parameters.Add("operacion", LetraConstante.I);

                List<OrdenDTO> pedidoDTOList = _pedidoService.ListarInventario(parameters);
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
                                   TipoMovimiento = f.TipoOperacionDTO?.TipoMovimientoDTO?.Nombre,
                                   Documento = f.DocumentoComercialDTO?.Nombre,
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
                                //   f.PrecioVenta
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
                        ViewBag.Title = "Nueva inventario inicial";
                        pedidoDTO.FechaOrden = DateTime.Now;
                        pedidoDTO.EditAction = editAction;
                        pedidoDTO.AlmacenId = 1;
                        break;
                    case EditActionConstant.EDIT:
                        ViewBag.IsNew = false;
                        ViewBag.Title = "Editar inventario inicial";
                        pedidoDTO = await _pedidoService.BuscarInventarioInicial(Convert.ToInt32(ordenId));
                        pedidoDTO.EditAction = editAction;
                        ListarTipoOperacion(pedidoDTO.TipoOperacionDTO.TipoMovimientoId);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return PartialView(pedidoDTO);
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
                        await _pedidoService.InsertIventarioItem(pedidoDTO);
                        jsonResultMessage.message = "Inventario grabado satisfactoriamente.";
                        break;
                    case EditActionConstant.EDIT:
                        _pedidoService.UpdateInventarioItem(pedidoDTO);
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
            OrdenDTO pedidoDTO = new OrdenDTO();
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Header);
            Dictionary<string, string> detailDictionary = WebHelper.JsonToDictionary(collection.Detail);
            if (collection.EditAction == EditActionConstant.EDIT)
                pedidoDTO.OrdenId = Convert.ToInt32(headerDictionary["OrdenId"]);

            pedidoDTO.Codigo = headerDictionary["Codigo"].ToString();
            pedidoDTO.Operacion = OperacionConstant.INGRESO;
            pedidoDTO.AlmacenId = Convert.ToInt32(headerDictionary["AlmacenId"]);
            pedidoDTO.FechaOrden = Convert.ToDateTime(headerDictionary["FechaOrden"]);
            pedidoDTO.DocumentoComercialId = Convert.ToInt32(headerDictionary["DocumentoComercialId"]);
            pedidoDTO.TipoOperacionId = Convert.ToInt32(headerDictionary["TipoOperacionId"]);
            pedidoDTO.MonedaId = Convert.ToInt32(headerDictionary["MonedaId"]);
            pedidoDTO.PersonalId = 1;
            pedidoDTO.PeriodoEmpresaId = 1;
            pedidoDTO.Observacion = headerDictionary["Observacion"].ToString().Trim();
            pedidoDTO.NumeroDocumento = string.Empty;
            pedidoDTO.VehiculoId = null;
            pedidoDTO.FormaPagoId = null;
            pedidoDTO.ProveedorId = null;
            pedidoDTO.Anulado = EstadoConstante.ACTIVO;
            pedidoDTO.Descuento = 0;

            return pedidoDTO;
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
                    PesoNeto = Convert.ToDecimal(dictionary["PesoNeto"]),
                    PesoBruto = Convert.ToDecimal(dictionary["PesoBruto"]),
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
        public ActionResult ReadExcelFile(HttpPostedFileBase fileBase)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                if (fileBase != null && fileBase.ContentLength > 0)
                {
                    Stream stream = fileBase.InputStream;
                    var fileName = Path.GetFileName(fileBase.FileName);
                    //IWorkbook workbook = null;
                    ISheet sheet;
                    if (fileBase.FileName.EndsWith(".xls"))
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(fileBase.InputStream); //HSSWorkBook object will read the Excel 97-2000 formats  
                    }
                    else if (fileBase.FileName.EndsWith(".xlsx"))
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(fileBase.InputStream);

                        sheet = hssfwb.GetSheetAt(0); //get first Exce

                        IEnumerator rows = sheet.GetRowEnumerator();

                        IRow headerRow = sheet.GetRow(0);
                        int cellCount = headerRow.LastCellNum;


                        for (int j = 0; j < cellCount; j++)
                        {
                            ICell cell = headerRow.GetCell(j);
                        }

                        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row == null)
                                break;
                            for (int j = row.FirstCellNum; j < cellCount; j++)
                            {

                            }

                        }
                    }
                    else
                    {

                    }
                }
                return Json(jsonResultMessage);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }

        private void xlsxToDT()
        {
             XSSFWorkbook hssfworkbook= new XSSFWorkbook();
            DataSet dataSet1 = new DataSet();

            using (FileStream file = new FileStream(@"E:\Docs\HoursWidget_RTM.xlsx", FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new XSSFWorkbook(file);
            }

            DataTable dt = new DataTable();
            ISheet sheet = hssfworkbook.GetSheetAt(1);
            IRow headerRow = sheet.GetRow(0);
            IEnumerator rows = sheet.GetRowEnumerator();

            int colCount = headerRow.LastCellNum;
            int rowCount = sheet.LastRowNum;

            for (int c = 0; c < colCount; c++)
            {

                dt.Columns.Add(headerRow.GetCell(c).ToString());
            }

            bool skipReadingHeaderRow = rows.MoveNext();
            while (rows.MoveNext())
            {
                IRow row = (XSSFRow)rows.Current;
                DataRow dr = dt.NewRow();

                for (int i = 0; i < colCount; i++)
                {
                    ICell cell = row.GetCell(i);

                    if (cell != null)
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }

            hssfworkbook = null;
            sheet = null;
            dataSet1.Tables.Add(dt);
        }

        static void DisplayData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
                }
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
