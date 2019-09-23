using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureFunctions.Autofac;
using System.Net.Http;
using System.Net;
using Blotter.Business.Interfaces;
using Blotter.AzureServiceApi.Infrastructure;

namespace Blotter.AzureServiceApi
{
    [DependencyInjectionConfig(typeof(DIConfig))]
    public static class AnnouncerFunction
    {
        [FunctionName("AnnouncerFunction")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log,[Inject] IAnnouncer announcer)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent($"Base Directory is: {announcer.Announce()}")
            };
        }
    }
}
