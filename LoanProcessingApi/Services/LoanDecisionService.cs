using LoanProcessingApi.Models;

namespace LoanProcessingApi.Services
{
    public class LoanDecisionService
    {
        public void EvaluateApplication(Application app)
        {
            if(app.RequestedLoanAmount < 10000)
            {
                app.Status = ApplicationStatus.Rejected;
                app.DecisionReason = "Loan amount must be at least 10000.";
                return;
            }
            else if(app.RequestedLoanAmount < 25000)
            {
                app.InterestRate = 9.5m;
            }
            else if( app.RequestedLoanAmount < 50000)
            {
                app.InterestRate = 8m;
            }
            else
            {
                app.InterestRate = 6.5m;
            }
            app.Status = ApplicationStatus.Approved;
        }
    }
}
