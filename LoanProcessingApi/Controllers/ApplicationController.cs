using Microsoft.AspNetCore.Mvc;
using LoanProcessingApi.DTOs;
using LoanProcessingApi.Models;

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

        [HttpPost("Create")]
        public IActionResult CreateApplication(CreateApplicationRequest req)
        {
            var app = MapToApplication(req);
            return Ok();
        }

        private Application MapToApplication(CreateApplicationRequest req)
        {
            return new Application()
            {
                RequestedLoanAmount = req.RequestedLoanAmount,
                BorrowerAddress = req.BorrowerAddress,
                BorrowerName = req.BorrowerName
            };
        }
    }
}
