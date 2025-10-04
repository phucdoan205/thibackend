using Microsoft.EntityFrameworkCore;
using thibackend.Models;

namespace thibackend.Entity;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<StudentModel> Students { get; set; }
    
    public DbSet<ClassModel> Classes { get; set; }
}