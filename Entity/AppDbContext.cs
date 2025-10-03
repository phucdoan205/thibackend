using BackendMidterm.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendMidterm.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Class> Classes => Set<Class>();
    public DbSet<Student> Students => Set<Student>();
}
