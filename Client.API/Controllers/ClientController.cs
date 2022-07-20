using Microsoft.AspNetCore.Mvc;

namespace Client.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        [HttpGet("all")]
        public IEnumerable<string> Get()
        {
            return new List<string>();
        }
    }
}