using Autofac;
using Blotter.Domain.Interfaces;
using Blotter.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blotter.Domain.Ioc
{
    public class DomainLayerModule: Module
    {
        public DomainLayerModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CountryRepository>().As<ICountryRepository>().InstancePerDependency();
            builder.RegisterType<StateRepository>().As<IStateRepository>().InstancePerDependency();
        }
    }
}
