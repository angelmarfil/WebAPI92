using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI92.Migrations
{
    public partial class _230524 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "PkRol", "Nombre" },
                values: new object[] { 1, "sa" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "PkUsuario", "FkRol", "Nombre", "Password", "User" },
                values: new object[] { 1, 1, "Angel", "password", "angelmarfil" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "PkUsuario",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "PkRol",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "User",
                table: "Usuario");
        }
    }
}
