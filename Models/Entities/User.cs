using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Holistic_Hiking.Models.Entities;

public class User : IdentityUser
{

    // user first name
    public string FirstName {get; set;} = string.Empty;

    // optional user last name
    public string? LastName {get; set;}

    // optional user bio/description
    public string? UserBio {get; set;}

    // join date
    public DateOnly JoinDate {get; set;} = DateOnly.FromDateTime(DateTime.Today);

    /* ----------------------------------
                Relationships
    ------------------------------------- */

    // User -> Comment -- 1:M, one user can leave many comments
    public ICollection<Comment> Comments {get; set;} = [];

    /*---------- Uncomment when Rating is done ----------
    // User -> TrailRating -- 1:M, one user can rate multiple trail;
    // public ICollection<Rating> Ratings {get; set;} = [];
    */
}