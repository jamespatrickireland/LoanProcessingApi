namespace LoanProcessingApi.Models
{
    public class GenerateLetterResult
    {
        public bool Success { get; set; }
        public byte[]? PdfyBytes { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
