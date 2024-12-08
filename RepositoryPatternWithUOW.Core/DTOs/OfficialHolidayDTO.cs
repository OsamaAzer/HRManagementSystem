
namespace RepositoryPatternWithUOW.Core.DTOs
{
    public class OfficialHolidayDTO
    {
        public string Name { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public DateOnly Date { get; set; }
    }
}
