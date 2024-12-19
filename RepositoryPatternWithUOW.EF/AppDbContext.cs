using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.Enums;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<OfficialHoliday> OfficialHolidays { get; set; }

        public DbSet<SpecialLeave> SpecialLeaves { get; set; }

        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Gender)
                .HasConversion(
                    v => v.ToString(),
                    v => (Gender)Enum.Parse(typeof(Gender), v)
                );

            modelBuilder.Entity<Attendance>()
                .Property(a => a.Status)
                .HasConversion(
                    v => v.ToString(), // Enum to string for database storage
                    v => (AttendanceStatus)Enum.Parse(typeof(AttendanceStatus), v) // String to enum for entity
                );
        }
    }
}
