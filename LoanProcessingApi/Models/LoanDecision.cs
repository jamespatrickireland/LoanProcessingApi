namespace LoanProcessingApi.Models
{
    public class LoanDecision
    {
        public ApplicationStatus Status { get; set; }
        public decimal InterestRate { get; set; }
        public string? Reason { get; set; }
    }
}
