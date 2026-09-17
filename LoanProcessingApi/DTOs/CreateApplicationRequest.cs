using LoanProcessingApi.Models;
using System.ComponentModel.DataAnnotations;

namespace LoanProcessingApi.DTOs
{
    public class CreateApplicationRequest
    {
        [Required]
        string BorrowerName { get; set; }
        [Required]
        Address BorrowerAddress { get; set; }
        [Required]
        decimal RequestedLoanAmount { get; set; }


    }
}
