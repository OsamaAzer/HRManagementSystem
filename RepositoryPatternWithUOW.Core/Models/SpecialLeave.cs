
namespace RepositoryPatternWithUOW.Core.Models
{
    public class SpecialLeave
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateOnly Date {  get; set; }
        
        public int? EmployeeId {  get; set; }
        
        public virtual Employee? Employee { get; set; }
    }
}
