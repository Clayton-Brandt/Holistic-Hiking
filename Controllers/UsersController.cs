using System.Security.Claims;
using Holistic_Hiking.Models.Entities;
using Holistic_Hiking.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Holistic_Hiking.Controllers;

public class UsersController : Controller
{
    private readonly IUserRepository _userRepo;

    public UsersController(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    // GET: /Users/Profile
    [HttpGet]
    public async Task<IActionResult> Profile(string? id)
    {
        // Use logged-in user if no ID provided
        id ??= User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(id))
            return Challenge();

        var user = await _userRepo.ReadAsync(id);

        if (user is null)
            return NotFound();

        return View(user);
    }

    // GET: /Users/Edit
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Edit()
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(id))
            return Challenge();

        var user = await _userRepo.ReadAsync(id);

        if (user is null)
            return NotFound();

        return View(user);
    }

    // POST: /Users/Edit
    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        [Bind("FirstName,LastName,UserBio")] User user)
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(id))
            return Challenge();

        // Validate only editable profile fields.
        // Identity fields are not supplied by this form.
        ModelState.Clear();

        if (string.IsNullOrWhiteSpace(user.FirstName))
        {
            ModelState.AddModelError(
                nameof(user.FirstName),
                "First name is required.");
        }
        else if (user.FirstName.Length > 50)
        {
            ModelState.AddModelError(
                nameof(user.FirstName),
                "First name cannot exceed 50 characters.");
        }

        if (user.LastName?.Length > 50)
            ModelState.AddModelError(
                nameof(user.LastName),
                "Last name cannot exceed 50 characters.");

        if (user.UserBio?.Length > 1000)
            ModelState.AddModelError(
                nameof(user.UserBio),
                "Biography cannot exceed 1000 characters.");

        if (!ModelState.IsValid)
            return View(user);

        var result = await _userRepo.UpdateAsync(id, user);

        if (result is null)
        {
            ModelState.AddModelError(
                "",
                "Unable to update your profile.");

            return View(user);
        }

        TempData["SuccessMessage"] =
            "Profile updated successfully!";

        return RedirectToAction(nameof(Profile));
    }


    // GET: /Users/Dashboard
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Dashboard()
    {
        // Get the currently logged-in user's ID
        var id = User.FindFirstValue(
            ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(id))
        {
            return Challenge();
        }

        // Retrieve dashboard information
        var user = await _userRepo.ReadDashboardAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        return View(user);
    }

}
