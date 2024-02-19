using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SixthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItineraryId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItineraryId",
                table: "Attractions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ItineraryId",
                table: "Events",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_ItineraryId",
                table: "Attractions",
                column: "ItineraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attractions_Itineraries_ItineraryId",
                table: "Attractions",
                column: "ItineraryId",
                principalTable: "Itineraries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Itineraries_ItineraryId",
                table: "Events",
                column: "ItineraryId",
                principalTable: "Itineraries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attractions_Itineraries_ItineraryId",
                table: "Attractions");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Itineraries_ItineraryId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ItineraryId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Attractions_ItineraryId",
                table: "Attractions");

            migrationBuilder.DropColumn(
                name: "ItineraryId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ItineraryId",
                table: "Attractions");
        }
    }
}
