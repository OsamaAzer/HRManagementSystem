
using System.Text.Json.Serialization;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
