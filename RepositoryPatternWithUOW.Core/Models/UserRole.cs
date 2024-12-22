
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class UserRole
    {
        public int Id { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
