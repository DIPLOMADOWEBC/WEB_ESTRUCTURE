using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Data.Entity.Validation;
using Infiniteskills.Common;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Infiniteskills.Repository
{
    public class OrdenRepository : RepositoryBase<Orden>, IOrdenRepository
    {
        protected DbSet<Orden> _dbSetOrden;
        public OrdenRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _dbSetOrden = applicationDbContext.Set<Orden>();
        }
        public override string[] IncludeEntity()
        {
            string[] relatedEnties = new string[] {
                    "FormaPago",
                    "Personal",
                    "Proveedor",
                    "DocumentoComercial"
            };
            return relatedEnties;
        }
        public override Expression<Func<Orden, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Orden>();

            if (parameterList.ContainsKey("codigo"))
            {
                string value = parameterList["codigo"].ToString();
                predicate = predicate.And(x => x.Codigo.Contains(value));
            }
            if (parameterList.ContainsKey("fechaPedido"))
            {
                DateTime value = Convert.ToDateTime(parameterList["fechaPedido"]);
                predicate = predicate.And(x => DbFunctions.TruncateTime(x.FechaOrden) == value);
            }
            if (parameterList.ContainsKey("razonSocial"))
            {
                string value = parameterList["razonSocial"].ToString();
                predicate = predicate.And(x => x.Proveedor.RazonSocial.Contains(value));
            }

            if (parameterList.ContainsKey("docComercialId"))
            {
                int value = Convert.ToInt32(parameterList["docComercialId"]);
                predicate = predicate.And(x => x.DocumentoComercialId == value);
            }

            if (parameterList.ContainsKey("operacion"))
            {
                string value = Convert.ToString(parameterList["operacion"]);
                predicate = predicate.And(x => x.TipoOperacion.Codigo == value.Trim());
            }

            return predicate;
        }
        public override List<Orden> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
        public List<Orden> ListarInventario(Dictionary<string, object> parameters)
        {
            try
            {
                IQueryable<Orden> query = _dbSetOrden;

                var predicate = PredicateBuilder.True<Orden>();

                if (parameters.ContainsKey("codigo"))
                {
                    string value = parameters["codigo"].ToString();
                    predicate = predicate.And(x => x.Codigo.Contains(value));
                }

                if (parameters.ContainsKey("almacenId"))
                {
                    int value = Convert.ToInt32(parameters["almacenId"]);
                    predicate = predicate.And(x => x.AlmacenId == value);
                }

                if (parameters.ContainsKey("fechaPedido"))
                {
                    DateTime value = Convert.ToDateTime(parameters["fechaPedido"]);
                    predicate = predicate.And(x => DbFunctions.TruncateTime(x.FechaOrden) == value);
                }
                if (parameters.ContainsKey("razonSocial"))
                {
                    string value = parameters["razonSocial"].ToString();
                    predicate = predicate.And(x => x.Proveedor.RazonSocial.Contains(value));
                }

                if (parameters.ContainsKey("docComercialId"))
                {
                    int value = Convert.ToInt32(parameters["docComercialId"]);
                    predicate = predicate.And(x => x.DocumentoComercialId == value);
                }

                if (parameters.ContainsKey("operacion"))
                {
                    string value = Convert.ToString(parameters["operacion"]);
                    predicate = predicate.And(x => x.Operacion == value.Trim());
                }


                query = query
                         .Include(x => x.Personal)
                         .Include(x => x.Almacen)
                         .Include(x => x.TipoOperacion)
                         //.Include(x => x.DocumentoComercial)
                         .Where(predicate)
                         .OrderByDescending(x => x.FechaCreacion);

                return query.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Orden> ListarPedidos(Dictionary<string, object> parameters)
        {
            try
            {
            

                var predicate = PredicateBuilder.True<Orden>();

                if (parameters.ContainsKey("codigo"))
                {
                    string value = parameters["codigo"].ToString();
                    predicate = predicate.And(x => x.Codigo.Contains(value));
                }
                if (parameters.ContainsKey("fechaPedido"))
                {
                    DateTime value = Convert.ToDateTime(parameters["fechaPedido"]);
                    predicate = predicate.And(x => DbFunctions.TruncateTime(x.FechaOrden) == value);
                }
                if (parameters.ContainsKey("razonSocial"))
                {
                    string value = parameters["razonSocial"].ToString();
                    predicate = predicate.And(x => x.Proveedor.RazonSocial.Contains(value));
                }

                if (parameters.ContainsKey("docComercialId"))
                {
                    int value = Convert.ToInt32(parameters["docComercialId"]);
                    predicate = predicate.And(x => x.DocumentoComercialId == value);
                }

                if (parameters.ContainsKey("operacion"))
                {
                    string value = Convert.ToString(parameters["operacion"]);
                    predicate = predicate.And(x => x.Operacion == value.Trim());
                }


               var  query = _applicationDbContext.Orden
                         .Include(x => x.Personal)
                         .Include(x => x.Proveedor)
                         .Include(x => x.FormaPago)
                         .Include(x => x.TipoOperacion)
                         .Include(x => x.DocumentoComercial)
                         .Where(predicate)
                         .OrderByDescending(x => x.FechaCreacion);

                return query.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Orden> ListarCompra(Dictionary<string, object> parameters)
        {
            try
            {
                IQueryable<Orden> query = _dbSetOrden;

                var predicate = PredicateBuilder.True<Orden>();

                if (parameters.ContainsKey("codigo"))
                {
                    string value = parameters["codigo"].ToString();
                    predicate = predicate.And(x => x.Codigo.Contains(value));
                }
                if (parameters.ContainsKey("fechaPedido"))
                {
                    DateTime value = Convert.ToDateTime(parameters["fechaPedido"]);
                    predicate = predicate.And(x => DbFunctions.TruncateTime(x.FechaOrden) == value);
                }
                if (parameters.ContainsKey("razonSocial"))
                {
                    string value = parameters["razonSocial"].ToString();
                    predicate = predicate.And(x => x.Proveedor.RazonSocial.Contains(value));
                }

                if (parameters.ContainsKey("docComercialId"))
                {
                    int value = Convert.ToInt32(parameters["docComercialId"]);
                    predicate = predicate.And(x => x.DocumentoComercialId == value);
                }

                if (parameters.ContainsKey("operacion"))
                {
                    string value = Convert.ToString(parameters["operacion"]);
                    predicate = predicate.And(x => x.TipoOperacion.Codigo == value.Trim());
                }


                query = query
                         .Include(x => x.Personal)
                         .Include(x => x.TipoOperacion)
                         .Include(x => x.FormaPago)
                         .Include(x => x.Proveedor)
                         .Include(x => x.DocumentoComercial).Where(predicate)
                         .OrderByDescending(x => x.FechaCreacion);

                return query.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Orden> ListarMovimiento(Dictionary<string, object> parameters)
        {
            try
            {
                IQueryable<Orden> query = _dbSetOrden;

                var predicate = PredicateBuilder.True<Orden>();

                if (parameters.ContainsKey("codigo"))
                {
                    string value = parameters["codigo"].ToString();
                    predicate = predicate.And(x => x.Codigo.Contains(value));
                }
                if (parameters.ContainsKey("fechaPedido"))
                {
                    DateTime value = Convert.ToDateTime(parameters["fechaPedido"]);
                    predicate = predicate.And(x => DbFunctions.TruncateTime(x.FechaOrden) == value);
                }
                if (parameters.ContainsKey("razonSocial"))
                {
                    string value = parameters["razonSocial"].ToString();
                    predicate = predicate.And(x => x.Proveedor.RazonSocial.Contains(value));
                }

                if (parameters.ContainsKey("docComercialId"))
                {
                    int value = Convert.ToInt32(parameters["docComercialId"]);
                    predicate = predicate.And(x => x.DocumentoComercialId == value);
                }

                if (parameters.ContainsKey("operacion"))
                {
                    string value = parameters["operacion"].ToString();
                    predicate = predicate.And(x => x.Operacion == value);
                }

                if (parameters.ContainsKey("almacenId"))
                {
                    int value = Convert.ToInt32(parameters["almacenId"]);
                    predicate = predicate.And(x => x.AlmacenId == value);
                }


                query = query
                         .Include(x => x.Personal)
                         .Include(x => x.TipoOperacion)
                         .Include(x => x.DocumentoComercial).Where(predicate)
                         .OrderByDescending(x => x.FechaCreacion);

                return query.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Orden> ListarCotizacion(Dictionary<string, object> parameters)
        {
            try
            {
                IQueryable<Orden> query = _dbSetOrden;

                var predicate = PredicateBuilder.True<Orden>();

                if (parameters.ContainsKey("codigo"))
                {
                    string value = parameters["codigo"].ToString();
                    predicate = predicate.And(x => x.Codigo.Contains(value));
                }
                if (parameters.ContainsKey("fechaPedido"))
                {
                    DateTime value = Convert.ToDateTime(parameters["fechaPedido"]);
                    predicate = predicate.And(x => DbFunctions.TruncateTime(x.FechaOrden) == value);
                }
                if (parameters.ContainsKey("razonSocial"))
                {
                    string value = parameters["razonSocial"].ToString();
                    predicate = predicate.And(x => x.Proveedor.RazonSocial.Contains(value));
                }

                if (parameters.ContainsKey("docComercialId"))
                {
                    int value = Convert.ToInt32(parameters["docComercialId"]);
                    predicate = predicate.And(x => x.DocumentoComercialId == value);
                }

                if (parameters.ContainsKey("operacion"))
                {
                    string value = Convert.ToString(parameters["operacion"]);
                    List<string> list = value.Split(',').ToList();
                    predicate = predicate.And(x => list.Contains(x.TipoOperacion.Codigo));
                }


                query = query
                         .Include(x => x.Personal)
                         .Include(x => x.TipoOperacion)
                         .Include(x => x.Proveedor)
                         .Include(x => x.FormaPago)
                         .Include(x => x.DocumentoComercial).Where(predicate)
                         .OrderByDescending(x => x.FechaCreacion);

                return query.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Orden> ListarGuiaRemision(Dictionary<string, object> parameters)
        {
            try
            {
                IQueryable<Orden> query = _dbSetOrden;

                var predicate = PredicateBuilder.True<Orden>();

                if (parameters.ContainsKey("codigo"))
                {
                    string value = parameters["codigo"].ToString();
                    predicate = predicate.And(x => x.Codigo.Contains(value));
                }
                if (parameters.ContainsKey("fechaPedido"))
                {
                    DateTime value = Convert.ToDateTime(parameters["fechaPedido"]);
                    predicate = predicate.And(x => DbFunctions.TruncateTime(x.FechaOrden) == value);
                }
                if (parameters.ContainsKey("razonSocial"))
                {
                    string value = parameters["razonSocial"].ToString();
                    predicate = predicate.And(x => x.Proveedor.RazonSocial.Contains(value));
                }

                if (parameters.ContainsKey("docComercialId"))
                {
                    int value = Convert.ToInt32(parameters["docComercialId"]);
                    predicate = predicate.And(x => x.DocumentoComercialId == value);
                }

                if (parameters.ContainsKey("operacion"))
                {
                    string value = Convert.ToString(parameters["operacion"]);
                    List<string> list = value.Split(',').ToList();
                    predicate = predicate.And(x => list.Contains(x.TipoOperacion.Codigo));
                }


                query = query
                         .Include(x => x.Personal)
                         .Include(x => x.TipoOperacion)
                         .Include(x => x.Proveedor)
                         .Include(x => x.FormaPago)
                         .Include(x => x.DocumentoComercial).Where(predicate)
                         .OrderByDescending(x => x.FechaCreacion);

                return query.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task InsertIventarioItem(Orden orden)
        {
            using (var dbTransaction = _applicationDbContext.Database.BeginTransaction())
            {

                try
                {
                    List<int> bienServList = orden.OrdenItem.Select(x => x.BienServicioId).ToList();

                    string mes = orden.FechaOrden.Month.ToString(new string(DigitosConstante.CERO[0], 2));
                    MesContable mesContable = _applicationDbContext.MesContable.Where(x => x.Codigo == mes).FirstOrDefault();


                    foreach (int item in bienServList)
                    {
                        OrdenSaldo ordenSaldo = _applicationDbContext.OrdenSaldo.Where(x => x.BienServicioId == item
                                                && x.AlmacenId == orden.AlmacenId && x.PeriodoEmpresaId == orden.PeriodoEmpresaId).FirstOrDefault();

                        if (ordenSaldo == null)
                        {


                            foreach (var ordenItem in orden.OrdenItem)
                            {
                                if (item.Equals(ordenItem.BienServicioId))
                                {
                                    var ordeSaldo = new OrdenSaldo
                                    {
                                        AlmacenId = orden.AlmacenId,
                                        MesContableId = mesContable.MesContableId,
                                        PeriodoEmpresaId = orden.PeriodoEmpresaId,
                                        BienServicioId = ordenItem.BienServicioId
                                    };

                                    ordeSaldo.CantidadIngreso += ordenItem.Cantidad;
                                    ordeSaldo.ValorIngreso += ordenItem.Cantidad * ordenItem.ValorUnitario;
                                    ordeSaldo.MontoSaldo += ordenItem.Cantidad * ordenItem.ValorUnitario;
                                    ordeSaldo.CantidadReserva += ordenItem.Cantidad;

                                    _applicationDbContext.OrdenSaldo.Add(ordeSaldo);
                                    await _applicationDbContext.SaveChangesAsync();
                                    break;
                                }

                            }
                        }
                        else
                        {

                            foreach (var ordenItem in orden.OrdenItem)
                            {
                                if (ordenItem.BienServicioId.Equals(ordenSaldo.BienServicioId))
                                {


                                    _applicationDbContext.OrdenSaldo.Where(x => x.BienServicioId == item && x.AlmacenId == orden.AlmacenId
                                                                     && x.PeriodoEmpresaId == orden.PeriodoEmpresaId).ToList().ForEach(x =>
                                                                     {

                                                                         x.CantidadIngreso += ordenItem.Cantidad;
                                                                         x.ValorIngreso = ordenItem.Cantidad * ordenItem.ValorUnitario;
                                                                     });
                                    await _applicationDbContext.SaveChangesAsync();
                                    break;
                                }
                            }

                        }

                    }

                    _applicationDbContext.OrdenItem.AddRange(orden.OrdenItem);
                    orden.Cantidad = orden.OrdenItem.Sum(x => x.Cantidad);
                    orden.SubTotal = orden.OrdenItem.Sum(x => x.ValorUnitario) * orden.Cantidad;
                    orden.Impuesto = 0;
                    orden.TotalPedido = orden.SubTotal;
                    orden.MesContableId = mesContable.MesContableId;

                    _applicationDbContext.Orden.Add(orden);
                    await _applicationDbContext.SaveChangesAsync();

                    dbTransaction.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    dbTransaction.Rollback();
                    string entityValidationError = GetEntityValidationErrorMessage(ex);
                    throw new Exception(entityValidationError);
                }

            }
        }
        public async Task UpdateInventarioItem(Orden orden)
        {
            using (var dbTransaction = _applicationDbContext.Database.BeginTransaction())
            {
                try
                {

                    await _applicationDbContext.SaveChangesAsync();
                    dbTransaction.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    dbTransaction.Rollback();
                    string entityValidationError = GetEntityValidationErrorMessage(ex);
                    throw new Exception(entityValidationError);
                }
            }
        }
        public async Task InsertarMovimiento(Orden orden)
        {
            using (var dbTransaction = _applicationDbContext.Database.BeginTransaction())
            {

                try
                {
                    //bienes y servicios
                    List<int> bienServList = orden.OrdenItem.Select(x => x.BienServicioId).ToList();

                    //mes contable
                    string mes = orden.FechaOrden.Month.ToString(new string(DigitosConstante.CERO[0], 2));
                    MesContable mesContable = _applicationDbContext.MesContable.Where(x => x.Codigo == mes).FirstOrDefault();

                    //Tipo de operacion movimiento
                    TipoOperacion tipoOperacion = _applicationDbContext.TipoOperacion
                                                 // .Include(a => a.TipoMovimiento)
                                                  .Where(x => x.TipoOperacionId == orden.TipoOperacionId)
                                                  .FirstOrDefault();

                    if (tipoOperacion.Codigo == OperacionConstant.INGRESO)
                    {

                        foreach (int item in bienServList)
                        {
                            OrdenSaldo ordenSaldo = _applicationDbContext
                                                    .OrdenSaldo.Where(x => x.BienServicioId == item
                                                    && x.AlmacenId == orden.AlmacenId
                                                    && x.PeriodoEmpresaId == orden.PeriodoEmpresaId)
                                                    .FirstOrDefault();

                            if (ordenSaldo == null)
                            {

                                foreach (var ordenItem in orden.OrdenItem)
                                {
                                    if (item.Equals(ordenItem.BienServicioId))
                                    {
                                        var ordeSaldo = new OrdenSaldo
                                        {
                                            AlmacenId = orden.AlmacenId,
                                            MesContableId = mesContable.MesContableId,
                                            PeriodoEmpresaId = orden.PeriodoEmpresaId,
                                            BienServicioId = ordenItem.BienServicioId
                                        };

                                        ordeSaldo.CantidadIngreso += ordenItem.Cantidad;
                                        ordeSaldo.ValorIngreso += ordenItem.Cantidad * ordenItem.ValorUnitario;
                                        ordeSaldo.MontoSaldo += ordenItem.Cantidad * ordenItem.ValorUnitario;

                                        _applicationDbContext.OrdenSaldo.Add(ordeSaldo);
                                        await _applicationDbContext.SaveChangesAsync();
                                        break;
                                    }

                                }
                            }
                            else
                            {

                                foreach (var ordenItem in orden.OrdenItem)
                                {
                                    if (ordenItem.BienServicioId.Equals(ordenSaldo.BienServicioId))
                                    {

                                        _applicationDbContext.OrdenSaldo.Where(x => x.BienServicioId == item && x.AlmacenId == orden.AlmacenId
                                                                         && x.PeriodoEmpresaId == orden.PeriodoEmpresaId).ToList().ForEach(x =>
                                                                         {

                                                                             x.CantidadIngreso += ordenItem.Cantidad;
                                                                             x.CantidadReserva += ordenItem.Cantidad;
                                                                             x.ValorIngreso += (ordenItem.Cantidad * ordenItem.ValorUnitario);
                                                                             x.MontoSaldo += (ordenItem.Cantidad * ordenItem.ValorUnitario);
                                                                         });
                                        await _applicationDbContext.SaveChangesAsync();
                                        break;
                                    }
                                }

                            }

                        }

                    }
                    if (tipoOperacion.Codigo == OperacionConstant.SALIDA)
                    {
                        foreach (var bienServicio in bienServList)
                        {
                            OrdenSaldo ordenSaldo = _applicationDbContext.OrdenSaldo.Where(x => x.BienServicioId == bienServicio
                                                 && x.AlmacenId == orden.AlmacenId && x.PeriodoEmpresaId == orden.PeriodoEmpresaId)
                                                 .FirstOrDefault();

                            foreach (var ordenItem in orden.OrdenItem)
                            {
                                if (ordenItem.BienServicioId.Equals(ordenSaldo.BienServicioId))
                                {
                                    _applicationDbContext.OrdenSaldo.Where(x => x.BienServicioId == bienServicio && x.AlmacenId == orden.AlmacenId
                                                                     && x.PeriodoEmpresaId == orden.PeriodoEmpresaId).ToList().ForEach(x =>
                                                                     {
                                                                         x.CantidadSalida += ordenItem.Cantidad;
                                                                         x.CantidadReserva -= ordenItem.Cantidad;
                                                                         x.ValorSalida += ordenItem.Cantidad * ordenItem.ValorUnitario;
                                                                         x.MontoSaldo -= x.ValorSalida;
                                                                     });
                                    await _applicationDbContext.SaveChangesAsync();
                                    break;
                                }
                            }
                        }
                    }

                    _applicationDbContext.OrdenItem.AddRange(orden.OrdenItem);
                    decimal impuesto = ParametrosSistema.VALOR_IMPUESTO / 100;
                    orden.Cantidad = orden.OrdenItem.Sum(x => x.Cantidad);
                    orden.SubTotal = orden.OrdenItem.Sum(x => x.ValorUnitario) * orden.OrdenItem.Sum(x => x.Cantidad);
                    orden.Impuesto = orden.SubTotal * impuesto;
                    orden.TotalPedido = orden.SubTotal + orden.Impuesto;
                    orden.MesContableId = mesContable.MesContableId;
                    _applicationDbContext.Orden.Add(orden);

                    await _applicationDbContext.SaveChangesAsync();
                    dbTransaction.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    dbTransaction.Rollback();
                    string entityValidationError = GetEntityValidationErrorMessage(ex);
                    throw new Exception(entityValidationError);
                }

            }
        }
        public async Task InsertarCompra(Orden orden)
        {
            using (var dbTransaction = _applicationDbContext.Database.BeginTransaction())
            {

                try
                {
                    List<int> bienServList = orden.OrdenItem.Select(x => x.BienServicioId).ToList();
                    string mes = orden.FechaOrden.Month.ToString(new string(DigitosConstante.CERO[0], 2));
                    MesContable mesContable = await _applicationDbContext.MesContable.Where(x => x.Codigo == mes).FirstOrDefaultAsync();


                    foreach (int item in bienServList)
                    {
                        OrdenSaldo ordenSaldo = await _applicationDbContext.OrdenSaldo
                                                      .Where(x => x.BienServicioId == item
                                                      && x.AlmacenId == orden.AlmacenId
                                                      && x.PeriodoEmpresaId == orden.PeriodoEmpresaId).FirstOrDefaultAsync();

                        if (ordenSaldo == null)
                        {
                            foreach (var ordenItem in orden.OrdenItem)
                            {
                                if (item.Equals(ordenItem.BienServicioId))
                                {
                                    var ordeSaldo = new OrdenSaldo
                                    {
                                        AlmacenId = orden.AlmacenId,
                                        MesContableId = mesContable.MesContableId,
                                        PeriodoEmpresaId = orden.PeriodoEmpresaId,
                                        BienServicioId = ordenItem.BienServicioId
                                    };

                                    ordeSaldo.CantidadIngreso += ordenItem.Cantidad;
                                    ordeSaldo.ValorIngreso += ordenItem.Cantidad * ordenItem.ValorUnitario;
                                    ordeSaldo.MontoSaldo += ordenItem.Cantidad * ordenItem.ValorUnitario;
                                    ordeSaldo.CantidadReserva += ordenItem.Cantidad;

                                    _applicationDbContext.OrdenSaldo.Add(ordeSaldo);
                                    await _applicationDbContext.SaveChangesAsync();
                                    break;
                                }

                            }
                        }
                        else
                        {

                            foreach (var ordenItem in orden.OrdenItem)
                            {
                                if (ordenItem.BienServicioId.Equals(ordenSaldo.BienServicioId))
                                {


                                    _applicationDbContext.OrdenSaldo.Where(x => x.BienServicioId == item && x.AlmacenId == orden.AlmacenId
                                                                     && x.PeriodoEmpresaId == orden.PeriodoEmpresaId).ToList().ForEach(x =>
                                                                     {
                                                                         x.CantidadIngreso += ordenItem.Cantidad;
                                                                         x.ValorIngreso = ordenItem.Cantidad * ordenItem.ValorUnitario;
                                                                     });
                                    await _applicationDbContext.SaveChangesAsync();
                                    break;
                                }
                            }

                        }

                    }

                    _applicationDbContext.OrdenItem.AddRange(orden.OrdenItem);

                    decimal impuesto = ParametrosSistema.VALOR_IMPUESTO / 100;

                    orden.Cantidad = orden.OrdenItem.Sum(x => x.Cantidad);
                    orden.SubTotal = orden.OrdenItem.Sum(x => x.ValorUnitario) * orden.Cantidad;
                    orden.Impuesto = orden.SubTotal * impuesto;
                    orden.TotalPedido = orden.SubTotal + orden.Impuesto;
                    orden.MesContableId = mesContable.MesContableId;
                    _applicationDbContext.Orden.Add(orden);
                    await _applicationDbContext.SaveChangesAsync();

                    dbTransaction.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    dbTransaction.Rollback();
                    string entityValidationError = GetEntityValidationErrorMessage(ex);
                    throw new Exception(entityValidationError);
                }

            }
        }
        public async Task InsertarTransferencia(Orden orden)
        {
            using (var dbTransaction = _applicationDbContext.Database.BeginTransaction())
            {

                try
                {
                    //Lista de bienes patrimoniales
                    List<int> bienServList = orden.OrdenItem.Select(x => x.BienServicioId).ToList();

                    string mes = orden.FechaOrden.Month.ToString(new string(DigitosConstante.CERO[0], 2));
                    MesContable mesContable = _applicationDbContext
                                               .MesContable.Where(x => x.Codigo == mes).FirstOrDefault();


                    foreach (int item in bienServList)
                    {
                        OrdenSaldo ordenSaldo = _applicationDbContext
                                                .OrdenSaldo.Where(x => x.BienServicioId == item
                                                && x.AlmacenId == orden.AlmacenId
                                                && x.PeriodoEmpresaId == orden.PeriodoEmpresaId).FirstOrDefault();


                        foreach (var ordenItem in orden.OrdenItem)
                        {
                            if (ordenItem.BienServicioId.Equals(ordenSaldo.BienServicioId))
                            {

                                _applicationDbContext.OrdenSaldo.Where(x => x.BienServicioId == item && x.AlmacenId == orden.AlmacenId
                                                                 && x.PeriodoEmpresaId == orden.PeriodoEmpresaId).ToList().ForEach(x =>
                                                                 {
                                                                     x.CantidadSalida += ordenItem.Cantidad;
                                                                     x.CantidadReserva -= ordenItem.Cantidad;
                                                                     x.ValorSalida += ordenItem.Cantidad * ordenItem.ValorUnitario;
                                                                     x.MontoSaldo -= x.ValorSalida;
                                                                 });

                                await _applicationDbContext.SaveChangesAsync();
                                break;
                            }
                        }

                    }

                    _applicationDbContext.OrdenItem.AddRange(orden.OrdenItem);
                    orden.Cantidad = orden.OrdenItem.Sum(x => x.Cantidad);
                    orden.SubTotal = orden.OrdenItem.Sum(x => x.ValorUnitario) * orden.Cantidad;
                    orden.TotalPedido = orden.SubTotal;
                    orden.MesContableId = mesContable.MesContableId;
                    orden.Impuesto = 0;

                    _applicationDbContext.Orden.Add(orden);
                    await _applicationDbContext.SaveChangesAsync();

                    dbTransaction.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    dbTransaction.Rollback();
                    string entityValidationError = GetEntityValidationErrorMessage(ex);
                    throw new Exception(entityValidationError);
                }

            }
        }
        public  void InsertPedidoItem(Orden orden)
        {
            using (var dbTransaction = _applicationDbContext.Database.BeginTransaction())
            {

                try
                {
                    //Lista de bienes patrimoniales
                    List<int> bienServList = orden.OrdenItem.Select(x => x.BienServicioId).ToList();

                    string mes = orden.FechaOrden.Month.ToString(new string(DigitosConstante.CERO[0], 2));
                    MesContable mesContable = _applicationDbContext
                                               .MesContable.Where(x => x.Codigo == mes).FirstOrDefault();


                    foreach (int item in bienServList)
                    {
                        OrdenSaldo ordenSaldo = _applicationDbContext
                                                .OrdenSaldo.Where(x => x.BienServicioId == item
                                                && x.AlmacenId == orden.AlmacenId
                                                && x.PeriodoEmpresaId == orden.PeriodoEmpresaId).FirstOrDefault();


                        foreach (var ordenItem in orden.OrdenItem)
                        {
                            if (ordenItem.BienServicioId.Equals(ordenSaldo.BienServicioId))
                            {

                                _applicationDbContext.OrdenSaldo.Where(x => x.BienServicioId == item && x.AlmacenId == orden.AlmacenId
                                                                 && x.PeriodoEmpresaId == orden.PeriodoEmpresaId).ToList().ForEach(x =>
                                                                 {
                                                                     x.CantidadSalida += ordenItem.Cantidad;
                                                                     x.CantidadReserva -= ordenItem.Cantidad;
                                                                     x.ValorSalida += ordenItem.Cantidad * ordenItem.ValorUnitario;
                                                                     x.MontoSaldo -= x.ValorSalida;
                                                                 });

                              _applicationDbContext.SaveChanges();
                                break;
                            }
                        }

                    }

                    _applicationDbContext.OrdenItem.AddRange(orden.OrdenItem);
                    orden.Cantidad = orden.OrdenItem.Sum(x => x.Cantidad);
                    orden.SubTotal = orden.OrdenItem.Sum(x => x.ValorUnitario) * orden.Cantidad;
                    orden.TotalPedido = orden.SubTotal;
                    orden.MesContableId = mesContable.MesContableId;
                    orden.Impuesto = 0;
                    _applicationDbContext.Orden.Add(orden);
                    _applicationDbContext.SaveChanges();

                    dbTransaction.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    dbTransaction.Rollback();
                    string entityValidationError = GetEntityValidationErrorMessage(ex);
                    throw new Exception(entityValidationError);
                }

            }
        }
        public async Task UpdatePedidoItem(Orden pedido)
        {

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            using (var transaction = _applicationDbContext.Database.BeginTransaction())
            {
                try
                {
                    await _applicationDbContext.SaveChangesAsync();
                    transaction.Commit();

                }
                catch (DbEntityValidationException ex)
                {
                    transaction.Rollback();
                    string entityValidationError = GetEntityValidationErrorMessage(ex);
                    throw new Exception(entityValidationError);
                }
            }
        }
        public async Task<Orden> BuscarPedidos(int id)
        {
           var query = _applicationDbContext.Orden
                       .Include(x => x.Proveedor)
                       .Include(x => x.TipoOperacion)
                       .Where(x => x.OrdenId == id)
                       .OrderByDescending(x => x.FechaCreacion);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Orden> BuscarInventarioInicial(int id)
        {
            IQueryable<Orden> query = _dbSetOrden;
            query = query
                       .Include(x => x.TipoOperacion)
                       .Where(x => x.OrdenId == id)
                       .OrderByDescending(x => x.FechaCreacion);

            return await query.FirstOrDefaultAsync();
        }
        public IEnumerable<Orden> BuscarOrdenCompra(string codigo)
        {
            IQueryable<Orden> query = _dbSetOrden;
            query = query
                       .Include(x => x.FormaPago)
                       .Include(x => x.Proveedor)
                       .Include(x => x.Almacen)
                       .Include(x => x.DocumentoComercial)
                       .Include(x => x.TipoOperacion)
                       .Include(x => x.Moneda)
                       .Where(x => x.Codigo.Contains(codigo));

            return query.ToList();
        }
        public async Task<Orden> BuscarMovimiento(int id)
        {
            IQueryable<Orden> query = _dbSetOrden;
            query = query
                       .Include(x => x.TipoOperacion)
                       .Include(x => x.Proveedor)
                       .Where(x => x.OrdenId == id)
                       .OrderByDescending(x => x.FechaCreacion);

            return await query.FirstOrDefaultAsync();
        }
        public decimal VerificarSaldo(OrdenSaldo saldo)
        {
            throw new NotImplementedException();
        }

    }
}
