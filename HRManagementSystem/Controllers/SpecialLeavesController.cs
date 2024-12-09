using Mapster;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.DTOs;
using RepositoryPatternWithUOW.Core.Models;

namespace HRManagementSystem.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SpecialLeavesController(IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var specialLeave = await unitOfWork.SpecialLeaves.GetById(id);

            if (specialLeave == null)
                return NotFound($"Special Leave with ID: {id} not found");

            return Ok(specialLeave);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var specialLeave = await unitOfWork.SpecialLeaves.Find();

            if (specialLeave.Count() == 0)
                return NotFound("No Special Leaves found!");

            return Ok(specialLeave);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SpecialLeaveDTO dto)
        {
            if (dto == null)
                return BadRequest("Special Leave data is required.");

            var specialLeave = dto.Adapt<SpecialLeave>();

            await unitOfWork.SpecialLeaves.Add(specialLeave);

            unitOfWork.Complete();

            return Ok(specialLeave);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SpecialLeaveDTO dto)
        {
            var specialLeave = await unitOfWork.SpecialLeaves.GetById(id);

            if (specialLeave is null)
                return NotFound($"There is no Special Leave with ID: {id}");

            specialLeave.Name = dto.Name;
            specialLeave.DayOfWeek = dto.DayOfWeek;
            specialLeave.Date = dto.Date;

            unitOfWork.SpecialLeaves.Update(specialLeave);

            unitOfWork.Complete();

            return Ok(specialLeave);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoliday(int id)
        {
            var specialLeave = await unitOfWork.SpecialLeaves.GetById(id);

            if (specialLeave is null)
                return NotFound($"The Special Leave with ID: {id} doesn't exist!!!");

            unitOfWork.SpecialLeaves.Delete(specialLeave);

            unitOfWork.Complete();

            return Ok(specialLeave);
        }
    }
}
