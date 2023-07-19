using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedingEmployeedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Adress", "Age", "EmailID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Delhi", 25, "ib@gmail.com", "Ishaan", "Batra" },
                    { 2, "Banglore", 32, "ps@gmail.com", "Priyanks", "Singh" },
                    { 3, "Pune", 40, "ps@gmail.com", "Shweta", "Agarwal" },
                    { 4, "Pune", 38, "dp@gmail.com", "Deepa", "Patel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 4);
        }
    }
}
