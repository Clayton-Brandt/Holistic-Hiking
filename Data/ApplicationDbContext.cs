using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Holistic_Hiking.Models.Entities;

namespace Holistic_Hiking.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Trail> Trails => Set<Trail>();
    public DbSet<Comment> Comments => Set<Comment>();

    // DATA SEEDS
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Comment>(entity =>
{
    entity.HasKey(c => c.CommentId);

    entity.Property(c => c.Text)
          .IsRequired()
          .HasMaxLength(2000);

    entity.Property(c => c.CreatedAt)
          .IsRequired();

    entity.HasOne(c => c.Trail)
          .WithMany(t => t.Comments)
          .HasForeignKey(c => c.TrailId)
          .OnDelete(DeleteBehavior.Cascade);

    entity.HasOne(c => c.User)
          .WithMany()
          .HasForeignKey(c => c.UserId)
          .OnDelete(DeleteBehavior.Cascade);
});

        // Trail seeds
        builder.Entity<Trail>().HasData(
            new Trail
            {
                TrailId = 1,
                Name = "Alum Cave Trail",
                Location = "Great Smoky Mountains National Park",
                Length = 4.6,
                Difficulty = "Moderate",
                Description = "Climbs through the Arch Rock tunnel and past Inspiration Point to the 100-foot-high Alum Cave Bluffs. The trail continues on to Mount LeConte."
            },

            new Trail
            {
                TrailId = 2,
                Name = "Laurel Falls Trail",
                Location = "Great Smoky Mountains National Park",
                Length = 2.6,
                Difficulty = "Easy",
                Description = "Paved path to an 80-foot cascade. Closed for rehabilitation, with reopening expected in 2027."
            },

            new Trail
            {
                TrailId = 3,
                Name = "Ramsey Cascades Trail",
                Location = "Great Smoky Mountains National Park",
                Length = 8.0,
                Difficulty = "Hard",
                Description = "Strenuous climb of more than 2,100 feet through old-growth forest to the park's tallest waterfall, at 100 feet. The final half mile involves boulder-hopping along the stream."
            },

            new Trail
            {
                TrailId = 4,
                Name = "Chimney Tops Trail",
                Location = "Great Smoky Mountains National Park",
                Length = 4.0,
                Difficulty = "Hard",
                Description = "Steep climb gaining about 1,400 feet off Newfound Gap Road. The final stretch to the summit pinnacles has been closed since the 2016 wildfires."
            },

            new Trail
            {
                TrailId = 5,
                Name = "Rainbow Falls Trail",
                Location = "Great Smoky Mountains National Park",
                Length = 5.4,
                Difficulty = "Moderate",
                Description = "Steady climb of about 1,600 feet through forest to an 80-foot waterfall."
            },

            new Trail
            {
                TrailId = 6,
                Name = "Abrams Falls Trail",
                Location = "Great Smoky Mountains National Park",
                Length = 5.0,
                Difficulty = "Moderate",
                Description = "Popular Cades Cove hike to a short, powerful waterfall. Strong currents make swimming at the falls dangerous."
            },

            new Trail
            {
                TrailId = 7,
                Name = "Charlies Bunion",
                Location = "Great Smoky Mountains National Park",
                Length = 8.0,
                Difficulty = "Hard",
                Description = "Follows the Appalachian Trail from Newfound Gap to a rocky outcrop with wide mountain views."
            },

            new Trail
            {
                TrailId = 8,
                Name = "Andrews Bald",
                Location = "Great Smoky Mountains National Park",
                Length = 3.6,
                Difficulty = "Moderate",
                Description = "Forney Ridge Trail from the Kuwohi parking area to a grassy high-elevation bald."
            },

            new Trail
            {
                TrailId = 9,
                Name = "Grotto Falls",
                Location = "Great Smoky Mountains National Park",
                Length = 2.6,
                Difficulty = "Easy",
                Description = "Trillium Gap Trail to a 25-foot waterfall that hikers can walk behind."
            },

            new Trail
            {
                TrailId = 10,
                Name = "Gregory Bald",
                Location = "Great Smoky Mountains National Park",
                Length = 11.3,
                Difficulty = "Hard",
                Description = "Long, strenuous climb from Cades Cove to a high grassy bald known for its early summer flame azaleas."
            },

            new Trail
            {
                TrailId = 11,
                Name = "Porters Creek Trail",
                Location = "Great Smoky Mountains National Park",
                Length = 4.0,
                Difficulty = "Easy",
                Description = "Gentle Greenbrier area walk along a creek, popular for spring wildflowers."
            },

            new Trail
            {
                TrailId = 12,
                Name = "Middle Prong Trail",
                Location = "Great Smoky Mountains National Park",
                Length = 8.3,
                Difficulty = "Moderate",
                Description = "Old logging railroad grade in the Tremont area that follows a series of cascades."
            },

            new Trail
            {
                TrailId = 13,
                Name = "Baskins Creek Falls",
                Location = "Great Smoky Mountains National Park",
                Length = 3.0,
                Difficulty = "Moderate",
                Description = "Quieter waterfall hike near Gatlinburg that sees less traffic than the park's better-known falls."
            },

            new Trail
            {
                TrailId = 14,
                Name = "Little River Trail",
                Location = "Great Smoky Mountains National Park",
                Length = 4.9,
                Difficulty = "Easy",
                Description = "Wide, gently graded Elkmont trail beside the Little River."
            },

            new Trail
            {
                TrailId = 15,
                Name = "Bullhead Trail",
                Location = "Great Smoky Mountains National Park",
                Length = 13.9,
                Difficulty = "Hard",
                Description = "Challenging all-day climb to the summit of Mount LeConte."
            },

            new Trail
            {
                TrailId = 16,
                Name = "Twin Arches Loop",
                Location = "Big South Fork National River and Recreation Area",
                Length = 4.5,
                Difficulty = "Moderate",
                Description = "Loop past a pair of massive natural sandstone arches, with steep wooden stairs and cliff edges along the way."
            },

            new Trail
            {
                TrailId = 17,
                Name = "Slave Falls and Needle Arch",
                Location = "Big South Fork National River and Recreation Area",
                Length = 3.0,
                Difficulty = "Easy",
                Description = "Forest walk leading to both a waterfall and a natural arch."
            },

            new Trail
            {
                TrailId = 18,
                Name = "Middle Creek Loop",
                Location = "Big South Fork National River and Recreation Area",
                Length = 3.5,
                Difficulty = "Easy",
                Description = "Easy loop on the west side of the park passing sandstone rock shelters."
            },

            new Trail
            {
                TrailId = 19,
                Name = "Rock Creek Loop",
                Location = "Big South Fork National River and Recreation Area",
                Length = 7.1,
                Difficulty = "Moderate",
                Description = "Longer west side loop rated moderately difficult by the park."
            },

            new Trail
            {
                TrailId = 20,
                Name = "Honey Creek Loop",
                Location = "Big South Fork National River and Recreation Area",
                Length = 5.5,
                Difficulty = "Hard",
                Description = "The park's most challenging loop, with creek crossings and boulder fields. Allow about an hour per mile."
            },

            new Trail
            {
                TrailId = 21,
                Name = "Oscar Blevins Farm Loop",
                Location = "Big South Fork National River and Recreation Area",
                Length = 3.6,
                Difficulty = "Easy",
                Description = "Easy central area loop past a historic farmstead."
            },

            new Trail
            {
                TrailId = 22,
                Name = "Sunset Overlook",
                Location = "Big South Fork National River and Recreation Area",
                Length = 2.6,
                Difficulty = "Easy",
                Description = "Easy out-and-back walk to an overlook on the east side of the park."
            },

            new Trail
            {
                TrailId = 23,
                Name = "Base of the Falls Trail",
                Location = "Fall Creek Falls State Park",
                Length = 0.7,
                Difficulty = "Moderate",
                Description = "Short but steep descent of about 250 feet into the gorge, ending at the base of Fall Creek Falls."
            },

            new Trail
            {
                TrailId = 24,
                Name = "Gorge Overlook and Woodland Loop",
                Location = "Fall Creek Falls State Park",
                Length = 3.1,
                Difficulty = "Moderate",
                Description = "Rim loop with views of Cane Creek Falls, Cane Creek Gulf, and Fall Creek Falls."
            },

            new Trail
            {
                TrailId = 25,
                Name = "Piney Creek Falls and Lower Loop",
                Location = "Fall Creek Falls State Park",
                Length = 5.2,
                Difficulty = "Moderate",
                Description = "Forested loop that takes in Piney Creek Falls."
            },

            new Trail
            {
                TrailId = 26,
                Name = "Gilbert Gaul Trail",
                Location = "Fall Creek Falls State Park",
                Length = 4.2,
                Difficulty = "Moderate",
                Description = "Natural-surface, hiking-only trail following the shore of Fall Creek Lake."
            },

            new Trail
            {
                TrailId = 27,
                Name = "Burgess Falls River Trail",
                Location = "Burgess Falls State Park",
                Length = 1.5,
                Difficulty = "Moderate",
                Description = "Short river walk past a series of waterfalls, ending at the 130-foot main falls."
            },

            new Trail
            {
                TrailId = 28,
                Name = "Cummins Falls Gorge Trail",
                Location = "Cummins Falls State Park",
                Length = 2.5,
                Difficulty = "Hard",
                Description = "Physically demanding route through the gorge to the base of the falls. A permit is required."
            },

            new Trail
            {
                TrailId = 29,
                Name = "Virgin Falls Trail",
                Location = "Virgin Falls State Natural Area",
                Length = 8.2,
                Difficulty = "Hard",
                Description = "Strenuous hike that is mostly downhill on the way in and uphill on the way out, with a side trip to Sheep Cave available."
            },

            new Trail
            {
                TrailId = 30,
                Name = "Stone Door Trail",
                Location = "Savage Gulf State Park",
                Length = 2.0,
                Difficulty = "Easy",
                Description = "Mostly level walk from the ranger station to the Stone Door overlook."
            },

            new Trail
            {
                TrailId = 31,
                Name = "Margarette Falls Trail",
                Location = "Cherokee National Forest",
                Length = 2.6,
                Difficulty = "Moderate",
                Description = "Creekside hike near Greeneville to a 60-foot fan-shaped waterfall, with an ankle-deep creek ford about a mile in."
            },

            new Trail
            {
                TrailId = 32,
                Name = "Round Bald via Carvers Gap",
                Location = "Roan Highlands",
                Length = 2.0,
                Difficulty = "Moderate",
                Description = "Short Appalachian Trail section from Carvers Gap on the Tennessee and North Carolina line up to an open grassy bald."
            }
        );



    }
}

