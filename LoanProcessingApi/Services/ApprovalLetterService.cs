using LoanProcessingApi.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace LoanProcessingApi.Services
{
    public class ApprovalLetterService
    {
        public GenerateLetterResult GenerateLetter(Application app)
        {
            var res = new GenerateLetterResult();
            try
            {
                res.PdfBytes = Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(20));

                        string text = "";

                        text = app.BorrowerName + "\n"
                            + app.BorrowerAddress.Street + " " + app.BorrowerAddress.City + ", " + app.BorrowerAddress.State + " " + app.BorrowerAddress.Zip + "\n" + "\n"
                            + app.RequestedLoanAmount.ToString() + "\n"
                            + app.InterestRate.ToString();

                        page.Header()
                            .Text("Loan Application")
                            .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                        page.Content()
                            .PaddingVertical(1, Unit.Centimetre)
                            .Column(x =>
                            {
                                x.Spacing(20);

                                x.Item().Text(text);
                            });

                    });
                }).GeneratePdf();
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.ToString();
                res.Success = false;
                return res;
            }
            res.Success = true;
            return res;


        }
    }
}
