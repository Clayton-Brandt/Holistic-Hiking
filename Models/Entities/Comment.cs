using Microsoft.AspNetCore.Identity;

namespace Holistic_Hiking.Models.Entities;

public class Comment
{
    public int CommentId { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    /* ----------------------------------
                Relationships
    ------------------------------------- */

    // User -> Comment
    // foreign key to user
    public string UserId {get; set;} = string.Empty;
    // navigation property
    public User? User {get; set;}
    // public IdentityUser User { get; set; } = null!;

    // Trail -> Comment
    // foreign key to trail
    public int TrailId {get; set;}
    // navigation property
    public Trail? Trail {get; set;}

}