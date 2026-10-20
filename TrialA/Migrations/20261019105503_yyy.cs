using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrialA.Migrations
{
    /// <inheritdoc />
    public partial class yyy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CeratedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CandidateProfiles",
                columns: table => new
                {
                    CandidateProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skill = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    YearOfExperience = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateProfiles", x => x.CandidateProfileId);
                    table.ForeignKey(
                        name: "FK_CandidateProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Jops",
                columns: table => new
                {
                    JopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeType = table.Column<int>(type: "int", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jops", x => x.JopId);
                    table.ForeignKey(
                        name: "FK_Jops_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "CompanyId");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CoverLetter = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CandidateProfileId = table.Column<int>(type: "int", nullable: false),
                    JopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Applications_CandidateProfiles_CandidateProfileId",
                        column: x => x.CandidateProfileId,
                        principalTable: "CandidateProfiles",
                        principalColumn: "CandidateProfileId");
                    table.ForeignKey(
                        name: "FK_Applications_Jops_JopId",
                        column: x => x.JopId,
                        principalTable: "Jops",
                        principalColumn: "JopId");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CeratedAt", "Email", "FullName", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(1905, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed@gmail.com", "Ahmed Hassan", "1234567", 2 },
                    { 2, new DateTime(1905, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara@gmail.com", "Sara Mohamed", "7654321", 0 },
                    { 3, new DateTime(1905, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali@gmail.com", "Ali Mohamed", "000000000", 1 }
                });

            migrationBuilder.InsertData(
                table: "CandidateProfiles",
                columns: new[] { "CandidateProfileId", "Phone", "ResumeUrl", "Skill", "UserId", "YearOfExperience" },
                values: new object[,]
                {
                    { 1, "01012345678", "Example.com/resum1", "Asp.netcore", 3, 3 },
                    { 2, "01112345678", "Example.com/resuem2", "flutter", 2, 3 },
                    { 3, "01129566806", "Example3.com/resuem2", "logic", 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Companys",
                columns: new[] { "CompanyId", "Description", "Location", "Name", "UserId", "Website" },
                values: new object[,]
                {
                    { 1, "oseihwoefowheofhw", "Cairo", "Teach soluition", 3, "http://werwerwerwwerwer" },
                    { 2, "ioajsfiojasiofj", "giza", "FutureSystem", 2, "http://werwerwerwwerwer" },
                    { 3, "for potatos", "egypt", "Agreland", 1, "http://werwerwerwwerwer" }
                });

            migrationBuilder.InsertData(
                table: "Jops",
                columns: new[] { "JopId", "CompanyId", "Deadline", "Description", "EmployeType", "Location", "PostedDate", "Salary", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1905, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "weijweiofjiowejriowerwe", 0, "Cairo", new DateTime(1905, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000m, 0, "Backend" },
                    { 2, 2, new DateTime(1905, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "iwe0rwe0rwrw", 2, "Giza", new DateTime(1905, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000m, 0, "Frontend" },
                    { 3, 2, new DateTime(1905, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "jjjjjjj", 1, "faysel", new DateTime(1905, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 900m, 0, "wireframe" }
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "ApplicationId", "ApplicationDate", "CandidateProfileId", "CoverLetter", "JopId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(1905, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ewfwfwefwefwf000", 1, 0 },
                    { 2, new DateTime(1905, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "wejrwewerwerw", 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CandidateProfileId_JopId",
                table: "Applications",
                columns: new[] { "CandidateProfileId", "JopId" });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JopId",
                table: "Applications",
                column: "JopId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateProfiles_UserId",
                table: "CandidateProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companys_UserId",
                table: "Companys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jops_CompanyId",
                table: "Jops",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "CandidateProfiles");

            migrationBuilder.DropTable(
                name: "Jops");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
