using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankLendingPortal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerMasters",
                columns: table => new
                {
                    CustId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CustFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    AadharCard = table.Column<int>(type: "int", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonthlySalary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMasters", x => x.CustId);
                });

            migrationBuilder.CreateTable(
                name: "LoanAppMasters",
                columns: table => new
                {
                    LoanAppId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InterestRate = table.Column<int>(type: "int", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanAppMasters", x => x.LoanAppId);
                });

            migrationBuilder.CreateTable(
                name: "LoanMaster",
                columns: table => new
                {
                    LoanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Typeofloan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterestRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanMaster", x => new { x.LoanId, x.Typeofloan, x.DateOfCreation });
                });

            migrationBuilder.CreateTable(
                name: "PaymentTracks",
                columns: table => new
                {
                    PaymentTrackId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoanAppId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Month_no = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDateOfPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentRecieveDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTracks", x => x.PaymentTrackId);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplications",
                columns: table => new
                {
                    LoanAppId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustId = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    LoanAmt = table.Column<int>(type: "int", nullable: false),
                    NoOfYears = table.Column<int>(type: "int", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfLoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanAppDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplications", x => x.LoanAppId);
                    table.ForeignKey(
                        name: "FK_LoanApplications_CustomerMasters_CustId",
                        column: x => x.CustId,
                        principalTable: "CustomerMasters",
                        principalColumn: "CustId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditRisks",
                columns: table => new
                {
                    CrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanAppId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreditScore = table.Column<int>(type: "int", nullable: false),
                    Emi = table.Column<int>(type: "int", nullable: false),
                    BasicCheck = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditRisks", x => x.CrId);
                    table.ForeignKey(
                        name: "FK_CreditRisks_LoanApplications_LoanAppId",
                        column: x => x.LoanAppId,
                        principalTable: "LoanApplications",
                        principalColumn: "LoanAppId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanAppDetailMasters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoanAppId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MonthNo = table.Column<int>(type: "int", nullable: false),
                    Installment = table.Column<int>(type: "int", nullable: false),
                    InterestRate = table.Column<int>(type: "int", nullable: false),
                    POutStandingBeginOfMon = table.Column<int>(type: "int", nullable: false),
                    PRepayment = table.Column<int>(type: "int", nullable: false),
                    PrOutStandingEndOfMon = table.Column<int>(type: "int", nullable: false),
                    LastDateofinstallPay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanAppDetailMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanAppDetailMasters_LoanApplications_LoanAppId",
                        column: x => x.LoanAppId,
                        principalTable: "LoanApplications",
                        principalColumn: "LoanAppId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanAppDetailMasters_LoanAppMasters_LoanAppId",
                        column: x => x.LoanAppId,
                        principalTable: "LoanAppMasters",
                        principalColumn: "LoanAppId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditRisks_LoanAppId",
                table: "CreditRisks",
                column: "LoanAppId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanAppDetailMasters_LoanAppId",
                table: "LoanAppDetailMasters",
                column: "LoanAppId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_CustId",
                table: "LoanApplications",
                column: "CustId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditRisks");

            migrationBuilder.DropTable(
                name: "LoanAppDetailMasters");

            migrationBuilder.DropTable(
                name: "LoanMaster");

            migrationBuilder.DropTable(
                name: "PaymentTracks");

            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropTable(
                name: "LoanAppMasters");

            migrationBuilder.DropTable(
                name: "CustomerMasters");
        }
    }
}
