using LoanProcessingApi.Models;

namespace LoanProcessingApi.Services
{
    public class ApprovalLetterService
    {
        public GenerateLetterResult GenerateLetter(Application app)
        {
            var res = new GenerateLetterResult();
            res.Success = true;
            return res;


        }
    }
}
