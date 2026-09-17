namespace LoanProcessingApi.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public float InterestRate { get; set; }
        public DateOnly CreatedDate { get; set; }
    }
}
