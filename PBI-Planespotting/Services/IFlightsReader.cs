using PBI_Planespotting.Models;

namespace PBI_Planespotting.Services
{
    public interface IFlightsReader
    {
        public Task<List<Flight>> Get();
    }
}
