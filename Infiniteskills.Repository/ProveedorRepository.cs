using Infiniteskills.Common;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infiniteskills.Repository
{
  
    public class ProveedorRepository : RepositoryBase<Proveedor>, IProveedorRepository
    {
        private DbSet<Proveedor> _proveedorDbSet;
        public ProveedorRepository(ApplicationDbContext ApplicationDbContext)
            : base(ApplicationDbContext)
        {
            _proveedorDbSet = _applicationDbContext.Proveedor;
        }

        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] {
                "Distrito.Provincia.Departamento.Pais",
                "FormaVenta",
                "TipoProveedor"
            };
            return relatedEnties;
        }
        public override Expression<Func<Proveedor, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Proveedor>();
            if (parameterList.ContainsKey("numeroDocumento"))
            {
                string value = Convert.ToString(parameterList["numeroDocumento"]);
                predicate = predicate.And(x => x.NumeroDocumento.Contains(value));
            }

            if (parameterList.ContainsKey("razonSocial"))
            {
                string value = Convert.ToString(parameterList["razonSocial"]);
                predicate = predicate.And(x => x.RazonSocial.Contains(value));
            }

            if (parameterList.ContainsKey("tipoProveedor"))
            {
                string value = Convert.ToString(parameterList["tipoProveedor"]);
                predicate = predicate.And(x => x.TipoCliente == value);
            }

            return predicate;
        }

        public override List<Proveedor> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), pageCount, orderBy);
        }



        public async Task<IEnumerable<Proveedor>> ListarProveedor(string query)
        {
            var queryLinq = _applicationDbContext
                .Proveedor.Where(x => x.RazonSocial.Contains(query) || x.Nombres.Contains(query) || x.NumeroDocumento.Contains(query))
                .Take(10).ToListAsync();
            return await queryLinq;
        }


        public async Task<Proveedor> BuscarProveedor(int id)
        {
            IQueryable<Proveedor> query = _proveedorDbSet;

            query = query
                .Include(x => x.Personal)
                //.Include(x => x.Direccion)
                .Where(x => x.ProveedorId == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Proveedor>> ListarProveedor(int id)
        {
            var query = _applicationDbContext
                .Proveedor.Where(x => x.ProveedorId == id)
                .ToListAsync();

            return await query;
        }

        public void InsertarCliente(Proveedor proveedor,
              IEnumerable<Contacto> contacto)
        {
            using (var dbTransaction = _applicationDbContext.Database.BeginTransaction())
            {
                try
                {

                    IEnumerable<Contacto> lista =
                        _applicationDbContext
                        .Contacto.AddRange(contacto);
                    _applicationDbContext.SaveChanges();


                    proveedor.ProveedorContacto = lista
                        .Select(x => new ProveedorContacto()
                        {
                            ContactoId = x.ContactoId
                        }).ToList();

                    _applicationDbContext.Proveedor.Add(proveedor);
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

        public void ActualizarCliente(Proveedor proveedor)
        {
            using (var dbTransaction = _applicationDbContext.Database.BeginTransaction())
            {
                try
                {

                    _applicationDbContext.Proveedor.Where(x => x.ProveedorId == proveedor.ProveedorId).ToList().ForEach(x =>
                    {
                        x.ProveedorId = proveedor.ProveedorId;
                        x.DocumentoIdentidadId = proveedor.DocumentoIdentidadId;
                        x.NumeroDocumento = proveedor.NumeroDocumento;
                        x.TipoProveedorId = proveedor.TipoProveedorId;
                        x.TipoProveedorId = proveedor.TipoProveedorId;
                        x.RazonSocial = proveedor.RazonSocial;
                        x.Nombres = proveedor.Nombres;
                        x.PersonalId = proveedor.PersonalId;
                        x.Telefono = proveedor.Telefono;
                        x.Celular = proveedor.Celular;
                        x.NombreDireccion = proveedor.NombreDireccion;
                        x.FormaVentaId = proveedor.FormaVentaId;
                        x.MonedaId = proveedor.MonedaId;
                        x.TipoPrecioId = proveedor.TipoPrecioId;
                       // x.Direccion = proveedor.Direccion;
                        x.DistritoId = proveedor.DistritoId;
                        x.CorreoUno = proveedor.CorreoUno;
                        x.CorreoDos = proveedor.CorreoDos;
                        x.PaginaWeb = proveedor.PaginaWeb;
                    });
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

        public async Task<IEnumerable<Proveedor>> BuscarPorRuc(string ruc)
        {
            var query = _applicationDbContext.Proveedor
                .Where(x => x.NumeroDocumento.Contains(ruc)
                && x.Estado == EstadoConstante.ACTIVO)
                .ToListAsync();

            return await query;
        }

        public IEnumerable<Proveedor> BuscarPorCodigo(int id)
        {
            var query = _applicationDbContext
                .Proveedor.Where(x => x.ProveedorId == id)
                .ToList();

            return  query;
        }
    }
}
