using LoanProcessingApi.Models;
using LoanProcessingApi.Services;
using QuestPDF.Infrastructure;

namespace LoanProcessingApi.Tests
{
    public class ApprovalLetterServiceTests
    {
        public ApprovalLetterServiceTests()
        {
            QuestPDF.Settings.License = LicenseType.Evaluation;
        }

        [Fact]
        public void ApprovalLetterService_SuccessAndPdf()
        {
            // Arrange
            var service = new ApprovalLetterService();
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
                RequestedLoanAmount = 10000,
                Status = ApplicationStatus.Approved,
                InterestRate = 9.5m
            };

            // Act
            var res = service.GenerateLetter(app);

            // Assert
            Assert.True(res.Success);
            Assert.NotNull(res.PdfBytes);
            Assert.NotEmpty(res.PdfBytes);
        }

        [Fact]
        public void ApprovalLetterService_FailureAndErrorMessage()
        {
            // Arrange
            var service = new ApprovalLetterService();
            var app = new Application
            {
                BorrowerName = "Test User",
                RequestedLoanAmount = 10000,
            };

            // Act
            var res = service.GenerateLetter(app);

            // Assert
            Assert.False(res.Success);
            Assert.NotNull(res.ErrorMessage);
            Assert.Null(res.PdfBytes);
        }
    }
}
