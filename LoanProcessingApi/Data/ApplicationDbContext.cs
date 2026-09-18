using Microsoft.EntityFrameworkCore;
using LoanProcessingApi.Models;

namespace LoanProcessingApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>()
                .ComplexProperty(a => a.BorrowerAddress)
                .IsRequired();

            modelBuilder.Entity<Application>()
                .Property(a => a.RequestedLoanAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Application>()
                .Property(a => a.InterestRate)
                .HasPrecision(5, 2);
        }
    }
}
