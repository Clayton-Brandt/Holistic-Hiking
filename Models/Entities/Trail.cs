using Microsoft.EntityFrameworkCore;

namespace Holistic_Hiking.Models.Entities;

public class Trail
{
    // Primary Key
    public int TrailId {get;set;}

    // Trail Name
    public string Name {get; set;} = string.Empty;

    // Location
    public string Location {get; set;} = string.Empty;

    // Length
    public double Length {get; set;}

    // Difficulty
    public string Difficulty {get; set;} = string.Empty;

    // Rating -- Remove this to make its own rating entity
    public int Rating {get; set;}

    // Description
    public string Description {get; set;} = string.Empty;

    // Trail Image URL
    public string? ImageUrl {get; set;}

    /* ----------------------------------
                Relationships
    ------------------------------------- */

    // Trail -> Comment -- 1:M, trails can have many comments
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    // Trail -> TrailRating -- 1:M, trails can have many ratings

}