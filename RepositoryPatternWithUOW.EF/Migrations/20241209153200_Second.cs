using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryPatternWithUOW.EF.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Employees_EmployeeId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficialHoliday_Employees_EmployeeId",
                table: "OfficialHoliday");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialLeave_Employees_EmployeeId",
                table: "SpecialLeave");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecialLeave",
                table: "SpecialLeave");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfficialHoliday",
                table: "OfficialHoliday");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.RenameTable(
                name: "SpecialLeave",
                newName: "SpecialLeaves");

            migrationBuilder.RenameTable(
                name: "OfficialHoliday",
                newName: "OfficialHolidays");

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "Attendances");

            migrationBuilder.RenameIndex(
                name: "IX_SpecialLeave_EmployeeId",
                table: "SpecialLeaves",
                newName: "IX_SpecialLeaves_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_OfficialHoliday_EmployeeId",
                table: "OfficialHolidays",
                newName: "IX_OfficialHolidays_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_EmployeeId",
                table: "Attendances",
                newName: "IX_Attendances_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecialLeaves",
                table: "SpecialLeaves",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfficialHolidays",
                table: "OfficialHolidays",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Employees_EmployeeId",
                table: "Attendances",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficialHolidays_Employees_EmployeeId",
                table: "OfficialHolidays",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialLeaves_Employees_EmployeeId",
                table: "SpecialLeaves",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Employees_EmployeeId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficialHolidays_Employees_EmployeeId",
                table: "OfficialHolidays");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialLeaves_Employees_EmployeeId",
                table: "SpecialLeaves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecialLeaves",
                table: "SpecialLeaves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfficialHolidays",
                table: "OfficialHolidays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.RenameTable(
                name: "SpecialLeaves",
                newName: "SpecialLeave");

            migrationBuilder.RenameTable(
                name: "OfficialHolidays",
                newName: "OfficialHoliday");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendance");

            migrationBuilder.RenameIndex(
                name: "IX_SpecialLeaves_EmployeeId",
                table: "SpecialLeave",
                newName: "IX_SpecialLeave_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_OfficialHolidays_EmployeeId",
                table: "OfficialHoliday",
                newName: "IX_OfficialHoliday_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_EmployeeId",
                table: "Attendance",
                newName: "IX_Attendance_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecialLeave",
                table: "SpecialLeave",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfficialHoliday",
                table: "OfficialHoliday",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Employees_EmployeeId",
                table: "Attendance",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficialHoliday_Employees_EmployeeId",
                table: "OfficialHoliday",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialLeave_Employees_EmployeeId",
                table: "SpecialLeave",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
