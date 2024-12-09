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

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<OfficialHoliday> OfficialHolidays { get; set; }

        public DbSet<SpecialLeave> SpecialLeaves { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Employee>().Property("Gender").HasConversion<String>();

        //    modelBuilder.Entity<SpecialLeave>().Property("DayOfWeek").HasConversion<String>();

        //    modelBuilder.Entity<OfficialHoliday>().Property("DayOfWeek").HasConversion<String>();

        //    modelBuilder.Entity<Attendance>().Property("AttendanceStatus").HasConversion<String>();

        //    modelBuilder.Entity<Attendance>().Property("DayOfWeek").HasConversion<String>();
        //}
    }
}
