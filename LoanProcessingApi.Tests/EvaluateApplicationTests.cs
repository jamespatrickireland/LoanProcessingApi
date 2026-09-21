using LoanProcessingApi.Services;
using LoanProcessingApi.Models;


namespace LoanProcessingApi.Tests
{
    public class EvaluateApplicationTests
    {
        [Fact]
        public void EvaluateApplication_AmountBelow10000_RejectsApplication()
        {
            // Arrange
            var service = new LoanDecisionService();
            var app = new Application
            {
                BorrowerName = "Test User",
                BorrowerAddress = new Address
                {
                    Street = "1 Main St",
                    City = "Test City",
                    State = "CA",
                    Zip = "55555"
                },
                RequestedLoanAmount = 9999
            };

            // Act
            service.EvaluateApplication(app);

            // Assert
            Assert.Equal(ApplicationStatus.Rejected, app.Status);
            Assert.Equal("Loan amount must be at least 10000.", app.DecisionReason);
        }

        [Theory]
        [InlineData(10000,9.5)]
        [InlineData(24999,9.5)]
        [InlineData(25000,8)]
        [InlineData(49999, 8)]
        [InlineData(50000, 6.5)]
        public void EvaluateApplication_ApprovedBoundaries_ReturnExpectedRate(int requestedAmount,double expectedRate)
        {
            // Arrange
            var service = new LoanDecisionService();
            var app = new Application
            {
                BorrowerName = "Test User",
                BorrowerAddress = new Address
                {
                    Street = "1 Main St",
                    City = "Test City",
                    State = "CA",
                    Zip = "55555"
                },
                RequestedLoanAmount = requestedAmount
            };

            // Act
            service.EvaluateApplication(app);

            // Assert
            Assert.Equal(ApplicationStatus.Approved, app.Status);
            Assert.Equal((decimal)expectedRate, app.InterestRate);
        }

    }
}