using Holistic_Hiking.Models.Entities;

namespace Holistic_Hiking.Services;

public interface IUserRepository
{
    // Read One User
    Task<User?> ReadAsync(string Id);

    // Read All Users 
    Task<IEnumerable<User>> ReadAllAsync ();

    // Update Users
    Task<User?> UpdateAsync(string OldId, User user);

}