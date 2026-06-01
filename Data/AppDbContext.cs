using Microsoft.EntityFrameworkCore;
using OlympicsAsp.Models;
namespace OlympicsAsp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Goal> Goals => Set<Goal>();
}
