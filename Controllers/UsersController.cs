using Microsoft.AspNetCore.Mvc; 
using Holistic_Hiking.Models.Entities;
using Holistic_Hiking.Services;
using Holistic_Hiking.Data.Migrations;

namespace Holistic_Hiking.Controllers;

public class UsersController : Controller
{
    private readonly IUserRepository _userRepo;

    public UsersController (IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }
}