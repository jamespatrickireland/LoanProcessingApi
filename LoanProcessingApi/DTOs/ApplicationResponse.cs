using LoanProcessingApi.Models;
namespace LoanProcessingApi.DTOs
{
    public class ApplicationResponse
    {
        public int Id { get; set; }
        public ApplicationStatus Status { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string BorrowerName { get; set; }
        public Address BorrowerAddress { get; set; }
        public decimal RequestedLoanAmount { get; set; }
        public string? DecisionReason { get; set; }
    }
}
