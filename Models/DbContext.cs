using Microsoft.EntityFrameworkCore;
using SalesTracker_RJLOZANSKI.Models;

namespace SalesTracker_RJLOZANSKI.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }

    public DbSet<SalesRep> SalesReps {get; set;}
    public DbSet<Deal> Deals {get; set;}
}