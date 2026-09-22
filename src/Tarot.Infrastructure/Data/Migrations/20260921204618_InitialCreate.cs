using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarot.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StyleDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicTracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileRef = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SourceTier = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LicenseNote = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicTracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeckId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Arcana = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UprightMeaning = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ReversedMeaning = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SceneDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ImageRef = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadingSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ViewerIntro = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CardId = table.Column<int>(type: "int", nullable: true),
                    ReadingText = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Language = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NarrationText = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: true),
                    CritiqueVerdict = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CritiqueNotes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    AudioRef = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VideoRef = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MusicTrackId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingSessions_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReadingSessions_MusicTracks_MusicTrackId",
                        column: x => x.MusicTrackId,
                        principalTable: "MusicTracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_DeckId_Name",
                table: "Cards",
                columns: new[] { "DeckId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReadingSessions_CardId",
                table: "ReadingSessions",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingSessions_CreatedAt",
                table: "ReadingSessions",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingSessions_MusicTrackId",
                table: "ReadingSessions",
                column: "MusicTrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadingSessions");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "MusicTracks");

            migrationBuilder.DropTable(
                name: "Decks");
        }
    }
}
