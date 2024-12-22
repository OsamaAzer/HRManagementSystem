
using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternWithUOW.Core.DTOs
{
    public class RegisterDTO : AccountBase
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string? FullName { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
