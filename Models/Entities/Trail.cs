// using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Holistic_Hiking.Models.Entities;

/*
Most likely will need to change when API is up and running
NEED TO RESEARCH HOW APIs WORK WITH MVC and ENTITY FRAMEWORK
Do we want to do data annotations, started, but then got lazy... :) 
*/
public class Trail
{
    // Primary Key
    public int TrailId {get;set;}

    // Trail Name
    // [StringLength (128)]
    public string Name {get; set;} = string.Empty;

    // Location
    // [StringLength (32)]
    public string Location {get; set;} = string.Empty;

    // Length -- Do we want to do string or int?
    // [StringLength (16)]
    public string Length {get; set;} = string.Empty;

    // Difficulty -- Do we want to do string or int? 1-10? or "easy, medium, hard"?
    public int Difficulty {get; set;}
    // public string Difficulty {get; set;} = string.Empty;

    // Rating
    public int Rating {get; set;}

    // Description
    public string Description {get; set;} = string.Empty;

    // Trail Image URL
    public string? ImageUrl {get; set;}

    /* In case we need the option to upload Images...
    // Trail Image Upload
    public FormFile? ImageUpload {get; set;}
    */
}