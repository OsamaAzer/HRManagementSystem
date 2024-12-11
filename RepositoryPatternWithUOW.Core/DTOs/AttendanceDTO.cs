
using RepositoryPatternWithUOW.Core.Enums;

namespace RepositoryPatternWithUOW.Core.DTOs
{
    public class AttendanceDTO
    {
        public AttendanceStatus Status { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly ArrivingTime { get; set; }

        public TimeOnly LeavingTime { get; set; }

        public int OverTimeHours { get; set; }

        public int LateTimeHours { get; set; }

        public int? EmployeeId { get; set; }
    }
}
