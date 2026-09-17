using Microsoft.AspNetCore.Mvc;
using LoanProcessingApi.DTOs;
using LoanProcessingApi.Models;
using LoanProcessingApi.Services;

namespace LoanProcessingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
       
        private readonly ILogger<ApplicationController> _logger;
        private readonly LoanDecisionService _loanDecision;

        public ApplicationController(LoanDecisionService loanDec,ILogger<ApplicationController> logger)
        {
            _loanDecision = loanDec;
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
            var dec = _loanDecision.Evaluate(app);
            return Ok(dec);
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
