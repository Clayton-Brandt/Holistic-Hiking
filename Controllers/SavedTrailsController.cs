
using Holistic_Hiking.Data;
using Holistic_Hiking.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Holistic_Hiking.Controllers;

[Authorize]
public class SavedTrailsController : Controller
{
    private readonly ApplicationDbContext _context;

    public SavedTrailsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // POST: /SavedTrails/Save
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Save(int trailId)
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
            return Challenge();

        bool trailExists = await _context.Trails
            .AnyAsync(t => t.TrailId == trailId);

        if (!trailExists)
            return NotFound();

        bool alreadySaved = await _context.SavedTrails
            .AnyAsync(s => s.UserId == userId && s.TrailId == trailId);

        if (!alreadySaved)
        {
            var savedTrail = new SavedTrail
            {
                UserId = userId,
                TrailId = trailId
            };

            _context.SavedTrails.Add(savedTrail);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Dashboard", "Users");
    }

    // POST: /SavedTrails/Remove
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int trailId)
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
            return Challenge();

        var savedTrail = await _context.SavedTrails
            .FirstOrDefaultAsync(s =>
                s.UserId == userId &&
                s.TrailId == trailId);

        if (savedTrail != null)
        {
            _context.SavedTrails.Remove(savedTrail);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Dashboard", "Users");
    }
}
