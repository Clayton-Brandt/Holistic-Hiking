using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Holistic_Hiking.Data.Migrations
{
    /// <inheritdoc />
    public partial class Trails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    TrailId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Length = table.Column<double>(type: "REAL", nullable: false),
                    Difficulty = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trails", x => x.TrailId);
                });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "TrailId", "Description", "Difficulty", "ImageUrl", "Length", "Location", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "Scenic Trail", "Moderate", null, 4.5999999999999996, "Great Smoky Mountains National Park", "Alum Cave Trail", 0 },
                    { 2, "Scenic Trail", "Easy", null, 2.6000000000000001, "Great Smoky Mountains National Park", "Laurel Falls Trail", 0 },
                    { 3, "Scenic Trail", "Hard", null, 15.0, "Great Smoky Mountains National Park", "Ramsey Cascade Trail", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trails");
        }
    }
}
