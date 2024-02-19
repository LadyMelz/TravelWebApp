using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attractions_Itineraries_ItineraryId",
                table: "Attractions");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Itineraries_ItineraryId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Itineraries_Users_UserId",
                table: "Itineraries");

            migrationBuilder.DropTable(
                name: "Attraction_Itineraries");

            migrationBuilder.DropTable(
                name: "Event_Itineraries");

            migrationBuilder.DropIndex(
                name: "IX_Itineraries_UserId",
                table: "Itineraries");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Attraction_Itineraries",
                columns: table => new
                {
                    AttractionId = table.Column<int>(type: "int", nullable: false),
                    ItineraryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attraction_Itineraries", x => new { x.AttractionId, x.ItineraryId });
                    table.ForeignKey(
                        name: "FK_Attraction_Itineraries_Attractions_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attraction_Itineraries_Itineraries_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "Itineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event_Itineraries",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    ItineraryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Itineraries", x => new { x.EventId, x.ItineraryId });
                    table.ForeignKey(
                        name: "FK_Event_Itineraries_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Itineraries_Itineraries_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "Itineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Itineraries_UserId",
                table: "Itineraries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ItineraryId",
                table: "Events",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_ItineraryId",
                table: "Attractions",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Attraction_Itineraries_ItineraryId",
                table: "Attraction_Itineraries",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Itineraries_ItineraryId",
                table: "Event_Itineraries",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Itineraries_Users_UserId",
                table: "Itineraries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
