
namespace RepositoryPatternWithUOW.Core.DTOs
{
    public class SpecialLeaveDTO
    {
        public string Name { get; set; }

        public DateOnly Date { get; set; }

        public int? EmployeeId { get; set; }
    }
}
