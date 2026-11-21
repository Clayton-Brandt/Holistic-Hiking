using Holistic_Hiking.Data;
using Holistic_Hiking.Models.DTOs;
using Holistic_Hiking.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Holistic_Hiking.Controllers;

public class RatingsController : Controller
{
    private readonly ApplicationDbContext _db;

    public RatingsController(ApplicationDbContext db)
    {
        _db = db;
    }

    private string? CurrentUserId =>
        User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

    // GET /Ratings/ForTrail?trailId=5
    // Public — returns average + count, plus this user's rating if logged in
    [HttpGet]
    public async Task<IActionResult> ForTrail(int trailId)
    {
        var trailExists = await _db.Trails.AnyAsync(t => t.TrailId == trailId);
        if (!trailExists) return NotFound();

        var ratings = await _db.Ratings
            .Where(r => r.TrailId == trailId)
            .ToListAsync();

        var userId = CurrentUserId;

        var dto = new TrailRatingSummaryDto
        {
            TrailId = trailId,
            Count = ratings.Count,
            Average = ratings.Count == 0 ? 0 : Math.Round(ratings.Average(r => r.Value), 2),
            MyRating = userId is null
                ? null
                : ratings.FirstOrDefault(r => r.UserId == userId)?.Value
        };

        return Json(dto);
    }

    // POST /Ratings/Rate  (body: { trailId, value })
    // Upsert: if the user already rated this trail, update it
    [HttpPost]
    [Authorize]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> Rate([FromBody] RateTrailDto dto)
    {
        var userId = CurrentUserId;
        if (userId is null) return Unauthorized();

        if (dto.Value < 1 || dto.Value > 5)
            return BadRequest(new { error = "Rating must be between 1 and 5." });

        var trailExists = await _db.Trails.AnyAsync(t => t.TrailId == dto.TrailId);
        if (!trailExists) return NotFound(new { error = "Trail not found." });

        var existing = await _db.Ratings
            .FirstOrDefaultAsync(r => r.TrailId == dto.TrailId && r.UserId == userId);

        if (existing is null)
        {
            _db.Ratings.Add(new Rating
            {
                TrailId = dto.TrailId,
                UserId = userId,
                Value = dto.Value,
                CreatedAt = DateTime.UtcNow
            });
        }
        else
        {
            existing.Value = dto.Value;
            existing.UpdatedAt = DateTime.UtcNow;
        }

        await _db.SaveChangesAsync();

        // Return updated summary so the frontend can refresh in one call
        return await ForTrail(dto.TrailId);
    }

    // DELETE /Ratings/Delete?trailId=5  (removes the current user's rating for this trail)
    [HttpDelete]
    [Authorize]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> Delete(int trailId)
    {
        var userId = CurrentUserId;
        if (userId is null) return Unauthorized();

        var rating = await _db.Ratings
            .FirstOrDefaultAsync(r => r.TrailId == trailId && r.UserId == userId);

        if (rating is null) return NotFound(new { error = "You have not rated this trail." });

        _db.Ratings.Remove(rating);
        await _db.SaveChangesAsync();

        return await ForTrail(trailId);
    }
}