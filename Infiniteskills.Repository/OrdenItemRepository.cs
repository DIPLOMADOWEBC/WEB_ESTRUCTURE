using Infiniteskills.Common;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{

    public class OrdenItemRepository : RepositoryBase<OrdenItem>, IOrdenItemRepository
    {
        protected DbSet<OrdenItem> _DbSetOrdenItem;
        protected DbSet<OrdenSaldo> _DbOrdenSaldo;
        public OrdenItemRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _DbSetOrdenItem = applicationDbContext.Set<OrdenItem>();
            _DbOrdenSaldo = applicationDbContext.Set<OrdenSaldo>();
        }

        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] {
                "Orden.FormaPago",
                "Orden.Proveedor",
                "Orden.DocumentoComercial",
                "Orden.Personal",
                "BienServicio"
            };
            return relatedEnties;
        }
        public override Expression<Func<OrdenItem, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<OrdenItem>();
            if (parameterList.ContainsKey("ordenId"))
            {
                int value = Convert.ToInt32(parameterList["ordenId"]);
                predicate = predicate.And(x => x.OrdenId == value);
            }
            if (parameterList.ContainsKey("pedidodoItemList"))
            {
                List<int> valueList = (List<int>)parameterList["pedidodoItemList"];
                predicate = predicate.And(p => valueList.Contains(p.OrdenItemId));
            }


            return predicate;
        }
        public override List<OrdenItem> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
        public IEnumerable<OrdenItem> ListarInventario(Dictionary<string, object> parameters)
        {
            IQueryable<OrdenItem> query = _DbSetOrdenItem;

            var predicate = PredicateBuilder.True<OrdenItem>();


            query = query
                     .Include(x => x.Orden.DocumentoComercial)
                     .Include(x => x.BienServicio.UnidadMedida)
                     .Where(predicate)
                     .OrderByDescending(x => x.FechaCreacion);

            return query.ToList();
        }
        public IEnumerable<OrdenItem> ListarFactura(int id)
        {
            var query = _applicationDbContext.OrdenItem
                .Include(x => x.Orden.Proveedor)
                .Include(x => x.BienServicio)
                .Where(x=>x.OrdenId== id)
                .ToList();

            return query;
        }
        public IEnumerable<KardexProducto> ListarKardex(Dictionary<string, object> parameters)
        {
            var predicateOrden = PredicateBuilder.True<OrdenItem>();
            var predicateOrdenSaldo = PredicateBuilder.True<OrdenSaldo>();

            IQueryable<OrdenItem> orden = _DbSetOrdenItem;

            IQueryable<OrdenSaldo> ordenSaldo = _DbOrdenSaldo;

            if (parameters.ContainsKey("bienServicioId"))
            {
                int value = Convert.ToInt32(parameters["bienServicioId"]);
                predicateOrden = predicateOrden.And(x => x.BienServicioId== value);
                predicateOrdenSaldo = predicateOrdenSaldo.And(x => x.BienServicioId == value);
            }

            if (parameters.ContainsKey("empresaId"))
            {
                int value = Convert.ToInt32(parameters["empresaId"]);
                predicateOrden = predicateOrden.And(x => x.Orden.Almacen.Sucursal.EmpresaId == value);
            }

            if (parameters.ContainsKey("almacenId"))
            {
                int value = Convert.ToInt32(parameters["almacenId"]);
                predicateOrden = predicateOrden.And(x => x.Orden.Almacen.AlmacenId == value);
                predicateOrdenSaldo = predicateOrdenSaldo.And(x => x.AlmacenId == value);
            }

            //if (parameters.ContainsKey("tipoMovimientoId"))
            ////{
            ////    int value = Convert.ToInt32(parameters["tipoMovimientoId"]);
            ////    predicateOrden = predicateOrden.And(x => x.Orden.TipoOperacion.TipoMovimientoId == value);
            ////}

            if (parameters.ContainsKey("tipoOperacionId"))
            {
                int value = Convert.ToInt32(parameters["tipoOperacionId"]);
                predicateOrden = predicateOrden.And(x => x.Orden.TipoOperacionId == value);
            }

            var ordenItem = orden
                   .Include(x => x.BienServicio)
                   .Where(predicateOrden)
                   .OrderBy(x => x.BienServicioId)
                   .Select(x => new KardexProducto()
                   {
                       BienServicioId = x.BienServicioId,
                       Codigo = x.BienServicio.Codigo,
                       FechaPedido = x.Orden.FechaOrden,
                       //Color = x.Orden.TipoOperacion.TipoMovimiento.Codigo,
                       //Movimiento = x.Orden.TipoOperacion.TipoMovimiento.Nombre,
                       Descripcion = x.BienServicio.Descripcion,
                       UnidadMedida = x.BienServicio.UnidadMedida.Abreaviatura,
                       CantidadIngreso = x.Orden.Operacion == OperacionConstant.INGRESO ? x.Cantidad : 0,
                       ValorUnitario = x.Orden.Operacion == OperacionConstant.INGRESO ? x.ValorUnitario : 0,
                       MontoIngreso = x.Orden.Operacion == OperacionConstant.INGRESO ? x.Cantidad * x.ValorUnitario : 0,
                       CantidadSalida = x.Orden.Operacion == OperacionConstant.SALIDA ? 0 - x.Cantidad : 0,
                       ValorSalida = x.Orden.Operacion == OperacionConstant.SALIDA ? 0 - x.ValorUnitario : 0,
                       CantidadSaldo = x.Orden.Operacion == OperacionConstant.INGRESO ? 0 + x.Cantidad : 0,
                       MontoSaldo = x.Orden.Operacion == OperacionConstant.INGRESO ? 0 + (x.Cantidad * x.ValorUnitario) : 0,
                       FechaCreacion = x.FechaCreacion
                   });

            var ordenSaldos = ordenSaldo
                        .Include(x => x.BienServicio)
                        .Where(predicateOrdenSaldo)
                        .OrderBy(x => x.BienServicioId)
                        .Select(x => new KardexProducto()
                        {
                            BienServicioId = x.BienServicioId,
                            Codigo = x.BienServicio.Codigo,
                            FechaPedido = x.FechaCreacion,
                            Color = string.Empty,
                            Movimiento = string.Empty,
                            Descripcion = x.BienServicio.Descripcion,
                            UnidadMedida = x.BienServicio.UnidadMedida.Abreaviatura,
                            CantidadIngreso = x.CantidadIngreso,
                            ValorUnitario = x.ValorUnitario,
                            MontoIngreso = x.ValorIngreso,
                            CantidadSalida = 0 - x.CantidadSalida,
                            ValorSalida = 0 - x.ValorSalida,
                            CantidadSaldo = x.CantidadReserva,
                            MontoSaldo = x.MontoSaldo,
                            FechaCreacion = x.FechaCreacion
                        });

            var queryUnion = ordenItem
                .Union(ordenSaldos);
            return queryUnion.ToList();
        }
        public IEnumerable<OrdenItem> ListarOrdenItem(Dictionary<string, object> parameters)
        {
            IQueryable<OrdenItem> query = _DbSetOrdenItem;

            var predicate = PredicateBuilder.True<OrdenItem>();
            if (parameters.ContainsKey("ordenId"))
            {
                int value = Convert.ToInt32(parameters["ordenId"]);
                predicate = predicate.And(x => x.OrdenId == value);
            }

            query = query
                     .Include(x => x.BienServicio.UnidadMedida)
                     .Where(predicate)
                     .OrderByDescending(x => x.FechaCreacion);

            return query.ToList();
        }
    }
}
