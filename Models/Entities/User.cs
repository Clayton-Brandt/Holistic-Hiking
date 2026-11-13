using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Holistic_Hiking.Models.Entities;

public class User : IdentityUser
{
    // User first name
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    // Optional last name
    [StringLength(50)]
    public string? LastName { get; set; }

    // Optional user biography
    [StringLength(1000)]
    public string? UserBio { get; set; }

    // Account creation date
    public DateOnly JoinDate { get; set; }
        = DateOnly.FromDateTime(DateTime.Today);

    /* ----------------------------------
                Relationships
    ------------------------------------- */

    // User -> Comment (1:M)
    public ICollection<Comment> Comments { get; set; } = [];

    // User -> SavedTrail (1:M)
    public ICollection<SavedTrail> SavedTrails { get; set; } = [];

    // Uncomment when trail ratings are implemented
    // public ICollection<Rating> Ratings { get; set; } = [];
}
