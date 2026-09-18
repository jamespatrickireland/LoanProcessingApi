using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanProcessingApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BorrowerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedLoanAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    BorrowerAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorrowerAddress_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorrowerAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorrowerAddress_Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
