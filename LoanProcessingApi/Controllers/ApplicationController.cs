using LoanProcessingApi.Data;
using LoanProcessingApi.DTOs;
using LoanProcessingApi.Models;
using LoanProcessingApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LoanProcessingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
       
        private readonly ILogger<ApplicationController> _logger;
        private readonly LoanDecisionService _loanDecision;
        private readonly ApprovalLetterService _appLetter;
        private readonly ApplicationDbContext _dbContext;

        public ApplicationController(LoanDecisionService loanDec,ApprovalLetterService appLetter,ApplicationDbContext dbContext,ILogger<ApplicationController> logger)
        {
            _dbContext = dbContext;
            _loanDecision = loanDec;
            _appLetter = appLetter;
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
            _loanDecision.EvaluateApplication(app);

            _dbContext.Applications.Add(app);
            await _dbContext.SaveChangesAsync();

            var res = CreateResponse(app);
            return Ok(res);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            var app = await _dbContext.Applications.FirstOrDefaultAsync(a => a.Id == id);
            if(app == null)
            {
                return NotFound(id + " was not found");
            }
            var res = CreateResponse(app);
            return Ok(res);
        }

        [HttpPost("GenerateApprovalLetter/{id}")]
        public async Task<IActionResult> GenerateApprovalLetter(int id)
        {
            var app = await _dbContext.Applications.FirstOrDefaultAsync(a => a.Id == id);
            if(app == null)
            {
                return NotFound(id + " was not found");
            }
            else if(app.Status != ApplicationStatus.Approved)
            {
                return Conflict("This application was rejected.");
            }
            else
            {
                var result = _appLetter.GenerateLetter(app);
                if (!result.Success || result.PdfBytes == null)
                {
                    return StatusCode(500,result.ErrorMessage);
                }

                return File(result.PdfBytes,"application/pdf","ApprovalLetter.pdf");
            }
            
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

        private ApplicationResponse CreateResponse(Application app)
        {
            return new ApplicationResponse()
            {
                Id = app.Id,
                RequestedLoanAmount = app.RequestedLoanAmount,
                BorrowerAddress = app.BorrowerAddress,
                BorrowerName = app.BorrowerName,
                InterestRate = app.InterestRate,
                DecisionReason = app.DecisionReason,
                Status = app.Status,
                CreatedDate = app.CreatedDate,
            };
        }
    }
}
