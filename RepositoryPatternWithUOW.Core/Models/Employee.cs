using RepositoryPatternWithUOW.Core.Enums;
using System.Text.Json.Serialization;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string? FullName { get; set; }

        public Gender Gender { get; set; }

        public string? Address { get; set; }

        public string? Nationality { get; set; }
        
        public string? JobTitle { get; set; }

        public long? PhoneNumber {  get; set; }

        public DateOnly? ContractDate { get; set; }

        public TimeOnly? ArrivalTime { get; set; }

        public TimeOnly? DepartureTime { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department? Department { get; set; }

        [JsonIgnore]
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

        [JsonIgnore]
        public virtual ICollection<SpecialLeave> SpecialLeaves { get; set; } = new List<SpecialLeave>();

        public int ApplicationUserId { get; set; }

        public virtual ApplicationUser? ApplicationUser { get; set; }
    }
}
