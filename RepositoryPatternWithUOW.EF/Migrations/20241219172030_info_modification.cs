using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryPatternWithUOW.EF.Migrations
{
    /// <inheritdoc />
    public partial class info_modification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeSigningInfos_EmployeeSigningInfoUsername",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSigningInfos",
                table: "EmployeeSigningInfos");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeSigningInfoUsername",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeSigningInfoUsername",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "EmployeeSigningInfos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EmployeeSigningInfos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSigningInfos",
                table: "EmployeeSigningInfos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeSigningInfoId",
                table: "Employees",
                column: "EmployeeSigningInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeSigningInfos_EmployeeSigningInfoId",
                table: "Employees",
                column: "EmployeeSigningInfoId",
                principalTable: "EmployeeSigningInfos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeSigningInfos_EmployeeSigningInfoId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSigningInfos",
                table: "EmployeeSigningInfos");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeSigningInfoId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeeSigningInfos");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "EmployeeSigningInfos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeSigningInfoUsername",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSigningInfos",
                table: "EmployeeSigningInfos",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeSigningInfoUsername",
                table: "Employees",
                column: "EmployeeSigningInfoUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeSigningInfos_EmployeeSigningInfoUsername",
                table: "Employees",
                column: "EmployeeSigningInfoUsername",
                principalTable: "EmployeeSigningInfos",
                principalColumn: "Username");
        }
    }
}
