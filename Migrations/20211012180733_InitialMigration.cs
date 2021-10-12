using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto1Bases.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ccedula = table.Column<string>(type: "text", nullable: false),
                    cusuario = table.Column<string>(type: "text", nullable: true),
                    cconstrasenia = table.Column<string>(type: "text", nullable: true),
                    cnombre_completo = table.Column<string>(type: "text", nullable: true),
                    cedad = table.Column<int>(type: "integer", nullable: false),
                    cfecha_nacimiento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ctelefono = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ccedula);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    ecedula = table.Column<string>(type: "text", nullable: false),
                    eusuario = table.Column<string>(type: "text", nullable: true),
                    econstrasenia = table.Column<string>(type: "text", nullable: true),
                    enombre_completo = table.Column<string>(type: "text", nullable: true),
                    eedad = table.Column<int>(type: "integer", nullable: false),
                    efecha_nacimiento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    etelefono = table.Column<string>(type: "text", nullable: true),
                    rol = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.ecedula);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    pnombre_original = table.Column<string>(type: "text", nullable: false),
                    pnombre = table.Column<string>(type: "text", nullable: true),
                    pduracion = table.Column<string>(type: "text", nullable: true),
                    director = table.Column<string>(type: "text", nullable: true),
                    clasificacion = table.Column<string>(type: "text", nullable: true),
                    protagonistas = table.Column<string>(type: "text", nullable: true),
                    pimagen = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.pnombre_original);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    sid = table.Column<string>(type: "text", nullable: false),
                    nombre_sucursal = table.Column<string>(type: "text", nullable: true),
                    cantidad_columnas = table.Column<int>(type: "integer", nullable: false),
                    cantidad_filas = table.Column<int>(type: "integer", nullable: false),
                    scapacidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.sid);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    nombre_cine = table.Column<string>(type: "text", nullable: false),
                    ubicacion = table.Column<string>(type: "text", nullable: true),
                    cantidad_salas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.nombre_cine);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Sucursales");
        }
    }
}
