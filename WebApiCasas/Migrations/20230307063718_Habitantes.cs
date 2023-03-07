using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiCasas.Migrations
{
    public partial class Habitantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitante",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CURP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitante", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Habitante_Casas_CasaID",
                        column: x => x.CasaID,
                        principalTable: "Casas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habitante_CasaID",
                table: "Habitante",
                column: "CasaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habitante");
        }
    }
}
