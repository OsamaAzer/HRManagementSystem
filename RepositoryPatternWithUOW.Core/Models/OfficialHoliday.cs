
namespace RepositoryPatternWithUOW.Core.Models
{
    public class OfficialHoliday
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public DateOnly Date {  get; set; }
    }
}
