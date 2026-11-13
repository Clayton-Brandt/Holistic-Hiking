using Holistic_Hiking.Data;
using Holistic_Hiking.Models.DTOs;
using Holistic_Hiking.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Holistic_Hiking.Controllers;

public class CommentsController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<User> _userManager;

    public CommentsController(ApplicationDbContext db, UserManager<User> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    private string? CurrentUserId =>
        User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

    // GET /Comments/ForTrail?trailId=5
    [HttpGet]
    public async Task<IActionResult> ForTrail(int trailId)
    {
        var trailExists = await _db.Trails.AnyAsync(t => t.TrailId == trailId);
        if (!trailExists) return NotFound();

        var comments = await _db.Comments
            .Where(c => c.TrailId == trailId)
            .OrderByDescending(c => c.CreatedAt)
            .Select(c => new
            {
                c.CommentId,
                c.Text,
                c.UserId,
                UserName = c.User != null ? c.User.UserName : null,
                c.CreatedAt,
                c.UpdatedAt
            })
            .ToListAsync();

        return Json(comments);
    }

    // POST /Comments/Create
    [HttpPost]
    [Authorize]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> Create([FromBody] CreateCommentDto dto)
    {
        var userId = CurrentUserId;
        if (userId is null) return Unauthorized();

        if (string.IsNullOrWhiteSpace(dto.Text))
            return BadRequest(new { error = "Comment text cannot be empty." });

        if (dto.Text.Length > 2000)
            return BadRequest(new { error = "Comment text cannot exceed 2000 characters." });

        var trailExists = await _db.Trails.AnyAsync(t => t.TrailId == dto.TrailId);
        if (!trailExists) return NotFound(new { error = "Trail not found." });

        var comment = new Comment
        {
            TrailId = dto.TrailId,
            UserId = userId,
            Text = dto.Text.Trim(),
            CreatedAt = DateTime.UtcNow
        };

        _db.Comments.Add(comment);
        await _db.SaveChangesAsync();

        var userName = (await _userManager.FindByIdAsync(userId))?.UserName;

        return Json(new
        {
            comment.CommentId,
            comment.Text,
            comment.UserId,
            UserName = userName,
            comment.CreatedAt,
            comment.UpdatedAt
        });
    }

    // PUT /Comments/Update
    [HttpPut]
    [Authorize]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> Update([FromBody] UpdateCommentDto dto)
    {
        var userId = CurrentUserId;
        if (userId is null) return Unauthorized();

        if (string.IsNullOrWhiteSpace(dto.Text))
            return BadRequest(new { error = "Comment text cannot be empty." });

        if (dto.Text.Length > 2000)
            return BadRequest(new { error = "Comment text cannot exceed 2000 characters." });

        var comment = await _db.Comments.FirstOrDefaultAsync(c => c.CommentId == dto.CommentId);
        if (comment is null) return NotFound(new { error = "Comment not found." });
        if (comment.UserId != userId) return Forbid();

        comment.Text = dto.Text.Trim();
        comment.UpdatedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();
        return Ok();
    }

    // DELETE /Comments/Delete/7
    [HttpDelete]
    [Authorize]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = CurrentUserId;
        if (userId is null) return Unauthorized();

        var comment = await _db.Comments.FirstOrDefaultAsync(c => c.CommentId == id);
        if (comment is null) return NotFound(new { error = "Comment not found." });
        if (comment.UserId != userId) return Forbid();

        _db.Comments.Remove(comment);
        await _db.SaveChangesAsync();
        return Ok();
    }
}
