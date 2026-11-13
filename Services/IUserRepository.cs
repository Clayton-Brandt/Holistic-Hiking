using Holistic_Hiking.Models.Entities;

namespace Holistic_Hiking.Services;

public interface IUserRepository
{
    // Read one user
    Task<User?> ReadAsync(string id);

    // Read all users
    Task<IEnumerable<User>> ReadAllAsync();

    // Update user profile
    Task<User?> UpdateAsync(string id, User user);

    // Read user information for dashboard
    Task<User?> ReadDashboardAsync(string id);
}
