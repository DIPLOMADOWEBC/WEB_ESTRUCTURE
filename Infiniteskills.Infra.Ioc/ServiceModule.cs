using Autofac;
using Infiniteskills.Common;
using Infiniteskills.Infra.Base;
using Infiniteskills.Service;

namespace Infiniteskills.Infra.Ioc
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Dependency register for service
            //builder.RegisterGeneric(typeof(ServiceBase<>)).As(typeof(IServiceBase<>)).InstancePerDependency();
            builder.RegisterType<PeriodoService>().As<IPeriodoService>().InstancePerLifetimeScope();
            builder.RegisterType<PeriodoEmpresaService>().As<IPeriodoEmpresaService>().InstancePerLifetimeScope();
            builder.RegisterType<TablaService>().As<ITablaService>().InstancePerLifetimeScope();
            builder.RegisterType<PeriodoCorrelativoService>().As<IPeriodoCorrelativoService>().InstancePerLifetimeScope();
            builder.RegisterType<EmpresaService>().As<IEmpresaService>().InstancePerLifetimeScope();
            builder.RegisterType<SucursalService>().As<ISucursalService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoriaService>().As<ICategoriaService>().InstancePerLifetimeScope();
            builder.RegisterType<ProveedorService>().As<IProveedorService>().InstancePerLifetimeScope();
            builder.RegisterType<TipoProveedorService>().As<ITipoProveedorService>().InstancePerLifetimeScope();
            builder.RegisterType<DocumentoIdentidadService>().As<IDocumentoIdentidadService>().InstancePerLifetimeScope();
            builder.RegisterType<DocumentoComercialService>().As<IDocumentoComercialService>().InstancePerLifetimeScope();
            builder.RegisterType<PaisService>().As<IPaisService>().InstancePerLifetimeScope();
            builder.RegisterType<DepartamentoService>().As<IDepartamentoService>().InstancePerLifetimeScope();
            builder.RegisterType<ProvinciaService>().As<IProvinciaService>().InstancePerLifetimeScope();
            builder.RegisterType<DistritoService>().As<IDistritoService>().InstancePerLifetimeScope();
            builder.RegisterType<TipoExistenciaService>().As<ITipoExistenciaService>().InstancePerLifetimeScope();
            builder.RegisterType<BienServicioService>().As<IBienServicioService>().InstancePerLifetimeScope();
            builder.RegisterType<UnidadMedidaService>().As<IUnidadMedidaService>().InstancePerLifetimeScope();
            builder.RegisterType<TipoUsuarioService>().As<ITipoUsuarioService>().InstancePerLifetimeScope();
            builder.RegisterType<PersonalService>().As<IPersonalService>().InstancePerLifetimeScope();
            builder.RegisterType<OrdenService>().As<IOrdenService>().InstancePerLifetimeScope();
            builder.RegisterType<OrdenItemService>().As<IOrdenItemService>().InstancePerLifetimeScope();
            builder.RegisterType<FormaPagoService>().As<IFormaPagoService>().InstancePerLifetimeScope();
            builder.RegisterType<MarcaService>().As<IMarcaService>().InstancePerLifetimeScope();
            builder.RegisterType<TipoOperacionService>().As<ITipoOperacionService>().InstancePerLifetimeScope();
            builder.RegisterType<UsuarioService>().As<IUsuarioService>().InstancePerLifetimeScope();
            builder.RegisterType<UserManager>().As<IUserManager>().InstancePerLifetimeScope();
            builder.RegisterType<MenuService>().As<IMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<MonedaService>().As<IMonedaService>().InstancePerLifetimeScope();
            builder.RegisterType<AlmacenService>().As<IAlmacenService>().InstancePerLifetimeScope();
            builder.RegisterType<SerieService>().As<ISerieService>().InstancePerLifetimeScope();
            builder.RegisterType<ParametroSistemaService>().As<IParametroSistemaService>().InstancePerLifetimeScope();
            builder.RegisterType<FormaVentaService>().As<IFormaVentaService>().InstancePerLifetimeScope();
            builder.RegisterType<DireccionService>().As<IDireccionService>().InstancePerLifetimeScope();
            builder.RegisterType<ContactoService>().As<IContactoService>().InstancePerLifetimeScope();
            builder.RegisterType<ProveedorContactoService>().As<IProveedorContactoService>().InstancePerLifetimeScope();
            builder.RegisterType<SucursalUsuarioService>().As<ISucursalUsuarioService>().InstancePerLifetimeScope();
            builder.RegisterType<TipoPrecioService>().As<ITipoPrecioService>().InstancePerLifetimeScope();
            builder.RegisterType<AreaService>().As<IAreaService>().InstancePerLifetimeScope();
            builder.RegisterType<TipoBienService>().As<ITipoBienService>().InstancePerLifetimeScope();
            builder.RegisterType<OrdenSaldoService>().As<IOrdenSaldoService>().InstancePerLifetimeScope();
            builder.RegisterType<MesContableService>().As<IMesContableService>().InstancePerLifetimeScope();
            builder.RegisterType<LineaService>().As<ILineaService>().InstancePerLifetimeScope();
            builder.RegisterType<TipoMovimientoService>().As<ITipoMovimientoService>().InstancePerLifetimeScope();
            builder.RegisterType<ImpuestoService>().As<IImpuestoService>().InstancePerLifetimeScope();
            //Service client
            builder.RegisterType<ServiceClient>().As<IServiceClient>().InstancePerLifetimeScope();
            builder.RegisterType<SunatClient>().As<ISunatClient>().InstancePerLifetimeScope();

      
            
        }
    }
}
