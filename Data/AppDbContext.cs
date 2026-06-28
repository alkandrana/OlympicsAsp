using Microsoft.EntityFrameworkCore;
using OlympicsAsp.Models;

namespace OlympicsAsp;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Goal> Goals => Set<Goal>();
    public DbSet<Session> Sessions => Set<Session>();
}
