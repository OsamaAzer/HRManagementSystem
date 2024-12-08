using Mapster;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.DTOs;
using RepositoryPatternWithUOW.Core.Models;

namespace HRManagementSystem.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OfficialHolidaysController(IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var holiday = await unitOfWork.OfficialHolidays.GetById(id);

            if (holiday == null)
                return NotFound($"Holiday with ID: {id} not found");

            return Ok(holiday);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var holiday = await unitOfWork.OfficialHolidays.Find();

            if (holiday is null)
                return NotFound("No holidays found!");

            return Ok(holiday);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] OfficialHolidayDTO dto)
        {
            if (dto == null)
                return BadRequest("Holiday data is required.");

            var holiday = dto.Adapt<OfficialHoliday>();

            await unitOfWork.OfficialHolidays.Add(holiday);

            unitOfWork.Complete();

            return Ok(holiday);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] OfficialHolidayDTO dto)
        {
            var holiday = await unitOfWork.OfficialHolidays.GetById(id);

            if (holiday is null)
                return NotFound($"There is no holiday with ID: {id}");

            holiday.Name = dto.Name;
            holiday.DayOfWeek = dto.DayOfWeek;
            holiday.Date = dto.Date;

            unitOfWork.OfficialHolidays.Update(holiday);

            unitOfWork.Complete();

            return Ok(holiday);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoliday(int id)
        {
            var holiday = await unitOfWork.OfficialHolidays.GetById(id);

            if (holiday is null)
                return NotFound($"The holiday with ID: {id} doesn't exist!!!");

            unitOfWork.OfficialHolidays.Delete(holiday);

            unitOfWork.Complete();

            return Ok(holiday);
        }
    }
}
