using PBI_Planespotting.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace PBI_Planespotting.Services
{

    #region Response Hack
    /*
     * As with many "enterprise" JSON structures, the response 
     * structure is completely cursed, so the easiest thing is
     * to just do something like this.
     * 
     * Example response:
     * {
     *      "flights" : {
     *          "flight" : {
     *              [ ... list of flights ... ]
     *          }
     *      }
     * }
     * 
     */
    public class APIResponseA
    {
        public APIResponseB flights { get; set; }
    }
    public class APIResponseB
    {
        public List<Flight> flight { get; set; }
    }
    #endregion

    public class FlightsReader : IFlightsReader
    {

        private readonly HttpClient Http;
        private readonly IConfiguration Config;

        public FlightsReader(HttpClient httpClient, IConfiguration config)
        {
            Http = httpClient;
            Config = config;

            Http.BaseAddress = new Uri(Config["API:Flights"]);
            Http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<List<Flight>> Get()
        {
            var responseString = await Http.GetStringAsync("fids-pbi.json");
            var list = JsonSerializer.Deserialize<APIResponseA>(responseString,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }).flights.flight;

            return list;
        }
    }
}
