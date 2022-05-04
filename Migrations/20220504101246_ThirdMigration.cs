using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Management_System.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_departments_Department_Id",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_Department_Id",
                table: "employees");

            migrationBuilder.AlterColumn<int>(
                name: "Department_Id",
                table: "employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Department_Id1",
                table: "employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_Department_Id1",
                table: "employees",
                column: "Department_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_departments_Department_Id1",
                table: "employees",
                column: "Department_Id1",
                principalTable: "departments",
                principalColumn: "Department_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_departments_Department_Id1",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_Department_Id1",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Department_Id1",
                table: "employees");

            migrationBuilder.AlterColumn<int>(
                name: "Department_Id",
                table: "employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_employees_Department_Id",
                table: "employees",
                column: "Department_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_departments_Department_Id",
                table: "employees",
                column: "Department_Id",
                principalTable: "departments",
                principalColumn: "Department_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
