
using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternWithUOW.Core.DTOs
{
    public class EmployeeRegisterDTO
    {
        public string FullName { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string Nationality { get; set; }

        public long PhoneNumber { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
