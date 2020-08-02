namespace Infiniteskills.Service
{
    public static class ConfigureAutoMapper
    {

        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new DomainToModelMappingConfig());
                cfg.AddProfile(new ModelToDomainMappingConfig());
            });

            //AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}
