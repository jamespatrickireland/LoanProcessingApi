using LoanProcessingApi.Models;
using System.ComponentModel.DataAnnotations;

namespace LoanProcessingApi.DTOs
{
    public class CreateApplicationRequest
    {
        [Required]
        public string BorrowerName { get; set; }
        [Required]
        public Address BorrowerAddress { get; set; }
        [Required]
        public decimal RequestedLoanAmount { get; set; }


    }
}
