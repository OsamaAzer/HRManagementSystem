using RepositoryPatternWithUOW.Core.Enums;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; }

        public string Nationality { get; set; }
        
        public string? JobTitle { get; set; }

        public long PhoneNumber {  get; set; }

        public DateOnly? ContractDate { get; set; }

        public TimeOnly? ArrivalTime { get; set; }

        public TimeOnly? DepartureTime { get; set; }

        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

        public virtual ICollection<SpecialLeave> SpecialLeaves { get; set; } = new List<SpecialLeave>();

        // For Authentication
        public string Username { get; set; }

        public string Email {  get; set; }

        public string Password { get; set; }
        //
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
    }
}
