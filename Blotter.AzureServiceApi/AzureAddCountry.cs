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
using Blotter.AzureServiceApi.Infrastructure;
using Blotter.Business.Interfaces;
using System.Net.Http;
using System.Net;
using Blotter.Business.Models;

namespace Blotter.AzureServiceApi
{
    [DependencyInjectionConfig(typeof(DependencyContainer))]
    public static class AzureAddCountry
    {
        [FunctionName("AzureAddCountry")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log, [Inject] ICountryService countryService)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<CountryModel>(requestBody);
            countryService.Add(data);
            
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent($"Hello, {name}")
            };

        }
    }
}
