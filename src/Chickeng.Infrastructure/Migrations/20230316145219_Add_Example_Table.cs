using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chickeng.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExampleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WordExamples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Mean = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordExamples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VocabularyHasExamples",
                columns: table => new
                {
                    VocabularyId = table.Column<int>(type: "INTEGER", nullable: false),
                    WordExampleId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyHasExamples", x => new { x.VocabularyId, x.WordExampleId });
                    table.ForeignKey(
                        name: "FK_VocabularyHasExamples_Vocabularies_VocabularyId",
                        column: x => x.VocabularyId,
                        principalTable: "Vocabularies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VocabularyHasExamples_WordExamples_WordExampleId",
                        column: x => x.WordExampleId,
                        principalTable: "WordExamples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyHasExamples_WordExampleId",
                table: "VocabularyHasExamples",
                column: "WordExampleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VocabularyHasExamples");

            migrationBuilder.DropTable(
                name: "WordExamples");
        }
    }
}
