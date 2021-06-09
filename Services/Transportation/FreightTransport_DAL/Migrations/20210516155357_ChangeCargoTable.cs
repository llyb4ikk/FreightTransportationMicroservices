using Microsoft.EntityFrameworkCore.Migrations;

namespace FreightTransport_DAL.Migrations
{
    public partial class ChangeCargoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_Users_ClientId",
                table: "Cargos");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Cargos",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cargos_ClientId",
                table: "Cargos",
                newName: "IX_Cargos_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_Users_OwnerId",
                table: "Cargos",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_Users_OwnerId",
                table: "Cargos");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Cargos",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Cargos_OwnerId",
                table: "Cargos",
                newName: "IX_Cargos_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_Users_ClientId",
                table: "Cargos",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
