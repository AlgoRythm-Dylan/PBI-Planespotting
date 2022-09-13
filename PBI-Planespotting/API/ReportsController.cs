using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PBI_Planespotting.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        [Route("textual")]
        public async Task<IActionResult> Textual()
        {
            throw new NotImplementedException();
        }
    }
}
