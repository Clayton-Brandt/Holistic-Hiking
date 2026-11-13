using Holistic_Hiking.Data;
using Holistic_Hiking.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Holistic_Hiking.Services;

public class DbUserRepository : IUserRepository
{
    // Dependency injection
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;

    // Constructor
    public DbUserRepository(
        ApplicationDbContext context,
        UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // Read one user
    public async Task<User?> ReadAsync(string id)
    {
        return await _context.Users
            .Include(u => u.Comments)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    // Read all users
    public async Task<IEnumerable<User>> ReadAllAsync()
    {
        return await _context.Users
            .Include(u => u.Comments)
            .ToListAsync();
    }

    // Update user profile
    public async Task<User?> UpdateAsync(string id, User user)
    {
        // Find existing user
        var existing = await _userManager.FindByIdAsync(id);

        if (existing is null)
        {
            return null;
        }

        // Update profile information
        existing.FirstName = user.FirstName;
        existing.LastName = user.LastName;
        existing.UserBio = user.UserBio;

        // Save changes through Identity
        var result = await _userManager.UpdateAsync(existing);

        return result.Succeeded ? existing : null;
    }
}
