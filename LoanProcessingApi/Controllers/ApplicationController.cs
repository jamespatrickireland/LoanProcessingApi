using Microsoft.AspNetCore.Mvc;
using LoanProcessingApi.DTOs;

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

        [HttpGet("Test")]
        public string Test()
        {
            return "LoanProcessingApi is running";
        }

        [HttpPost("CreateApplication")]
        public IActionResult CreateApplication(CreateApplicationRequest req)
        {
            return Ok();
        }
    }
}
