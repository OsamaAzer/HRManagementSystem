using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.DTOs;
using RepositoryPatternWithUOW.Core.Enums;
using RepositoryPatternWithUOW.Core.Helpers;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.EF;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRManagementSystem.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[Controller]")]
    public class AuthController(IUnitOfWork unitOfWork, JWT jwt) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] EmployeeSigningInfoDTO dto)
        {
            if (await unitOfWork.EmployeeSigningInfo.FindOne(e => e.Username == dto.Username) is not null)
                return BadRequest("The Username is already exists");

            var employeeInfo = new EmployeeSigningInfo();

            employeeInfo = dto.Adapt(employeeInfo);
            employeeInfo.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await unitOfWork.EmployeeSigningInfo.Add(employeeInfo);

            unitOfWork.Complete();

            return Ok("User registered successfully.");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            //var isVerified = BCrypt.Net.BCrypt.Verify(loginDto.Password, Employee.)

            var employee = await unitOfWork.EmployeeSigningInfo
                .FindOne(e => e.Email == loginDto.Email);

            if (employee == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, employee.Password))
                return Unauthorized("Invalid Username or Password!");

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = jwt.Issuer,
                Audience = jwt.Audience,
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SigningKey)), SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, employee.Id.ToString()),
                    new(ClaimTypes.Email, employee.Email),
                    new(ClaimTypes.Role, "Admin"),
                    new(ClaimTypes.Role, "User")
                })
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var accessToken = tokenHandler.WriteToken(securityToken);

            return Ok(accessToken);
        }
    }
}
