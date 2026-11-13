using Microsoft.EntityFrameworkCore;

namespace Holistic_Hiking.Models.Entities;

public class User
{
    // primary key
    public int userId {get; set;}

    // username
    public string Username {get; set;} = string.Empty;

    // user firstname
    public string FirstName {get; set;} = string.Empty;

    // optional user last name
    public string? LastName {get; set;}

    // user email
    public string Email {get; set;} = string.Empty;

    

}