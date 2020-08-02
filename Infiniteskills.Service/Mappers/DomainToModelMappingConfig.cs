using AutoMapper;
using Infiniteskills.Domain;
using Infiniteskills.Transport;

namespace Infiniteskills.Service
{
    public class DomainToModelMappingConfig : Profile
    {
        public DomainToModelMappingConfig()
             : this("MyProfile")
        {

        }

        protected DomainToModelMappingConfig(string profileName)
            : base(profileName)
        {
            CreateMap<TipoPrecio, TipoPrecioDTO>().ReverseMap();

            CreateMap<Linea, LineaDTO>().ReverseMap();

            CreateMap<TipoBien, TipoBienDTO>().ReverseMap();

            CreateMap<SucursalPersonal, SucursalPersonalDTO>()
                .ForMember(dto => dto.SucursalDTO, dto => dto.MapFrom(e => e.Sucursal))
                .ForMember(dto => dto.PersonalDTO, dto => dto.MapFrom(e => e.Personal))
                .ReverseMap();

            CreateMap<Marca, MarcaDTO>().ReverseMap();

            CreateMap<MesContable, MesContableDTO>().ReverseMap();

            CreateMap<ParametroSistema, ParametroSistemaDTO>()
                .ForMember(dto => dto.EditAction, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Moneda, MonedaDTO>()
                .ReverseMap();

            CreateMap<Contacto, ContactoDTO>()
                .ForMember(dto => dto.AreaDTO, dto => dto.MapFrom(e => e.Area))
                .ForMember(dto => dto.ProveedorId, opt => opt.Ignore())
                 .ForMember(dto => dto.EditAction, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ProveedorContacto, ProveedorContactoDTO>()
                .ForMember(dto => dto.ProveedorDTO, dto => dto.MapFrom(e => e.Proveedor))
                .ForMember(dto => dto.ContactoDTO, dto => dto.MapFrom(e => e.Contacto))
                .ReverseMap();

            CreateMap<DireccionProveedor, DireccionProveedorDTO>()
                //.ForMember(dto => dto.ProveedorDTO, dto => dto.MapFrom(e => e.Proveedor))
                .ForMember(dto => dto.DistritoDTO, dto => dto.MapFrom(e => e.Distrito))
                .ReverseMap();

            CreateMap<Serie, SerieDTO>()
                .ForMember(dto => dto.AlmacenDTO, dto => dto.MapFrom(e => e.Almacen))
                .ReverseMap();

            CreateMap<Almacen, AlmacenDTO>()
                .ForMember(dto => dto.SucursalDTO, dto => dto.MapFrom(e => e.Sucursal))
                .ForMember(dto => dto.EditAction, opt => opt.Ignore())
                .ReverseMap();


            CreateMap<Periodo, PeriodoDTO>();

            CreateMap<Menu, MenuDTO>().ReverseMap();

            CreateMap<TipoMovimiento, TipoMovimientoDTO>()
                .ReverseMap();

            CreateMap<TipoOperacion, TipoOperacionDTO>().ReverseMap();
                     // .ForMember(dto => dto.TipoMovimientoDTO, dto => dto.MapFrom(e => e.TipoMovimiento));


            CreateMap<Tabla, TablaDTO>().ReverseMap();

            CreateMap<PeriodoEmpresa, PeriodoEmpresaDTO>()
                 .ForMember(dto => dto.PeriodoDTO, dto => dto.MapFrom(e => e.Periodo));
                 //.ForMember(dto => dto.SucursalDTO, dto => dto.MapFrom(e => e.Sucursal));

            CreateMap<PeriodoCorrelativo, PeriodoCorrelativoDTO>()
                .ForMember(dto => dto.PeriodoEmpresaDTO, dto => dto.MapFrom(e => e.PeriodoEmpresa))
                .ForMember(dto => dto.TablaDTO, dto => dto.MapFrom(e => e.Tabla));


            CreateMap<Categoria, CategoriaDTO>()
                   .ForMember(dto => dto.EditAction, opt => opt.Ignore());

            CreateMap<Pais, PaisDTO>();

            CreateMap<TipoExistencia, TipoExistenciaDTO>();

            CreateMap<Departamento, DepartamentoDTO>()
             .ForMember(dto => dto.PaisDTO, dto => dto.MapFrom(e => e.Pais));

            CreateMap<Provincia, ProvinciaDTO>()
               .ForMember(dto => dto.DepartamentoDTO, dto => dto.MapFrom(e => e.Departamento));

            CreateMap<Distrito, DistritoDTO>()
                 .ForMember(dto => dto.ProvinciaDTO, dto => dto.MapFrom(e => e.Provincia));

            CreateMap<DocumentoIdentidad, DocumentoIdentidadDTO>();

            CreateMap<DocumentoComercial, DocumentoComercialDTO>();

            CreateMap<FormaPago, FormaPagoDTO>();

            CreateMap<UnidadMedida, UnidadMedidaDTO>();

            CreateMap<TipoUsuario, TipoUsuarioDTO>();


            CreateMap<FormaVenta, FormaVentaDTO>()
                    .ReverseMap();

            CreateMap<Proveedor, ProveedorDTO>()
               .ForMember(dto => dto.FormaVentaDTO, dto => dto.MapFrom(e => e.FormaVenta))
               .ForMember(dto => dto.DistritoDTO, dto => dto.MapFrom(e => e.Distrito))
               .ForMember(dto => dto.TipoProveedorDTO, dto => dto.MapFrom(e => e.TipoProveedor))
               .ForMember(dto => dto.DocumentoIdentidadDTO, dto => dto.MapFrom(e => e.DocumentoIdentidad))
               .ForMember(dto => dto.PersonalDTO, dto => dto.MapFrom(e => e.Personal))
               .ForMember(dto => dto.MonedaDTO, dto => dto.MapFrom(e => e.Moneda))
               .ForMember(dto => dto.TipoPrecioDTO, dto => dto.MapFrom(e => e.TipoPrecio))
               .ForMember(dto => dto.EditAction, opt => opt.Ignore())
               .ForMember(dto => dto.DireccionDTO, opt => opt.Ignore())
               .ForMember(dto => dto.DireccionDTOList, opt => opt.Ignore())
               .ForMember(dto => dto.ContactoDTOList, opt => opt.Ignore());

            CreateMap<TipoProveedor, TipoProveedorDTO>();


            CreateMap<Sucursal, SucursalDTO>()
                  .ForMember(dto => dto.EmpresaDTO, dto => dto.MapFrom(e => e.Empresa))
                  .ForMember(dto => dto.DistritoDTO, dto => dto.MapFrom(e => e.Distrito))
                  .ForMember(dto => dto.EditAction, opt => opt.Ignore());

            CreateMap<Empresa, EmpresaDTO>()
                 .ForMember(dto => dto.EditAction, opt => opt.Ignore());


            CreateMap<Personal, PersonalDTO>()
                   .ForMember(dto => dto.UsuarioDTO, opt => opt.Ignore())
                   .ForMember(dto => dto.Usuario, opt => opt.Ignore())
                   .ForMember(dto => dto.Password, opt => opt.Ignore())
                   .ForMember(dto => dto.EditAction, opt => opt.Ignore())
                   .ForMember(dto => dto.SucursalId, opt => opt.Ignore());

            CreateMap<Usuario, UsuarioDTO>()
                 .ForMember(dto => dto.SucursalDTO, opt => opt.Ignore())
                 .ForMember(dto => dto.PersonalDTO, dto => dto.MapFrom(e => e.Personal));


            CreateMap<BienServicio, BienServicioDTO>()
                 .ForMember(dto => dto.MonedaDTO, dto => dto.MapFrom(e => e.Moneda))
                 .ForMember(dto => dto.UnidadMedidaDTO, dto => dto.MapFrom(e => e.UnidadMedida))
                 .ForMember(dto => dto.LineaDTO, dto => dto.MapFrom(e => e.Linea))
                 .ForMember(dto => dto.CategoriaDTO, dto => dto.MapFrom(e => e.Categoria))
                 .ForMember(dto => dto.ProveedorDTO, dto => dto.MapFrom(e => e.Proveedor))
                 .ForMember(dto => dto.MarcaDTO, dto => dto.MapFrom(e => e.Marca))
                 .ForMember(dto => dto.TipoBienDTO, dto => dto.MapFrom(e => e.TipoBien))
                 .ForMember(dto => dto.EditAction, opt => opt.Ignore());

            CreateMap<Orden, OrdenDTO>()
                   .ForMember(dto => dto.DocumentoComercialDTO, dto => dto.MapFrom(e => e.DocumentoComercial))
                   //.ForMember(dto => dto.PersonalDTO, dto => dto.MapFrom(e => e.Personal))
                   //.ForMember(dto => dto.PeriodoEmpresaDTO, dto => dto.MapFrom(e => e.PeriodoEmpresa))
                   //.ForMember(dto => dto.FormaPagoDTO, dto => dto.MapFrom(e => e.FormaPago))
                   .ForMember(dto => dto.TipoOperacionDTO, dto => dto.MapFrom(e => e.TipoOperacion))
                   .ForMember(dto => dto.ProveedorDTO, dto => dto.MapFrom(e => e.Proveedor));
                   //.ForMember(dto => dto.MonedaDTO, dto => dto.MapFrom(e => e.Moneda))
                   //.ForMember(dto => dto.AlmacenDTO, dto => dto.MapFrom(e => e.Almacen))
                   //.ForMember(dto => dto.MesContableDTO, dto => dto.MapFrom(e => e.MesContable))
                   //.ForMember(dto => dto.ConductorDTO, dto => dto.MapFrom(e => e.Conductor))
                   //.ForMember(dto => dto.VehiculoDTO, dto => dto.MapFrom(e => e.Vehiculo))
                   ////.ForMember(dto => dto.EmpresaDTO, dto => dto.MapFrom(e => e.Empresa))
                   //.ForMember(dto => dto.TipoPrecioDTO, dto => dto.MapFrom(e => e.TipoPrecio))
                   //.ForMember(dto => dto.ImpuestoDTO, dto => dto.MapFrom(e => e.Impuesto))
                   //.ForMember(dto => dto.EditAction, opt => opt.Ignore())
                   //.ForMember(dto => dto.NumeroRuc, opt => opt.Ignore())
                   //.ForMember(dto => dto.RazonSocial, opt => opt.Ignore())
                   //.ForMember(dto => dto.OrderItemList, opt => opt.Ignore())
                   //.ForMember(dto => dto.OperacionFlag, opt => opt.Ignore())
                   //.ForMember(dto => dto.Direccion, opt => opt.Ignore());

            CreateMap<OrdenItem, OrdenItemDTO>()
                 .ForMember(dto => dto.PedidoDTO, dto => dto.MapFrom(e => e.Orden))
                 .ForMember(dto => dto.BienServicioDTO, dto => dto.MapFrom(e => e.BienServicio));

            CreateMap<OrdenSaldo, OrdenSaldoDTO>()
                  .ForMember(dto => dto.AlmacenDTO, dto => dto.MapFrom(e => e.Almacen))
                  .ForMember(dto => dto.BienServicioDTO, dto => dto.MapFrom(e => e.BienServicio))
                  .ForMember(dto => dto.MesContableDTO, dto => dto.MapFrom(e => e.MesContable))
                  .ForMember(dto => dto.PeriodoEmpresaDTO, dto => dto.MapFrom(e => e.PeriodoEmpresa))
                  .ReverseMap();

        }
    }
}