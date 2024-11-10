using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace persoonBeheerSysteem.Migrations
{
    /// <inheritdoc />
    public partial class AddTenSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "AbsenceID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 3, 8, 18, 39, 603, DateTimeKind.Local).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "AbsenceID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 5, 8, 18, 39, 603, DateTimeKind.Local).AddTicks(9008));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "DepartmentName" },
                values: new object[,]
                {
                    { 3, "IT" },
                    { 4, "Marketing" },
                    { 5, "Operations" },
                    { 6, "Customer Service" },
                    { 7, "Sales" },
                    { 8, "Research" },
                    { 9, "Procurement" },
                    { 10, "Legal" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "ContactInfo", "DepartmentID", "Name", "Salary" },
                values: new object[] { 5, "charlie.white@example.com", 1, "Charlie White", 70000m });

            migrationBuilder.InsertData(
                table: "Absences",
                columns: new[] { "AbsenceID", "Date", "EmployeeID", "Reason" },
                values: new object[] { 5, new DateTime(2024, 11, 8, 8, 18, 39, 603, DateTimeKind.Local).AddTicks(9014), 5, "Work From Home" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "ContactInfo", "DepartmentID", "Name", "Salary" },
                values: new object[,]
                {
                    { 3, "alice.johnson@example.com", 3, "Alice Johnson", 45000m },
                    { 4, "bob.brown@example.com", 4, "Bob Brown", 48000m },
                    { 6, "emily.green@example.com", 5, "Emily Green", 54000m },
                    { 7, "frank.black@example.com", 6, "Frank Black", 52000m },
                    { 8, "grace.blue@example.com", 7, "Grace Blue", 49000m },
                    { 9, "henry.silver@example.com", 8, "Henry Silver", 53000m },
                    { 10, "isabella.gold@example.com", 9, "Isabella Gold", 58000m }
                });

            migrationBuilder.InsertData(
                table: "Absences",
                columns: new[] { "AbsenceID", "Date", "EmployeeID", "Reason" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 10, 31, 8, 18, 39, 603, DateTimeKind.Local).AddTicks(9010), 3, "Family Emergency" },
                    { 4, new DateTime(2024, 11, 7, 8, 18, 39, 603, DateTimeKind.Local).AddTicks(9012), 4, "Medical Appointment" },
                    { 6, new DateTime(2024, 11, 9, 8, 18, 39, 603, DateTimeKind.Local).AddTicks(9016), 6, "Conference" },
                    { 7, new DateTime(2024, 11, 6, 8, 18, 39, 603, DateTimeKind.Local).AddTicks(9017), 7, "Vacation" },
                    { 8, new DateTime(2024, 11, 4, 8, 18, 39, 603, DateTimeKind.Local).AddTicks(9019), 8, "Sick Leave" },
                    { 9, new DateTime(2024, 11, 2, 8, 18, 39, 603, DateTimeKind.Local).AddTicks(9021), 9, "Training" },
                    { 10, new DateTime(2024, 11, 1, 8, 18, 39, 603, DateTimeKind.Local).AddTicks(9023), 10, "Client Meeting" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Absences",
                keyColumn: "AbsenceID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Absences",
                keyColumn: "AbsenceID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Absences",
                keyColumn: "AbsenceID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Absences",
                keyColumn: "AbsenceID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Absences",
                keyColumn: "AbsenceID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Absences",
                keyColumn: "AbsenceID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Absences",
                keyColumn: "AbsenceID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Absences",
                keyColumn: "AbsenceID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "AbsenceID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 3, 8, 8, 49, 59, DateTimeKind.Local).AddTicks(8192));

            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "AbsenceID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 5, 8, 8, 49, 59, DateTimeKind.Local).AddTicks(8240));
        }
    }
}
