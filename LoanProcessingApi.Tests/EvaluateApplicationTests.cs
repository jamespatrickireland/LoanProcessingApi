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
        }

        [Fact]
        public void EvaluateApplication_AmountBetween10000And25000_9_5Rate()
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
                RequestedLoanAmount = 15000
            };

            // Act
            service.EvaluateApplication(app);

            // Assert
            Assert.Equal(9.5m, app.InterestRate);
        }

        [Fact]
        public void EvaluateApplication_AmountBetween25000And50000_8Rate()
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
                RequestedLoanAmount = 30000
            };

            // Act
            service.EvaluateApplication(app);

            // Assert
            Assert.Equal(8m, app.InterestRate);
        }

        [Fact]
        public void EvaluateApplication_AmountGreater50000_6_5Rate()
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
                RequestedLoanAmount = 60000
            };

            // Act
            service.EvaluateApplication(app);

            // Assert
            Assert.Equal(6.5m, app.InterestRate);
        }
    }
}