using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryPatternWithUOW.EF.Migrations
{
    /// <inheritdoc />
    public partial class modify_Info_tbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSigningInfos_Employees_EmployeeId",
                table: "EmployeeSigningInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSigningInfos",
                table: "EmployeeSigningInfos");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSigningInfos_EmployeeId",
                table: "EmployeeSigningInfos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeeSigningInfos");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeSigningInfos");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "EmployeeSigningInfos");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "EmployeeSigningInfos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeSigningInfoId",
                table: "Employees",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "EmployeeSigningInfoId",
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

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "EmployeeSigningInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "EmployeeSigningInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSigningInfos",
                table: "EmployeeSigningInfos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSigningInfos_EmployeeId",
                table: "EmployeeSigningInfos",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSigningInfos_Employees_EmployeeId",
                table: "EmployeeSigningInfos",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
