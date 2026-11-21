using Microsoft.AspNetCore.Identity;

namespace Holistic_Hiking.Models.Entities;

public class Rating
{
    public int RatingId { get; set; }

    public string UserId { get; set; } = string.Empty;
    public IdentityUser User { get; set; } = null!;

    public int TrailId { get; set; }
    public Trail Trail { get; set; } = null!;

    // 1–5 stars. Validated in controller + DB check constraint.
    public int Value { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}