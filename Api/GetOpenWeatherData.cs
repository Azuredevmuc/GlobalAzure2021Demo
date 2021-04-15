using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace BlazorApp.Api
{
    public static class GetOpenWeatherData
    {
        static HttpClient client = new HttpClient();

        [FunctionName("GetOpenWeatherData")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            //Get Wether Data of Munich
            var response = await client.GetAsync("https://api.openweathermap.org/data/2.5/onecall?lat=48.185777668797314&lon=11.56213033944366&exclude=minutely&appid=d5b5f7f03277369073f4155416a6a067&units=metric");
            var result = await response.Content.ReadAsStringAsync();
            return new OkObjectResult(JsonConvert.DeserializeObject(result));
        }
    }
}