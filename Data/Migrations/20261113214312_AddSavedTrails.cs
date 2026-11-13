using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holistic_Hiking.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSavedTrails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavedTrails",
                columns: table => new
                {
                    SavedTrailId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    TrailId = table.Column<int>(type: "INTEGER", nullable: false),
                    SavedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedTrails", x => x.SavedTrailId);
                    table.ForeignKey(
                        name: "FK_SavedTrails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedTrails_Trails_TrailId",
                        column: x => x.TrailId,
                        principalTable: "Trails",
                        principalColumn: "TrailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavedTrails_TrailId",
                table: "SavedTrails",
                column: "TrailId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedTrails_UserId_TrailId",
                table: "SavedTrails",
                columns: new[] { "UserId", "TrailId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavedTrails");
        }
    }
}
