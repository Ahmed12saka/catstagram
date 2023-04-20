using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatsTagram.Migrations
{
    /// <inheritdoc />
    public partial class Intialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HashTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatPostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HashTags_CatPosts_CatPostId",
                        column: x => x.CatPostId,
                        principalTable: "CatPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HashTags_CatPostId",
                table: "HashTags",
                column: "CatPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HashTags");

            migrationBuilder.DropTable(
                name: "CatPosts");
        }
    }
}
