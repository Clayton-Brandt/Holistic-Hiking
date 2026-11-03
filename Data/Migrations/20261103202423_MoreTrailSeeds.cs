using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Holistic_Hiking.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoreTrailSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 1,
                column: "Description",
                value: "Climbs through the Arch Rock tunnel and past Inspiration Point to the 100-foot-high Alum Cave Bluffs. The trail continues on to Mount LeConte.");

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 2,
                column: "Description",
                value: "Paved path to an 80-foot cascade. Closed for rehabilitation, with reopening expected in 2027.");

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 3,
                columns: new[] { "Description", "Length", "Name" },
                values: new object[] { "Strenuous climb of more than 2,100 feet through old-growth forest to the park's tallest waterfall, at 100 feet. The final half mile involves boulder-hopping along the stream.", 8.0, "Ramsey Cascades Trail" });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "TrailId", "Description", "Difficulty", "ImageUrl", "Length", "Location", "Name", "Rating" },
                values: new object[,]
                {
                    { 4, "Steep climb gaining about 1,400 feet off Newfound Gap Road. The final stretch to the summit pinnacles has been closed since the 2016 wildfires.", "Hard", null, 4.0, "Great Smoky Mountains National Park", "Chimney Tops Trail", 0 },
                    { 5, "Steady climb of about 1,600 feet through forest to an 80-foot waterfall.", "Moderate", null, 5.4000000000000004, "Great Smoky Mountains National Park", "Rainbow Falls Trail", 0 },
                    { 6, "Popular Cades Cove hike to a short, powerful waterfall. Strong currents make swimming at the falls dangerous.", "Moderate", null, 5.0, "Great Smoky Mountains National Park", "Abrams Falls Trail", 0 },
                    { 7, "Follows the Appalachian Trail from Newfound Gap to a rocky outcrop with wide mountain views.", "Hard", null, 8.0, "Great Smoky Mountains National Park", "Charlies Bunion", 0 },
                    { 8, "Forney Ridge Trail from the Kuwohi parking area to a grassy high-elevation bald.", "Moderate", null, 3.6000000000000001, "Great Smoky Mountains National Park", "Andrews Bald", 0 },
                    { 9, "Trillium Gap Trail to a 25-foot waterfall that hikers can walk behind.", "Easy", null, 2.6000000000000001, "Great Smoky Mountains National Park", "Grotto Falls", 0 },
                    { 10, "Long, strenuous climb from Cades Cove to a high grassy bald known for its early summer flame azaleas.", "Hard", null, 11.300000000000001, "Great Smoky Mountains National Park", "Gregory Bald", 0 },
                    { 11, "Gentle Greenbrier area walk along a creek, popular for spring wildflowers.", "Easy", null, 4.0, "Great Smoky Mountains National Park", "Porters Creek Trail", 0 },
                    { 12, "Old logging railroad grade in the Tremont area that follows a series of cascades.", "Moderate", null, 8.3000000000000007, "Great Smoky Mountains National Park", "Middle Prong Trail", 0 },
                    { 13, "Quieter waterfall hike near Gatlinburg that sees less traffic than the park's better-known falls.", "Moderate", null, 3.0, "Great Smoky Mountains National Park", "Baskins Creek Falls", 0 },
                    { 14, "Wide, gently graded Elkmont trail beside the Little River.", "Easy", null, 4.9000000000000004, "Great Smoky Mountains National Park", "Little River Trail", 0 },
                    { 15, "Challenging all-day climb to the summit of Mount LeConte.", "Hard", null, 13.9, "Great Smoky Mountains National Park", "Bullhead Trail", 0 },
                    { 16, "Loop past a pair of massive natural sandstone arches, with steep wooden stairs and cliff edges along the way.", "Moderate", null, 4.5, "Big South Fork National River and Recreation Area", "Twin Arches Loop", 0 },
                    { 17, "Forest walk leading to both a waterfall and a natural arch.", "Easy", null, 3.0, "Big South Fork National River and Recreation Area", "Slave Falls and Needle Arch", 0 },
                    { 18, "Easy loop on the west side of the park passing sandstone rock shelters.", "Easy", null, 3.5, "Big South Fork National River and Recreation Area", "Middle Creek Loop", 0 },
                    { 19, "Longer west side loop rated moderately difficult by the park.", "Moderate", null, 7.0999999999999996, "Big South Fork National River and Recreation Area", "Rock Creek Loop", 0 },
                    { 20, "The park's most challenging loop, with creek crossings and boulder fields. Allow about an hour per mile.", "Hard", null, 5.5, "Big South Fork National River and Recreation Area", "Honey Creek Loop", 0 },
                    { 21, "Easy central area loop past a historic farmstead.", "Easy", null, 3.6000000000000001, "Big South Fork National River and Recreation Area", "Oscar Blevins Farm Loop", 0 },
                    { 22, "Easy out-and-back walk to an overlook on the east side of the park.", "Easy", null, 2.6000000000000001, "Big South Fork National River and Recreation Area", "Sunset Overlook", 0 },
                    { 23, "Short but steep descent of about 250 feet into the gorge, ending at the base of Fall Creek Falls.", "Moderate", null, 0.69999999999999996, "Fall Creek Falls State Park", "Base of the Falls Trail", 0 },
                    { 24, "Rim loop with views of Cane Creek Falls, Cane Creek Gulf, and Fall Creek Falls.", "Moderate", null, 3.1000000000000001, "Fall Creek Falls State Park", "Gorge Overlook and Woodland Loop", 0 },
                    { 25, "Forested loop that takes in Piney Creek Falls.", "Moderate", null, 5.2000000000000002, "Fall Creek Falls State Park", "Piney Creek Falls and Lower Loop", 0 },
                    { 26, "Natural-surface, hiking-only trail following the shore of Fall Creek Lake.", "Moderate", null, 4.2000000000000002, "Fall Creek Falls State Park", "Gilbert Gaul Trail", 0 },
                    { 27, "Short river walk past a series of waterfalls, ending at the 130-foot main falls.", "Moderate", null, 1.5, "Burgess Falls State Park", "Burgess Falls River Trail", 0 },
                    { 28, "Physically demanding route through the gorge to the base of the falls. A permit is required.", "Hard", null, 2.5, "Cummins Falls State Park", "Cummins Falls Gorge Trail", 0 },
                    { 29, "Strenuous hike that is mostly downhill on the way in and uphill on the way out, with a side trip to Sheep Cave available.", "Hard", null, 8.1999999999999993, "Virgin Falls State Natural Area", "Virgin Falls Trail", 0 },
                    { 30, "Mostly level walk from the ranger station to the Stone Door overlook.", "Easy", null, 2.0, "Savage Gulf State Park", "Stone Door Trail", 0 },
                    { 31, "Creekside hike near Greeneville to a 60-foot fan-shaped waterfall, with an ankle-deep creek ford about a mile in.", "Moderate", null, 2.6000000000000001, "Cherokee National Forest", "Margarette Falls Trail", 0 },
                    { 32, "Short Appalachian Trail section from Carvers Gap on the Tennessee and North Carolina line up to an open grassy bald.", "Moderate", null, 2.0, "Roan Highlands", "Round Bald via Carvers Gap", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 32);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 1,
                column: "Description",
                value: "Scenic Trail");

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 2,
                column: "Description",
                value: "Scenic Trail");

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 3,
                columns: new[] { "Description", "Length", "Name" },
                values: new object[] { "Scenic Trail", 15.0, "Ramsey Cascade Trail" });
        }
    }
}
