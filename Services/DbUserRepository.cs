using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Holistic_Hiking.Models.Entities;
using Holistic_Hiking.Data;

namespace Holistic_Hiking.Services;

public class DbUserRepository : IUserRepository
{
    // Dependency injection of ApplicationDbContext
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;

    // Constructor for DbUserRepository
    public DbUserRepository(ApplicationDbContext context, UserManager<User> userManager)
    {
        // Assign the injected ApplicationDbContext to the private field
        _context = context;
        _userManager = userManager;
    }

    // Read one User
    public async Task<User?> ReadAsync (string Id)
    {
        return await _context.Users
            .Include(u => u.Comments)
            .FirstOrDefaultAsync(u => u.Id == Id);
    }

    // Read all Users
    public async Task<IEnumerable<User>> ReadAllAsync()
    {
        return await _context.Users
            .Include(u => u.Comments)
            .ToListAsync();
    }

    // Update User
    public async Task<User?> UpdateAsync(string oldId, User user)
    {
        // Find the existing user by its ID
        var existing = await _userManager.FindByIdAsync(oldId);
        // If the user does not exist, return null
        if (existing is null)
        {
            return null;
        }
        // Update the properties of the existing user with the new values
        existing.FirstName = user.FirstName;
        existing.LastName = user.LastName;
        existing.UserBio = user.UserBio;
        // Save changes to the database and return the updated expense
        var result = await _userManager.UpdateAsync(existing);

        return result.Succeeded ? existing : null;
    }

}