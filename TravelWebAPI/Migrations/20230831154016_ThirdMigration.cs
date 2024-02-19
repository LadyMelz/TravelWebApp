using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Itineraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Transportation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itineraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itineraries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Attraction_Itineraries_ItineraryId",
                table: "Attraction_Itineraries",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Itineraries_ItineraryId",
                table: "Event_Itineraries",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Itineraries_UserId",
                table: "Itineraries",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attraction_Itineraries");

            migrationBuilder.DropTable(
                name: "Event_Itineraries");

            migrationBuilder.DropTable(
                name: "Itineraries");
        }
    }
}
