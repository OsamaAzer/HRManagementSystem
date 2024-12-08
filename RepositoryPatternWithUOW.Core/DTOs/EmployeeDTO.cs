
using RepositoryPatternWithUOW.Core.Enums;

namespace RepositoryPatternWithUOW.Core.DTOs
{
    public class EmployeeDTO
    {
        public string FullName { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; }

        public string Nationality { get; set; }

        public string JobTitle { get; set; }

        public long PhoneNumber { get; set; }

        public DateOnly DateOfJoin { get; set; }

        public TimeOnly Arrival { get; set; }

        public TimeOnly Departure { get; set; }

        public int? DepartmentId { get; set; }
    }
}
