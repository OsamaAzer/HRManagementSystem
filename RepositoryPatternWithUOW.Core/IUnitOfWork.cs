using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.Core
{
    public interface IUnitOfWork : IDisposable
    {
        public IBaseRepository<Department> Departments { get; }

        public IBaseRepository<Employee> Employees { get; }

        public IBaseRepository<Attendance> Attendences { get; }

        public IBaseRepository<OfficialHoliday> OfficialHolidays { get; }

        public IBaseRepository<SpecialLeave> SpecialLeaves { get; }

        int Complete();
    }
}
