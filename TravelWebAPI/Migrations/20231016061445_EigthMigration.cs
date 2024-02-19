using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class EigthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Itineraries_UserId",
                table: "Itineraries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Itineraries_Users_UserId",
                table: "Itineraries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itineraries_Users_UserId",
                table: "Itineraries");

            migrationBuilder.DropIndex(
                name: "IX_Itineraries_UserId",
                table: "Itineraries");
        }
    }
}
