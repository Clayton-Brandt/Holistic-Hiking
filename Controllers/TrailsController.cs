using Microsoft.AspNetCore.Mvc; 
using Holistic_Hiking.Models.Entities;
using Holistic_Hiking.Services;

namespace Holistic_Hiking.Controllers;

public class TrailsController : Controller
{
    private readonly ITrailRepository _trailRepo;

    public TrailsController (ITrailRepository trailRepo)
    {
        _trailRepo = trailRepo;
    }

    public async Task<IActionResult> Index ()
    {
        var trail = await _trailRepo.ReadAllAsync();
        return View(trail);
    }

    public async Task<IActionResult> Details (int id)
    {
        var trail = await _trailRepo.ReadAsync(id);
        if (trail == null)
        {
            return NotFound();
        }
        return View(trail);
    }
}