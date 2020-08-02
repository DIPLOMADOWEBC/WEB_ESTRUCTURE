using AutoMapper;
using Infiniteskills.Domain;
using Infiniteskills.Transport;

namespace Infiniteskills.Service
{
    public class ModelToDomainMappingConfig : Profile
    {
        public ModelToDomainMappingConfig()
             : this("MyProfiles")
        {
        }

        protected ModelToDomainMappingConfig(string profileName)
            : base(profileName)
        {

            CreateMap<AreaDTO, Area>()
               .ForMember(e => e.Contacto, opt => opt.Ignore());

            CreateMap<ImpuestoDTO, Impuesto>()
             .ForMember(e => e.Orden, opt => opt.Ignore());

            CreateMap<TipoPrecioDTO, TipoPrecio>()
             .ForMember(e => e.Proveedor, opt => opt.Ignore())
             .ForMember(e => e.Orden, opt => opt.Ignore());

            CreateMap<SucursalPersonalDTO, SucursalPersonal>()
               .ForMember(e => e.Personal, opt => opt.Ignore())
               .ForMember(e => e.Sucursal, opt => opt.Ignore());


            CreateMap<FormaVentaDTO, FormaVenta>()
                .ForMember(e => e.Proveedor, opt => opt.Ignore());

            CreateMap<ContactoDTO, Contacto>()
            .ForMember(e => e.Area, opt => opt.Ignore())
            .ForMember(e => e.ProveedorContacto, opt => opt.Ignore());

            CreateMap<ProveedorContactoDTO, ProveedorContacto>()
                .ForMember(e => e.Contacto, opt => opt.Ignore())
                .ForMember(e => e.Proveedor, opt => opt.Ignore());

            CreateMap<MonedaDTO, Moneda>()
             .ForMember(e => e.Producto, opt => opt.Ignore())
             .ForMember(e => e.Proveedor, opt => opt.Ignore())
             .ForMember(e => e.Orden, opt => opt.Ignore());

            CreateMap<TipoMovimientoDTO, TipoMovimiento>().ReverseMap();
           /// .ForMember(e => e.TipoOperacion, opt => opt.Ignore());


            CreateMap<TipoOperacionDTO, TipoOperacion>()
                 // .ForMember(e => e.TipoMovimiento, opt => opt.Ignore())
                  .ForMember(e => e.Orden, opt => opt.Ignore());


            CreateMap<PeriodoDTO, Periodo>()
                 .ForMember(e => e.PeriodoEmpresa, opt => opt.Ignore());

            CreateMap<TipoProveedorDTO, TipoProveedor>()
             .ForMember(e => e.Proveedor, opt => opt.Ignore());

            CreateMap<AlmacenDTO, Almacen>()
              .ForMember(e => e.Sucursal, opt => opt.Ignore())
              .ForMember(e => e.Orden, opt => opt.Ignore())
              .ForMember(e => e.OrdenSaldo, opt => opt.Ignore())
              .ForMember(e => e.Serie, opt => opt.Ignore());

            CreateMap<PeriodoEmpresaDTO, PeriodoEmpresa>()
             .ForMember(e => e.Periodo, opt => opt.Ignore())
             .ForMember(e => e.PeriodoCorrelativo, opt => opt.Ignore())
             .ForMember(e => e.Orden, opt => opt.Ignore())
             .ForMember(e => e.OrdenSaldo, opt => opt.Ignore());
             //.ForMember(e => e.Sucursal, opt => opt.Ignore());

            CreateMap<PeriodoCorrelativoDTO, PeriodoCorrelativo>()
             .ForMember(e => e.Tabla, opt => opt.Ignore())
             .ForMember(e => e.PeriodoEmpresa, opt => opt.Ignore());

            CreateMap<SucursalDTO, Sucursal>()
                //.ForMember(e => e.PeriodoEmpresa, opt => opt.Ignore())
                .ForMember(e => e.Empresa, opt => opt.Ignore())
                .ForMember(e => e.Almacen, opt => opt.Ignore())
                .ForMember(e => e.Distrito, opt => opt.Ignore())
                .ForMember(e => e.SucursalUsuario, opt => opt.Ignore());

            CreateMap<FormaPagoDTO, FormaPago>()
                .ForMember(e => e.Pedido, opt => opt.Ignore());

            CreateMap<EmpresaDTO, Empresa>()
                .ForMember(e => e.Sucursal, opt => opt.Ignore());

            CreateMap<DocumentoComercialDTO, DocumentoComercial>()
                  .ForMember(e => e.Pedido, opt => opt.Ignore());


            CreateMap<CategoriaDTO, Categoria>()
              .ForMember(e => e.Producto, opt => opt.Ignore());

            CreateMap<UnidadMedidaDTO, UnidadMedida>()
                .ForMember(e => e.Producto, opt => opt.Ignore());

            CreateMap<DocumentoIdentidadDTO, DocumentoIdentidad>()
                .ForMember(e => e.Proveedor, opt => opt.Ignore());

            CreateMap<ProveedorDTO, Proveedor>()
               //.ForMember(e => e.Direccion, opt => opt.Ignore())
               .ForMember(e => e.FormaVenta, opt => opt.Ignore())
               .ForMember(e => e.Distrito, opt => opt.Ignore())
               .ForMember(e => e.Producto, opt => opt.Ignore())
               .ForMember(e => e.DocumentoIdentidad, opt => opt.Ignore())
               .ForMember(e => e.TipoProveedor, opt => opt.Ignore())
               .ForMember(e => e.ProveedorContacto, opt => opt.Ignore())
               .ForMember(e => e.Personal, opt => opt.Ignore())
               .ForMember(e => e.Moneda, opt => opt.Ignore())
               .ForMember(e => e.TipoPrecio, opt => opt.Ignore())
               .ForMember(e => e.Orden, opt => opt.Ignore());

            CreateMap<TipoUsuarioDTO, TipoUsuario>().ReverseMap();

            CreateMap<UsuarioDTO, Usuario>()
             .ForMember(e => e.Personal, opt => opt.Ignore());

            CreateMap<PersonalDTO, Personal>()
             .ForMember(e => e.Pedido, opt => opt.Ignore())
             .ForMember(e => e.Proveedor, opt => opt.Ignore())
             .ForMember(e => e.Usuario, opt => opt.Ignore())
             .ForMember(e => e.SucursalUsuario, opt => opt.Ignore());

            CreateMap<DistritoDTO, Distrito>()
                 .ForMember(e => e.Direccion, opt => opt.Ignore())
                 .ForMember(e => e.Proveedor, opt => opt.Ignore())
                 .ForMember(e => e.Provincia, opt => opt.Ignore())
                 .ForMember(e => e.Sucursal, opt => opt.Ignore());

            CreateMap<BienServicioDTO, BienServicio>()
               .ForMember(e => e.Moneda, opt => opt.Ignore())
               .ForMember(e => e.Linea, opt => opt.Ignore())
               .ForMember(e => e.PedidoItem, opt => opt.Ignore())
               .ForMember(e => e.TipoExistencia, opt => opt.Ignore())
               .ForMember(e => e.UnidadMedida, opt => opt.Ignore())
               .ForMember(e => e.Proveedor, opt => opt.Ignore())
               .ForMember(e => e.Categoria, opt => opt.Ignore())
               .ForMember(e => e.TipoBien, opt => opt.Ignore())
               .ForMember(e => e.OrdenSaldo, opt => opt.Ignore())
               .ForMember(e => e.Marca, opt => opt.Ignore());


            CreateMap<ConductorDTO, Conductor>()
               .ForMember(e => e.Orden, opt => opt.Ignore());


            CreateMap<VehiculoDTO, Vehiculo>()
                .ForMember(e => e.Orden, opt => opt.Ignore());

            CreateMap<OrdenDTO, Orden>()
                .ForMember(e => e.OrdenItem, opt => opt.Ignore())
                .ForMember(e => e.FormaPago, opt => opt.Ignore())
                .ForMember(e => e.DocumentoComercial, opt => opt.Ignore())
                .ForMember(e => e.TipoOperacion, opt => opt.Ignore())
                .ForMember(e => e.Proveedor, opt => opt.Ignore())
                .ForMember(e => e.Moneda, opt => opt.Ignore())
                .ForMember(e => e.Almacen, opt => opt.Ignore())
                .ForMember(e => e.PeriodoEmpresa, opt => opt.Ignore())
                .ForMember(e => e.MesContable, opt => opt.Ignore())
                .ForMember(e => e.Vehiculo, opt => opt.Ignore())
                .ForMember(e => e.Conductor, opt => opt.Ignore())
                .ForMember(e => e.TipoPrecio, opt => opt.Ignore())
                .ForMember(e => e.Impuesto, opt => opt.Ignore())
                .ForMember(e => e.Personal, opt => opt.Ignore());

            CreateMap<OrdenItemDTO, OrdenItem>()
                .ForMember(e => e.Orden, opt => opt.Ignore())
                .ForMember(e => e.BienServicio, opt => opt.Ignore());

            CreateMap<OrdenSaldoDTO, OrdenSaldo>()
             .ForMember(e => e.BienServicio, opt => opt.Ignore())
             .ForMember(e => e.Almacen, opt => opt.Ignore())
             .ForMember(e => e.MesContable, opt => opt.Ignore())
             .ForMember(e => e.PeriodoEmpresa, opt => opt.Ignore());

            CreateMap<MesContableDTO, MesContable>()
            .ForMember(e => e.OrdenSaldo, opt => opt.Ignore())
            .ForMember(e => e.Orden, opt => opt.Ignore());


            CreateMap<LineaDTO, Linea>()
                .ForMember(e => e.BienServicio, opt => opt.Ignore());

        }
    }
}