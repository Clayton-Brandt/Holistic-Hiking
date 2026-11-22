using Holistic_Hiking.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Holistic_Hiking.Data;

public static class SeedData
{
    // Shared password for every seeded account
    private const string DemoPassword = "Passw0rd!";

    public static async Task InitializeAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();

        const string email = "test@example.com";
        if (await userManager.FindByEmailAsync(email) == null)
        {
            var testUser = new User
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                FirstName = "firstName",
                LastName = "lastName",
                UserBio = "A short bio"
            };
            var result = await userManager.CreateAsync(testUser, DemoPassword);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException(string.Join("; ", result.Errors.Select(e => e.Description)));
            }

        }

        // Demo accounts use a known password, so keep them out of production
        if (env.IsDevelopment())
        {
            await SeedDemoUsersAsync(userManager, db);
        }
    }

    /* ----------------------------------
                Demo users
    ------------------------------------- */

    private record DemoComment(int TrailId, int DaysAgo, string Text);

    private record DemoUser(
        string Email,
        string FirstName,
        string? LastName,
        string? Bio,
        DateOnly JoinDate,
        int[] SavedTrailIds,
        DemoComment[] Comments);

    private static readonly DemoUser[] DemoUsers =
    [
        new("maya.hollins@example.com", "Maya", "Hollins",
            "Weekend waterfall chaser based out of Knoxville. Usually hiking with my dog, Juniper.",
            new DateOnly(2026, 6, 14),
            [5, 9, 23, 27, 29],
            [
                new(9, 41, "Walking behind the falls never gets old. Go early on a weekday, the parking lot fills up fast."),
                new(5, 30, "Steady climb the whole way up but the falls at the top are worth it. Rocks near the base are slick."),
                new(27, 12, "Great short river walk with a big payoff. Bring water, the stairs on the way back are a workout."),
            ]),

        new("devon.price@example.com", "Devon", "Price",
            "Trail runner and peak bagger. If it has a view at the top, I'm in.",
            new DateOnly(2026, 4, 2),
            [1, 3, 7, 10, 15, 32],
            [
                new(1, 55, "Classic Smokies hike. Arch Rock is a fun scramble and the bluffs are a great turnaround spot."),
                new(7, 38, "Exposed rock at the end has huge views. Windy and cold up top even in late summer, pack a layer."),
                new(3, 20, "Toughest hike I've done in the park. The last stretch to the cascades is all rock and roots."),
                new(32, 6, "Grassy balds and 360 views. Clouds rolled in fast, so check the forecast before you go."),
            ]),

        new("priya.raman@example.com", "Priya", "Raman",
            "Photographer learning the backcountry one trail at a time.",
            new DateOnly(2026, 8, 21),
            [8, 16, 22, 30],
            [
                new(16, 27, "The arches are massive in person. Late afternoon light through the north arch is beautiful."),
                new(22, 15, "Easy walk to an overlook that's perfect for sunset photos. Bring a headlamp for the walk back."),
                new(8, 9, "Wide open bald with views across the ridges. Lots of wildflowers in early summer."),
            ]),

        new("sam.okafor@example.com", "Sam", "Okafor",
            "New to hiking and working my way up from the easy trails.",
            new DateOnly(2026, 10, 3),
            [9, 11, 14, 17, 21],
            [
                new(14, 18, "Flat and shaded, great for a first hike. I saw a couple of people fly fishing along the river."),
                new(21, 10, "Nice loop past an old homestead. Good for families, the kids loved the barn."),
                new(11, 4, "Mostly gentle grade along the creek. Lots of old stone walls along the trail."),
            ]),

        new("ellie.brandt@example.com", "Ellie", null,
            null,
            new DateOnly(2026, 11, 10),
            [6, 28],
            [
                new(6, 3, "Wide waterfall and a nice pool at the bottom. Please don't swim here, the current is dangerous."),
            ]),

        new("marcus.webb@example.com", "Marcus", "Webb",
            "Retired teacher, section-hiking every state park in Tennessee. 19 down!",
            new DateOnly(2026, 2, 18),
            [20, 23, 24, 25, 26, 29, 30, 31],
            [
                new(23, 62, "Steep descent to the base of the falls, but there's a cable section to help. The mist up close is amazing."),
                new(30, 47, "The stone door itself is a neat crack in the bluff. Easy, paved approach with great overlooks."),
                new(29, 33, "Long day but you pass several waterfalls on the way. Virgin Falls disappearing into the cave is unique."),
                new(20, 21, "Rock-hopping, ladders and a few tight squeezes. Way more fun than the mileage suggests."),
                new(25, 8, "Lovely loop with a swinging bridge over the creek. Fall color was just starting."),
            ]),
    ];

    private static async Task SeedDemoUsersAsync(UserManager<User> userManager, ApplicationDbContext db)
    {
        var existingTrailIds = (await db.Trails.Select(t => t.TrailId).ToListAsync()).ToHashSet();

        foreach (var demo in DemoUsers)
        {
            // Skip users that already exist so seeding stays idempotent
            if (await userManager.FindByEmailAsync(demo.Email) != null)
            {
                continue;
            }

            var user = new User
            {
                UserName = demo.Email,
                Email = demo.Email,
                EmailConfirmed = true,
                FirstName = demo.FirstName,
                LastName = demo.LastName,
                UserBio = demo.Bio,
                JoinDate = demo.JoinDate
            };
            var result = await userManager.CreateAsync(user, DemoPassword);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException(string.Join("; ", result.Errors.Select(e => e.Description)));
            }

            foreach (var trailId in demo.SavedTrailIds.Where(existingTrailIds.Contains))
            {
                db.SavedTrails.Add(new SavedTrail
                {
                    UserId = user.Id,
                    TrailId = trailId,
                    SavedAt = DateTime.UtcNow.AddDays(-Random.Shared.Next(1, 60))
                });
            }

            foreach (var comment in demo.Comments.Where(c => existingTrailIds.Contains(c.TrailId)))
            {
                db.Comments.Add(new Comment
                {
                    UserId = user.Id,
                    TrailId = comment.TrailId,
                    Text = comment.Text,
                    CreatedAt = DateTime.UtcNow.AddDays(-comment.DaysAgo)
                });
            }

            await db.SaveChangesAsync();
        }
    }
}
