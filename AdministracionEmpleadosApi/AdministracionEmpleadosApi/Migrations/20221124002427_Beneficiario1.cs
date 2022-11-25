using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdministracionEmpleadosApi.Migrations
{
    /// <inheritdoc />
    public partial class Beneficiario1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiarios_Empleados_EmpleadoId",
                table: "Beneficiarios");

            migrationBuilder.AlterColumn<int>(
                name: "EmpleadoId",
                table: "Beneficiarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiarios_Empleados_EmpleadoId",
                table: "Beneficiarios",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiarios_Empleados_EmpleadoId",
                table: "Beneficiarios");

            migrationBuilder.AlterColumn<int>(
                name: "EmpleadoId",
                table: "Beneficiarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiarios_Empleados_EmpleadoId",
                table: "Beneficiarios",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id");
        }
    }
}
