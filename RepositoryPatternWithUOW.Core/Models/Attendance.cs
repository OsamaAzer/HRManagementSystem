﻿using RepositoryPatternWithUOW.Core.Enums;
using System.ComponentModel.DataAnnotations;
namespace RepositoryPatternWithUOW.Core.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        [EnumDataType(typeof(AttendanceStatus))]
        public AttendanceStatus Status { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly ArrivingTime { get; set; }

        public TimeOnly LeavingTime { get; set; }

        public int OverTimeHours { get; set; }

        public int LateTimeHours { get; set; }

        public int? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }

    }
}
