using Infiniteskills.Common;
using Infiniteskills.Helpers;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Infiniteskills.Web.Areas.LG.Controllers
{
    public class BienServicioController : Controller
    {
        private IBienServicioService _productoService;
        private ICategoriaService _categoriaService;
        private IProveedorService _proveedorService;
        private IUnidadMedidaService _unidadMedidaService;
        private ITipoExistenciaService _tipoExistenciaService;
        private IMarcaService _marcaService;
        private IMonedaService _monedaService;
        private ITipoBienService _tipoBienService;
        private ILineaService _lineaService;
        public BienServicioController(IBienServicioService productoService,
            ICategoriaService categoriaService, IProveedorService proveedorService,
            IUnidadMedidaService unidadMedidaService, ITipoExistenciaService tipoExistenciaService,
            IMarcaService marcaService, IMonedaService monedaService, ITipoBienService tipoBienService,
            ILineaService lineaService)
        {
            _productoService = productoService;
            _categoriaService = categoriaService;
            _proveedorService = proveedorService;
            _unidadMedidaService = unidadMedidaService;
            _tipoExistenciaService = tipoExistenciaService;
            _marcaService = marcaService;
            _monedaService = monedaService;
            _tipoBienService = tipoBienService;
            _lineaService = lineaService;
        }
        // GET: Producto
        public ActionResult Bandeja()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            List<CategoriaDTO> categoriaList = _categoriaService.SearchFor(parameters, string.Empty);
            ViewBag.ListCategoria = WebHelper.ToSelectListItem<CategoriaDTO>(categoriaList, x => x.CategoriaId.ToString(),
                x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            return PartialView();
        }

        [HttpPost]
        public ActionResult ListarBandeja(string descripcion, string marca,
            string proveedor, string categoriaId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrEmpty(descripcion))
                    parameters.Add("descripcion", descripcion);

                if (!string.IsNullOrEmpty(marca))
                    parameters.Add("marca", marca);

                if (!string.IsNullOrEmpty(proveedor))
                    parameters.Add("proveedor", proveedor);

                if (!string.IsNullOrEmpty(categoriaId))
                    parameters.Add("categoriaId", categoriaId);

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
                                   Categoria = f.CategoriaDTO.Nombre,
                                   f.Descripcion,
                                   Marca = f.MarcaDTO.Nombre,
                                   UnidadMedida = f.UnidadMedidaDTO.Abreaviatura,
                                   f.StockMinimo,
                                   f.StockMaximo,
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

        [HttpPost]
        public ActionResult ListarProveedor(string numeroRuc, string razonSocial)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrEmpty(numeroRuc))
                    parameters.Add("numeroRuc", numeroRuc);

                if (!string.IsNullOrEmpty(razonSocial))
                    parameters.Add("razonSocial", razonSocial);

                List<ProveedorDTO> proveedorDTOList = _proveedorService.SearchFor(parameters, string.Empty).Cast<ProveedorDTO>().ToList();
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = proveedorDTOList.Count,
                    rows = from f in proveedorDTOList.AsEnumerable()
                           orderby f.FechaCreacion descending
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   f.ProveedorId,
                                   f.RazonSocial,
                                   f.Telefono,
                                   f.Celular,
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

        // GET: Producto/Create
        [HttpGet]
        public async Task<ActionResult> Create(string editAction, string bienServicioId)
        {
            BienServicioDTO productoDTO = new BienServicioDTO();
            try
            {
                switch (editAction)
                {
                    case EditActionConstant.NEW:
                        productoDTO.EditAction = editAction;
                        ViewBag.Title = "Nuevo Bienes Servicio";
                        break;
                    case EditActionConstant.EDIT:
                        ViewBag.Title = "Editar Bienes Servicio";
                        productoDTO = _productoService.GetById(Convert.ToInt32(bienServicioId));
                        productoDTO.EditAction = editAction;
                        if (productoDTO.ProveedorId != null)
                            await this.ListarProveedor(Convert.ToInt32(productoDTO.ProveedorId));
                        break;
                }
                ListDropList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return PartialView(productoDTO);
        }


        private async Task ListarProveedor(int id)
        {
            IEnumerable<ProveedorDTO> proveedorList = await _proveedorService.ListarProveedor(id);
            ViewBag.ProveedorList = WebHelper.ToSelectListItem<ProveedorDTO>(proveedorList
                , x => x.ProveedorId.ToString(), x => x.RazonSocial, SelectListFirstElementType.Select, string.Empty);
        }

        public ActionResult ModalEdit()
        {
            return PartialView();
        }
        private void ListDropList()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            List<CategoriaDTO> categoriaList = _categoriaService.SearchFor(parameters, string.Empty);
            ViewBag.ListCategoria = WebHelper.ToSelectListItem<CategoriaDTO>(categoriaList, x => x.CategoriaId.ToString(),
                x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


            List<UnidadMedidaDTO> unidadMedidaDTOList = _unidadMedidaService.SearchFor(parameters, string.Empty);
            ViewBag.ListUnidadMedida = WebHelper.ToSelectListItem<UnidadMedidaDTO>(unidadMedidaDTOList, x => x.UnidadMedidaId.ToString(),
                x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            List<TipoExistenciaDTO> tipoProductoDTOList = _tipoExistenciaService.SearchFor(parameters, string.Empty);
            ViewBag.ListExistencia = WebHelper.ToSelectListItem<TipoExistenciaDTO>(tipoProductoDTOList, x => x.TipoExistenciaId.ToString(),
                x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            List<MarcaDTO> marcaDTOList = _marcaService.SearchFor(parameters, string.Empty);
            ViewBag.MarcaList = WebHelper.ToSelectListItem<MarcaDTO>(marcaDTOList, x => x.MarcaId.ToString(),
                x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            List<MonedaDTO> monedaDTOList = _monedaService.SearchFor(parameters, string.Empty);
            ViewBag.MonedaList = WebHelper.ToSelectListItem<MonedaDTO>(monedaDTOList, x => x.MonedaId.ToString(),
                x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


            List<TipoBienDTO> tipoBienDTOList = _tipoBienService.SearchFor(parameters, string.Empty);
            ViewBag.TipoBienList = WebHelper.ToSelectListItem<TipoBienDTO>(tipoBienDTOList, x => x.TipoBienId.ToString(),
                x => x.Nombre, SelectListFirstElementType.Select, string.Empty);

            List<LineaDTO> lineaDTOList = _lineaService.SearchFor(parameters, string.Empty);
            ViewBag.LineaList = WebHelper.ToSelectListItem<LineaDTO>(lineaDTOList, x => x.LineaId.ToString(),
                x => x.Nombre, SelectListFirstElementType.Select, string.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JsonHeader collection)
        {

            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            BienServicioDTO productoDTO = new BienServicioDTO();
            try
            {
                productoDTO = CargarProductoDTO(collection);
                switch (collection.EditAction)
                {
                    case EditActionConstant.NEW:
                        _productoService.Create(productoDTO);
                        jsonResultMessage.message = "Grabado satisfactoriamente.";
                        break;
                    case EditActionConstant.EDIT:
                        _productoService.Update(productoDTO);
                        jsonResultMessage.message = "Actualizado satisfactoriamente.";
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

        private BienServicioDTO CargarProductoDTO(JsonHeader collection)
        {
            Dictionary<string, string> editDictionary = WebHelper.JsonToDictionary(collection.Header);

            BienServicioDTO productoDTO = new BienServicioDTO();
            if (collection.EditAction == EditActionConstant.EDIT)
                productoDTO.BienServicioId = Convert.ToInt32(editDictionary["BienServicioId"]);

            if (editDictionary.ContainsKey("ProveedorId"))
                productoDTO.ProveedorId = Convert.ToInt32(editDictionary["ProveedorId"]);
            else
                productoDTO.ProveedorId = null;
            productoDTO.TipoExistenciaId = Convert.ToInt32(editDictionary["TipoExistenciaId"]);
            productoDTO.LineaId = Convert.ToInt32(editDictionary["LineaId"]);
            productoDTO.Codigo = editDictionary["Codigo"].ToString();
            //productoDTO.CodigoBarra = editDictionary["CodigoBarra"].ToString();
            productoDTO.CodigoComercial = editDictionary["CodigoComercial"].ToString();
            productoDTO.MonedaId = Convert.ToInt32(editDictionary["MonedaId"]);
            productoDTO.TipoBienId = Convert.ToInt32(editDictionary["TipoBienId"]);
            productoDTO.UnidadMedidaId = Convert.ToInt32(editDictionary["UnidadMedidaId"]);
            productoDTO.Descripcion = editDictionary["Descripcion"].ToUpper().ToString();
            productoDTO.MarcaId = Convert.ToInt32(editDictionary["MarcaId"]);
            productoDTO.CategoriaId = Convert.ToInt32(editDictionary["CategoriaId"]);
            productoDTO.PrecioUnitario = Convert.ToDecimal(editDictionary["PrecioUnitario"]);
            productoDTO.StockMinimo = Convert.ToDecimal(editDictionary["StockMinimo"]);
            productoDTO.StockMaximo = Convert.ToDecimal(editDictionary["StockMaximo"]);
            productoDTO.AlmacenId = null;
           // productoDTO.PrecioVenta = Convert.ToDecimal(editDictionary["PrecioVenta"]);
           // productoDTO.PrecioCompra = Convert.ToDecimal(editDictionary["PrecioCompra"]);
            //productoDTO.Peso = Convert.ToDecimal(editDictionary["Peso"]);
            productoDTO.Procedencia = editDictionary["Procedencia"].Trim();
            productoDTO.Observacion = editDictionary["Observacion"].Trim();



            return productoDTO;
        }



        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetProveedor(string query)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();

            try
            {
                IEnumerable<ProveedorDTO> proveedorList = await _proveedorService.ListarProveedor(query);

                var jsonData = proveedorList
                    .Select(x => new
                    {
                        x.ProveedorId,
                        x.RazonSocial
                    });


                jsonResultMessage.data = jsonData;
                return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}