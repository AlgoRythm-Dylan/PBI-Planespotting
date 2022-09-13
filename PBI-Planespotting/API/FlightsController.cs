using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBI_Planespotting.Services;

namespace PBI_Planespotting.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightsReader Flights;
        public FlightsController(IFlightsReader flights)
        {
            Flights = flights;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await Flights.Get());
        }
    }
}
