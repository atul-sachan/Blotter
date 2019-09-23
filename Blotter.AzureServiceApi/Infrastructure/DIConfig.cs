using Autofac;
using AzureFunctions.Autofac.Configuration;
using Blotter.Business.Interfaces;
using Blotter.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blotter.AzureServiceApi.Infrastructure
{
    public class DIConfig
    {
        public DIConfig(string functionName, string baseDirectory)
        {
            DependencyInjection.Initialize(builder =>
            {
                //builder.RegisterModule(new TestModule());
                builder.Register<DirectoryAnnouncer>(c => new DirectoryAnnouncer(baseDirectory)).As<IAnnouncer>();
            }, functionName);
        }
    }
}
