using Microsoft.EntityFrameworkCore;

namespace Holistic_Hiking.Models.Entities;

public class SavedTrail
{
    public int SavedTrailId { get; set; }

    // The user who saved the trail
    public string UserId { get; set; } = string.Empty;
    public User User { get; set; } = null!;

    // The trail being saved
    public int TrailId { get; set; }
    public Trail Trail { get; set; } = null!;

    // When the trail was saved
    public DateTime SavedAt { get; set; } = DateTime.UtcNow;
}
