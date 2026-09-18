using Microsoft.AspNetCore.Mvc;
using LoanProcessingApi.DTOs;
using LoanProcessingApi.Models;
using LoanProcessingApi.Services;
using LoanProcessingApi.Data;
using System.Threading.Tasks;

namespace LoanProcessingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
       
        private readonly ILogger<ApplicationController> _logger;
        private readonly LoanDecisionService _loanDecision;
        private readonly ApplicationDbContext _dbContext;

        public ApplicationController(LoanDecisionService loanDec,ApplicationDbContext dbContext,ILogger<ApplicationController> logger)
        {
            _dbContext = dbContext;
            _loanDecision = loanDec;
            _logger = logger;
        }

        [HttpGet("Test")]
        public string Test()
        {
            return "LoanProcessingApi is running";
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateApplication(CreateApplicationRequest req)
        {
            var app = MapToApplication(req);
            var dec = _loanDecision.Evaluate(app);
            _dbContext.Applications.Add(app);
            await _dbContext.SaveChangesAsync();

            var res = CreateResponse(app, dec);
            return Ok(res);
        }

        private Application MapToApplication(CreateApplicationRequest req)
        {
            return new Application()
            { 
                RequestedLoanAmount = req.RequestedLoanAmount,
                BorrowerAddress = req.BorrowerAddress,
                BorrowerName = req.BorrowerName,
                CreatedDate = DateTime.UtcNow
            };
        }

        private ApplicationResponse CreateResponse(Application app,LoanDecision dec)
        {
            return new ApplicationResponse()
            {
                Id = app.Id,
                RequestedLoanAmount = app.RequestedLoanAmount,
                BorrowerAddress = app.BorrowerAddress,
                BorrowerName = app.BorrowerName,
                InterestRate = dec.InterestRate,
                Status = dec.Status,
                CreatedDate = app.CreatedDate,
            };
        }
    }
}
