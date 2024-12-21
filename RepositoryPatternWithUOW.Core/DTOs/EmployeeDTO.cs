
using RepositoryPatternWithUOW.Core.Enums;

namespace RepositoryPatternWithUOW.Core.DTOs
{
    public class EmployeeDTO
    {
        public string FullName { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string Nationality { get; set; }

        public string JobTitle { get; set; }

        public long PhoneNumber { get; set; }

        public DateOnly ContractDate { get; set; }

        public TimeOnly ArrivalTime { get; set; }

        public TimeOnly DepartureTime { get; set; }

        public int? DepartmentId { get; set; }

        public int? RoleId { get; set; }

        public int? EmployeeSigningInfoId { get; set; }
    }
}
