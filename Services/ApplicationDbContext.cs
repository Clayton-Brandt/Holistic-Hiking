using Microsoft.EntityFrameworkCore;
using Holistic_Hiking.Models.Entities;

namespace Holistic_Hiking.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext (DbContextOptions options) : base (options)
    {
        
    }

    
}