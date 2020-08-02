using Infiniteskills.Helpers;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.LG.Controllers
{
    public class KardexController : AppController
    {
        private IOrdenItemService ordenItemService;
        private IBienServicioService bienServicioService;
        private IAlmacenService almacenService;
        private IEmpresaService empresaService;
        private ITipoOperacionService tipoOperacionService;
        private ITipoMovimientoService tipoMovimientoService;
        public KardexController(IOrdenItemService ordenItemService, IUsuarioService usuarioService,
            IBienServicioService bienServicioService, ITipoOperacionService tipoOperacionService,
            ITipoMovimientoService tipoMovimientoService, IAlmacenService almacenService,
            IEmpresaService empresaService)
                     : base(usuarioService)
        {
            this.ordenItemService = ordenItemService;
            this.bienServicioService = bienServicioService;
            this.almacenService = almacenService;
            this.empresaService = empresaService;
            this.tipoOperacionService = tipoOperacionService;
            this.tipoMovimientoService = tipoMovimientoService;
        }
        public ActionResult Bandeja()
        {
            ListarDropList();
            return PartialView();
        }

        [HttpPost]
        public ActionResult ListarBandeja(string bienServicioId, string empresaId, 
            string almacenId, string tipoMovimientoId, string tipoOperacionId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrEmpty(bienServicioId))
                    parameters.Add("bienServicioId", bienServicioId);


                if (!string.IsNullOrEmpty(empresaId))
                    parameters.Add("empresaId", empresaId);

                if (!string.IsNullOrEmpty(almacenId))
                    parameters.Add("almacenId", almacenId);
                else
                    parameters.Add("almacenId", this.UsuarioAlmacenId());

                if (!string.IsNullOrEmpty(tipoMovimientoId))
                    parameters.Add("tipoMovimientoId", tipoMovimientoId);

                if (!string.IsNullOrEmpty(tipoOperacionId))
                    parameters.Add("tipoOperacionId", tipoOperacionId);


                IEnumerable<KardexProductoDTO> ordenSaldoDTOList = ordenItemService.ListarKardex(parameters);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = ordenSaldoDTOList.Count(),
                    rows = from f in ordenSaldoDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   f.Codigo,
                                   f.Color,
                                   f.Descripcion,
                                   f.UnidadMedida,
                                   f.Movimiento,
                                   FechaPedido = f.FechaPedido.ToString("dd/MM/yyyy"),
                                   f.ValorUnitario,
                                   f.CantidadIngreso,
                                   f.MontoIngreso,
                                   f.CantidadSalida,
                                   f.ValorSalida,
                                   f.CantidadSaldo,
                                   f.MontoSaldo,
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

        // GET: OP/Kardex/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        private void ListarDropList()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            List<AlmacenDTO> almacenDTOList = almacenService.SearchFor(parameters, string.Empty);
            ViewBag.ListarAlmacen = WebHelper.ToSelectListItem<AlmacenDTO>(
            almacenDTOList, x => x.AlmacenId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


            List<EmpresaDTO> empresaDTOList = empresaService.SearchFor(parameters, string.Empty);
            ViewBag.ListarEmpresa = WebHelper.ToSelectListItem<EmpresaDTO>(
            empresaDTOList, x => x.EmpresaId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


            List<TipoMovimientoDTO> tipoMovimientoDTOList = tipoMovimientoService.SearchFor(parameters, string.Empty)
                .Cast<TipoMovimientoDTO>().ToList();

            ViewBag.TipoMovimimentoList = WebHelper.ToSelectListItem<TipoMovimientoDTO>(tipoMovimientoDTOList
                , x => x.TipoMovimientoId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);


            ViewBag.TipoOperacionList = WebHelper.ToSelectListItem<TipoOperacionDTO>(SelectListFirstElementType.Select);
        }

        [HttpPost]
        public async Task<JsonResult> GetBienServicio(string query)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {

                IEnumerable<BienServicioDTO> bienServicioList = await bienServicioService.ListarBienServicio(query);

                var jsonData = from f in bienServicioList
                               select new
                               {
                                   f.BienServicioId,
                                   f.Descripcion
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
        public JsonResult GetTipoOperacion(int tipoMovimientoId)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "tipoMovimientoId", tipoMovimientoId }
                };

                List<TipoOperacionDTO> tipoOperacionDTOList = tipoOperacionService.SearchFor(parameters, string.Empty)
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

    }
}
