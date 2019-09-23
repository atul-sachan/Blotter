using Autofac;
using Blotter.Business.Interfaces;
using Blotter.Business.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blotter.Business.Ioc
{
    public class ServiceLayerModule : Module
    {
        public ServiceLayerModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CountryService>().As<ICountryService>();
            builder.RegisterInstance(new LoggerFactory())
                .As<ILoggerFactory>();

            builder.RegisterGeneric(typeof(Logger<>))
                   .As(typeof(ILogger<>))
                   .SingleInstance();
            //builder.RegisterType<StateService>().As<IStateService>().InstancePerDependency();
        }
    }
}
