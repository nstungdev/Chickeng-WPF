using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chickeng.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhraseTableAddMeanColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mean",
                table: "Phrases",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mean",
                table: "Phrases");
        }
    }
}
