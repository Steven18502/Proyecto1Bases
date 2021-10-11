using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto1Bases.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peliculas");
        }
    }
}
