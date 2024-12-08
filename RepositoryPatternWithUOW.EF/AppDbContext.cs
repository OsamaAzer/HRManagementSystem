using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //DbSets
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
