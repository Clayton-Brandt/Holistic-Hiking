using Holistic_Hiking.Models.Entities;

namespace Holistic_Hiking.Services;

public interface IUserRepository
{
    // Create User
    Task<User> CreateAsync (User user);

    // Read One User
    Task<User?> ReadAsync (int Id);

    // Read All Users 
    Task<IEnumerable<User>> ReadAllAsync ();

    // Update Users
    Task<User?> UpdateAsync (int OldId, User user);

    // Delete Users
    Task<bool> DeleteAsync (int Id);
}