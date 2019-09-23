using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using AzureFunctions.Autofac.Configuration;
using Blotter.Business.Mappings;
using Blotter.DataLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Blotter.AzureServiceApi.Infrastructure
{
    public class DependencyContainer
    {
        public IContainer ApplicationContainer { get; set; }
        public DependencyContainer(string functionName)
        {
            

            DependencyInjection.Initialize(builder =>
            {
                var services = new ServiceCollection();
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                var mapperConfig = new MapperConfiguration(config =>
                        {
                            config.AddProfile<MappingProfile>();
                        });

                IMapper mapper = mapperConfig.CreateMapper();
                services.AddSingleton(mapper);
                services.BuildServiceProvider();
                builder.RegisterModule(new Business.Ioc.ServiceLayerModule());
                builder.RegisterModule(new Domain.Ioc.DomainLayerModule());
                builder.RegisterModule(new DataLayer.Ioc.DataLayerModule());
                builder.Populate(services);


            }, functionName);

            //var builder2 = new ContainerBuilder();
            //builder2.RegisterInstance(ApplicationContainer).As<IContainer>();
            //builder2.RegisterGeneric(typeof(DatabaseHelper<>))
            //                        .As(typeof(IDatabaseHelper<>))
            //                        .WithParameter(new ResolvedParameter(
            //                                (pi, ctx) => pi.ParameterType == typeof(IContainer) && pi.Name == "container",
            //                                (pi, ctx) => ApplicationContainer
            //                        ));

            //builder2.Update(ApplicationContainer);
        }
    }

    
}
