using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.DTOs;
using RepositoryPatternWithUOW.Core.Helpers;
using RepositoryPatternWithUOW.Core.Models;
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
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            if (dto is null)
                return BadRequest("Data is required!!");

            if (await unitOfWork.ApplicationUsers.FindOne(e => e.Email == dto.Email) is not null)
                return BadRequest("The Username is already exists");

            //var employeeInfo = new ApplicationUser();

            var employeeInfo = dto.Adapt<ApplicationUser>();

            employeeInfo.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await unitOfWork.ApplicationUsers.Add(employeeInfo);

            unitOfWork.Complete();

            return Ok("User registered successfully.");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            if(loginDto is null)
                return Unauthorized("Credentials are required");

            var applicationUser = await unitOfWork.ApplicationUsers
                .FindOne(e => e.Email!.ToLower() == loginDto.Email!.ToLower());

            if (applicationUser == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, applicationUser.Password))
                return Unauthorized("Invalid Username or Password!");

            var userRole = await unitOfWork.UserRoles.FindOne(x => x.ApplicationUserId == applicationUser.Id);

            if (userRole is null)
                return Unauthorized("User Role not found!");

            var role = await unitOfWork.Roles.FindOne(x => x.Id == userRole.Id);

            if (role is null)
                return Unauthorized("User Role not found!");

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = jwt.Issuer,

                Audience = jwt.Audience,

                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SigningKey)), SecurityAlgorithms.HmacSha256),

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, applicationUser.Id.ToString()),
                    new(ClaimTypes.Email, applicationUser.Email!),
                    new(ClaimTypes.Name, applicationUser.FullName!),
                    new(ClaimTypes.Role, role.Name)
                }),

                Expires = DateTime.Now.AddMinutes(30)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var accessToken = tokenHandler.WriteToken(securityToken);

            return Ok(accessToken);
        }
    }
}
