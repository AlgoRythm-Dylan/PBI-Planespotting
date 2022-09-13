using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PBI_Planespotting.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        [Route("textual")]
        /*
         * Provide a "textual" report (plain text)
         * so that information can be displayed in something
         * like a command prompt or even just directly
         * in a poor browser
         */
        public async Task<IActionResult> Textual()
        {
            throw new NotImplementedException();
        }
    }
}
