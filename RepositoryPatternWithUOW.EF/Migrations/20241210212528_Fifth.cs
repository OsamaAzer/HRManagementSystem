using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryPatternWithUOW.EF.Migrations
{
    /// <inheritdoc />
    public partial class Fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficialHolidays_Employees_EmployeeId",
                table: "OfficialHolidays");

            migrationBuilder.DropIndex(
                name: "IX_OfficialHolidays_EmployeeId",
                table: "OfficialHolidays");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "SpecialLeaves");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "OfficialHolidays");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "OfficialHolidays");

            migrationBuilder.DropColumn(
                name: "AttendanceDay",
                table: "Attendances");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DayOfWeek",
                table: "SpecialLeaves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DayOfWeek",
                table: "OfficialHolidays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "OfficialHolidays",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttendanceDay",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialHolidays_EmployeeId",
                table: "OfficialHolidays",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficialHolidays_Employees_EmployeeId",
                table: "OfficialHolidays",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
