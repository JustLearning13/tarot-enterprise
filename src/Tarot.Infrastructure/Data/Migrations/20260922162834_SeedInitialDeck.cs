using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarot.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialDeck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Decks",
                columns: new[] { "Id", "Name", "StyleDescription" },
                values: new object[] { 1, "Ukrainian collage", "Fashion-editorial photo collage deck with color-blocked patterns and Ukrainian vyshyvanka embroidery motifs" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
