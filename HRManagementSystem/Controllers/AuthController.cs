using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.DTOs;
using RepositoryPatternWithUOW.Core.Enums;
using RepositoryPatternWithUOW.Core.Helpers;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.EF;

namespace HRManagementSystem.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthController(IUnitOfWork unitOfWork, JwtService jwtService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] EmployeeRegisterDTO dto)
        {
            if (await unitOfWork.Employees.FindOne(e => e.Username == dto.Username) is not null)
                return BadRequest("The Username is already exists");

            var employee = new Employee();

            employee = dto.Adapt(employee);

            //var employee = new Employee
            //{
            //    FullName = dto.FullName,
            //    Username = dto.Username,
            //    Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            //    Nationality = dto.Nationality,
            //    PhoneNumber = dto.PhoneNumber,
            //    Email = dto.Email,
            //    Address = dto.Address,
            //    Gender = dto.Gender.GetEnumFromDisplayName()
            //};

            await unitOfWork.Employees.Add(employee);

            unitOfWork.Complete();

            return Ok("User registered successfully.");

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            var employee = await unitOfWork.Employees.FindOne(e => e.Username == loginDto.Username);

            if (employee == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, employee.Password))
            {
                return Unauthorized("Invalid Username or Password!");
            }

            var tokenRequestDTO = new TokenRequestDTO();

            tokenRequestDTO = loginDto.Adapt(tokenRequestDTO);

            //var tokenRequestDTO = new TokenRequestDTO
            //{
            //    Username = employee.Username,
            //    Role = employee.Role.Name
            //};

            var token = jwtService.GenerateToken(tokenRequestDTO);

            return Ok(new { Token = token });
        }
    }
}
