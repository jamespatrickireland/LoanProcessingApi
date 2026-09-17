using Microsoft.AspNetCore.Mvc;

namespace LoanProcessingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
       
        private readonly ILogger<ApplicationController> _logger;

        public ApplicationController(ILogger<ApplicationController> logger)
        {
            _logger = logger;
        }

        [HttpGet("test")]
        public string test()
        {
            return "LoanProcessingApi is running";
        }
    }
}
