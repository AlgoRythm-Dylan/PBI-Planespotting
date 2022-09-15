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
        public List<APIFlight> flight { get; set; }
    }
    #endregion
    #region Raw Response Object
    public class APIFlight
    {
        public string? Type { get; set; }
        public string? Rec { get; set; }
        public string? An { get; set; }
        public string? Ac { get; set; }
        public string? Flt { get; set; }
        public string? City { get; set; }
        public string? CC { get; set; }
        public string? Date { get; set; }
        public string? Sked { get; set; }
        public string? Gate { get; set; }
        public string? Rem { get; set; }
        public string? Bag { get; set; }
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
