using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.EF.Repositories;

namespace RepositoryPatternWithUOW.EF
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        //Entities initialization
        public IBaseRepository<Department> Departments { get; private set; } = new BaseRepository<Department>(context);

        public IBaseRepository<Employee> Employees { get; private set; } = new BaseRepository<Employee>(context);

        public IBaseRepository<Attendance> Attendences { get; private set; } = new BaseRepository<Attendance>(context);

        public IBaseRepository<OfficialHoliday> OfficialHolidays { get; private set; } = new BaseRepository<OfficialHoliday>(context);

        public IBaseRepository<SpecialLeave> SpecialLeaves { get; private set; } = new BaseRepository<SpecialLeave>(context);

        public IBaseRepository<Role> Roles { get; private set; } = new BaseRepository<Role>(context);

        public IBaseRepository<UserRole> UserRoles { get; private set; } = new BaseRepository<UserRole>(context);

        public IBaseRepository<ApplicationUser> ApplicationUsers { get; private set;} = new BaseRepository<ApplicationUser>(context);

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
