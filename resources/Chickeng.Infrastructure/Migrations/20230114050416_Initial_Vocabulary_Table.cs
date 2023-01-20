using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chickeng.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialVocabularyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vocabularies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Word = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    WordType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Mean = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Pronounce = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vocabularies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vocabularies");
        }
    }
}
