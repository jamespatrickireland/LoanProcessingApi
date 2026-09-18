using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanProcessingApi.Migrations
{
    /// <inheritdoc />
    public partial class AddDecisionReasonToApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DecisionReason",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DecisionReason",
                table: "Applications");
        }
    }
}
