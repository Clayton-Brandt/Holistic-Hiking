using Holistic_Hiking.Models.Entities;

namespace Holistic_Hiking.Services;

public interface ITrailRepository
{
    // Create Trail
    Task<Trail> CreateAsync (Trail trail);

    // Read One Trail
    Task<Trail?> ReadAsync (int Id);

    // Read All Trails 
    Task<IEnumerable<Trail>> ReadAllAsync ();

    // Update Trail
    Task<Trail?> UpdateAsync (int OldId, Trail trail);

    // Delete Trail
    Task<bool> DeleteAsync (int Id);
}