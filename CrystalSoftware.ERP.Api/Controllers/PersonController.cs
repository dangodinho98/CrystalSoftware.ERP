using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrystalSoftware.ERP.Api.Controllers
{
    [Route("api/person")]
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }
    }
}
