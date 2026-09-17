using LoanProcessingApi.Models;

namespace LoanProcessingApi.Services
{
    public class LoanDecisionService
    {
        public LoanDecision Evaluate(Application app)
        {
            var dec = new LoanDecision();
            if(app.RequestedLoanAmount < 10000)
            {
                dec.Status = ApplicationStatus.Rejected;
                dec.Reason = "Loan amount must be at least 10000.";
                return dec;
            }
            else if(app.RequestedLoanAmount < 25000)
            {
                dec.InterestRate = 9.5m;
            }
            else if( app.RequestedLoanAmount < 50000)
            {
                dec.InterestRate = 8m;
            }
            else
            {
                dec.InterestRate = 6.5m;
            }

            dec.Status = ApplicationStatus.Approved;
            return dec;
        }
    }
}
