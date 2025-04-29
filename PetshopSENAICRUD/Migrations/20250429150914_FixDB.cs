using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetshopSENAICRUD.Migrations
{
    public partial class FixDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdConsulta",
                table: "Pagamento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_IdConsulta",
                table: "Pagamento",
                column: "IdConsulta");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_IdConsulta",
                table: "Pagamento",
                column: "IdConsulta",
                principalTable: "Consulta",
                principalColumn: "IdConsulta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_IdConsulta",
                table: "Pagamento");

            migrationBuilder.DropIndex(
                name: "IX_Pagamento_IdConsulta",
                table: "Pagamento");

            migrationBuilder.DropColumn(
                name: "IdConsulta",
                table: "Pagamento");
        }
    }
}
