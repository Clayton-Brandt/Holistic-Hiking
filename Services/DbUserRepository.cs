using Microsoft.EntityFrameworkCore;
using Holistic_Hiking.Models.Entities;
using Holistic_Hiking.Data;

namespace Holistic_Hiking.Services;

public class DbUserRepository : IUserRepository
{
    // Dependency injection of ApplicationDbContext
    private readonly ApplicationDbContext _context;

    // Constructor for DbUserRepository
    public DbUserRepository(ApplicationDbContext context)
    {
        // Assign the injected ApplicationDbContext to the private field
        _context = context;
    }

    // Create User
    public async Task<User> CreateAsync (User user)
    {
        // Add the new user to the DbSet and save changes
        _context.Users.Add(user);
        // Save changes to the database
        await _context.SaveChangesAsync();
        // Return the newly created user
        return user;
    }

    // Read one User
    public async Task<User?> ReadAsync (int Id)
    {
        return await _context.Users.Include(u => u.Comments).FirstOrDefaultAsync(u => u.UserId == Id);
    }

    // Read all Users
    public async Task<IEnumerable<User>> ReadAllAsync()
    {
        return await _context.Users.Include(u => u.Comments).ToListAsync();
    }

    // Update User
    public async Task<User?> UpdateAsync(int oldId, User user)
    {
        // Find the existing user by its ID
        var existing = await _context.Users.FindAsync(oldId);
        // If the user does not exist, return null
        if (existing is null)
        {
            return null;
        }
        // Update the properties of the existing user with the new values
        existing.UserName = user.UserName;
        existing.FirstName = user.FirstName;
        existing.LastName = user.LastName;
        existing.Email = user.Email;
        existing.UserBio = user.UserBio;
        // Save changes to the database and return the updated expense
        await _context.SaveChangesAsync();
        return existing;
    }

    // Delete User
    public async Task<bool> DeleteAsync (int Id)
    {
        // Find the existing user by its ID
        var existing = await _context.Users.FindAsync(Id);
        // If the user does not exist, return false
        if (existing is null)
        {
            return false;
        }
        
        // Remove the existing user from the DbSet and save changes
        _context.Users.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}