using Mapster;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.DTOs;
using RepositoryPatternWithUOW.Core.Models;

namespace HRManagementSystem.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RolesController(IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var role = await unitOfWork.Roles.GetById(id);

            if (role == null)
                return NotFound($"Role with ID: {id} not found");

            return Ok(role);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var roles = await unitOfWork.Roles.FindAll();

            if (roles.Count() == 0)
                return NotFound("No Roles found!");

            IEnumerable<RoleDTO> rolesDto = new List<RoleDTO>();

            rolesDto = roles.Adapt(rolesDto);

            return Ok(rolesDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RoleDTO dto)
        {
            if (dto == null)
                return BadRequest("Role data is required.");

            var role = dto.Adapt<Role>();

            await unitOfWork.Roles.Add(role);

            unitOfWork.Complete();

            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] RoleDTO dto)
        {
            var role = await unitOfWork.Roles.GetById(id);

            if (role is null)
                return NotFound($"There is no Role with ID: {id}");

            role = dto.Adapt(role);

            unitOfWork.Roles.Update(role);

            unitOfWork.Complete();

            return Ok(role);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoliday(int id)
        {
            var role = await unitOfWork.Roles.GetById(id);

            if (role is null)
                return NotFound($"The Role with ID: {id} doesn't exist!!!");

            unitOfWork.Roles.Delete(role);

            unitOfWork.Complete();

            return Ok(role);
        }
    }
}
