using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.DTOs;
using RepositoryPatternWithUOW.Core.Models;

namespace HRManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[Controller]")]
    public class DepartmentsController(IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var department = await unitOfWork.Departments.GetById(id);

            if (department == null)
                return NotFound($"Department with ID: {id} not found");

            return Ok(department);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var departments = await unitOfWork.Departments.FindAll();

            if (departments.Count() == 0)
                return NotFound("No departments found!");

            //IEnumerable<DepartmentDTO> departmentsDto = new List<DepartmentDTO>();

            //departmentsDto = departments.Adapt(departmentsDto);

            return Ok(departments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DepartmentDTO dto)
        {
            if (dto == null)
                return BadRequest("Department data is required.");

            var department = dto.Adapt<Department>();

            await unitOfWork.Departments.Add(department);

            unitOfWork.Complete();

            return Ok(department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] DepartmentDTO dto)
        {
            var department = await unitOfWork.Departments.GetById(id);

            if (department is null)
                return NotFound($"There is no Department with ID: {id}");

            department = dto.Adapt(department);

            unitOfWork.Departments.Update(department);

            unitOfWork.Complete();

            return Ok(department);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await unitOfWork.Departments.GetById(id);

            if (department is null)
                return NotFound($"The department with ID: {id} doesn't exist!!!");

            unitOfWork.Departments.Delete(department);

            unitOfWork.Complete();

            return Ok(department);
        }
    } 
}
