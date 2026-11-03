using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Holistic_Hiking.Models.Entities;

namespace Holistic_Hiking.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Trail> Trails => Set<Trail>();

    // DATA SEEDS
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Trail seeds
        builder.Entity<Trail>().HasData(
            new Trail
            {
                TrailId = 1,
                Name = "Alum Cave Trail",
                Location = "Great Smoky Mountains National Park",
                Length = 4.6,
                Difficulty = "Moderate",
                Description = "Scenic Trail"
            },
            
            new Trail
            {
                TrailId = 2,
                Name = "Laurel Falls Trail",
                Location = "Great Smoky Mountains National Park",
                Length = 2.6,
                Difficulty = "Easy",
                Description = "Scenic Trail"
            },

            new Trail
            {
                TrailId = 3,
                Name = "Ramsey Cascade Trail",
                Location = "Great Smoky Mountains National Park",
                Length = 15.0,
                Difficulty = "Hard",
                Description = "Scenic Trail"
            }
        );



    }
}

