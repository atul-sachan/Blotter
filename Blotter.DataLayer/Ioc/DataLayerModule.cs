﻿using Autofac;
using Autofac.Core;
using Blotter.DataLayer.Mongo;
using Blotter.DataLayer.Mongo.Mapping;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blotter.DataLayer.Ioc
{
    
    public class DataLayerModule: Module
    {
        public DataLayerModule()
        {
            
        }

        protected override void Load(ContainerBuilder builder)
        {
            MongoDatabaseDependency(builder);
            
        }

        private void MongoDatabaseDependency(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(MongoRepository<>))
                                    .As(typeof(IRepository<>))
                                    .WithParameter("connectionId", "MongoConnection")
                                    .InstancePerDependency();

            builder.RegisterGeneric(typeof(MongoRepository<>))
                                    .As(typeof(IRepository<>))
                                    .WithParameter("connectionId", "MongoConnection1")
                                    .InstancePerDependency();
            MongoClassMap.Instance();
        }
    }
}
