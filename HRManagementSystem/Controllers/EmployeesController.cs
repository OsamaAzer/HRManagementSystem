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
    public class EmployeesController(IUnitOfWork unitOfWork) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var employee = await unitOfWork.Employees.GetById(id);

            if (employee == null)
                return NotFound($"Employee with ID: {id} not found");

            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var employees = await unitOfWork.Employees.FindAll(["Department"]);

            if (employees.Count() == 0)
                return NotFound("No employees found!");

            //IEnumerable<EmployeeDTO> employeesDto = new List<EmployeeDTO>();

            //employeesDto = employees.Adapt(employeesDto);

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeDTO dto)
        {
            var employee = dto.Adapt<Employee>();

            await unitOfWork.Employees.Add(employee);

            unitOfWork.Complete();

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] EmployeeDTO dto)
        {
            Employee employee = await unitOfWork.Employees.GetById(id);

            if (employee is null)
                return NotFound($"There is no employee with ID: {id}");

            if (dto is null)
                return BadRequest("Please enter the data to be modified.");

            employee = dto.Adapt(employee);

            unitOfWork.Employees.Update(employee);

            unitOfWork.Complete();

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await unitOfWork.Employees.GetById(id);

            if (employee is null)
                return NotFound($"The employee doesn't exist!!!");

            unitOfWork.Employees.Delete(employee);

            unitOfWork.Complete();

            return Ok(employee);
        }
    }
}
