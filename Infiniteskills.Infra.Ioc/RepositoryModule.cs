using Autofac;
using Infiniteskills.Infra.Core;
using Infiniteskills.Repository;

namespace Infiniteskills.Infra.Ioc
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Dependency register for repository
            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepositoryBase<>)).InstancePerDependency();
            builder.RegisterType<OrdenRepository>().As<IOrdenRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PeriodoRepository>().As<IPeriodoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PeriodoEmpresaRepository>().As<IPeriodoEmpresaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TablaRepository>().As<ITablaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PeriodoCorrelativoRepository>().As<IPeriodoCorrelativoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EmpresaRepository>().As<IEmpresaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SucursalRepository>().As<ISucursalRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoriaRepository>().As<ICategoriaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProveedorRepository>().As<IProveedorRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TipoProveedorRepository>().As<ITipoProveedorRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DocumentoIdentidadRepository>().As<IDocumentoIdentidadRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DocumentoComercialRepository>().As<IDocumentoComercialRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PaisRepository>().As<IPaisRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DepartamentoRepository>().As<IDepartamentoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProvinciaRepository>().As<IProvinciaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DistritoRepository>().As<IDistritoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TipoExistenciaRepository>().As<ITipoExistenciaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<BienServicioRepository>().As<IBienServicioRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UnidadMedidaRepository>().As<IUnidadMedidaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PersonalRepository>().As<IPersonalRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TipoUsuarioRepository>().As<ITipoUsuarioRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrdenRepository>().As<IOrdenRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrdenItemRepository>().As<IOrdenItemRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FormaPagoRepository>().As<IFormaPagoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FormaVentaRepository>().As<IFormaVentaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MarcaRepository>().As<IMarcaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TipoOperacionRepository>().As<ITipoOperacionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DireccionRepository>().As<IDireccionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TipoPrecioRepository>().As<ITipoPrecioRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AreaRepository>().As<IAreaRepository>().InstancePerLifetimeScope();

            builder.RegisterType<MonedaRepository>().As<IMonedaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MenuRepository>().As<IMenuRepository>().InstancePerLifetimeScope();

            builder.RegisterType<AlmacenRepository>().As<IAlmacenRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ContactoRepository>().As<IContactoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProveedorContactoRepository>().As<IProveedorContactoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TipoBienRepository>().As<ITipoBienRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrdenSaldoRepository>().As<IOrdenSaldoRepository>().InstancePerLifetimeScope();

            builder.RegisterType<SucursalUsuarioRepository>().As<ISucursalUsuarioRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MesContableRepository>().As<IMesContableRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LineaRepository>().As<ILineaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TipoMovimientoRepository>().As<ITipoMovimientoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ImpuestoRepository>().As<IImpuestoRepository>().InstancePerLifetimeScope();

            builder.RegisterType<SerieRepository>().As<ISerieRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ParametroSistemaRepository>().As<IParametroSistemaRepository>().InstancePerLifetimeScope();
        }
    }
}
