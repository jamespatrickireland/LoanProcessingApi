using LoanProcessingApi.Models;
using System.ComponentModel.DataAnnotations;

namespace LoanProcessingApi.DTOs
{
    public class CreateApplicationRequest
    {
        [Required]
        public required string BorrowerName { get; set; }
        [Required]
        public required Address BorrowerAddress { get; set; }
        public decimal RequestedLoanAmount { get; set; }


    }
}
