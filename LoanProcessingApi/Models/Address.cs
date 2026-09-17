using System.ComponentModel.DataAnnotations;

namespace LoanProcessingApi.Models
{
    public class Address
    {
        [Required]
        public required string Street { get; set; }
        [Required]
        public required string City { get; set; }
        [Required]
        public required string State { get; set; }
        [Required]
        public required string Zip { get;  set; }
    }
}
