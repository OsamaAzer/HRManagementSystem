
using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternWithUOW.Core.DTOs
{
    public class AccountBase
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Password { get; set; }
    }
}
