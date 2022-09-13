using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBI_Planespotting.Services;

namespace PBI_Planespotting.App_Start
{
    public static class DependencyMapper
    {
        public static void Map(IServiceCollection services)
        {
            services.AddHttpClient<IFlightsReader, FlightsReader>();
        }
    }
}
