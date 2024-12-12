using Mapster;
using RepositoryPatternWithUOW.Core.DTOs;
using RepositoryPatternWithUOW.Core.Models;

namespace HRManagementSystem
{
    public static class MappingConfiguration
    {
        public static void ConfigureMapster()
        {
            TypeAdapterConfig<Employee, EmployeeDTO>.NewConfig().Map(des => des.Gender, src => src.Gender.ToString());

            TypeAdapterConfig<EmployeeDTO, Employee>.NewConfig().Map(des => des.Gender.ToString(), src => src.Gender);

            TypeAdapterConfig<Attendance, AttendanceDTO>.NewConfig().Map(des => des.Status, src => src.Status.ToString());

            TypeAdapterConfig<AttendanceDTO, Attendance>.NewConfig().Map(des => des.Status.ToString(), src => src.Status);
        }
    }
}
