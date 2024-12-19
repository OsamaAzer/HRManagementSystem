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
                return NotFound($"Official holiday with ID: {id} not found");

            return Ok(holiday);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var holidays = await unitOfWork.OfficialHolidays.FindAll();

            if (holidays.Count() == 0)
                return NotFound("No official holidays found!");

            IEnumerable<OfficialHolidayDTO> holidaysDto = new List<OfficialHolidayDTO>();

            holidaysDto = holidays.Adapt(holidaysDto);

            return Ok(holidaysDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] OfficialHolidayDTO dto)
        {
            if (dto == null)
                return BadRequest("Official holiday data is required.");

            var holiday = dto.Adapt<OfficialHoliday>();

            await unitOfWork.OfficialHolidays.Add(holiday);

            unitOfWork.Complete();

            return Ok(holiday);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] OfficialHolidayDTO dto)
        {
            OfficialHoliday holiday = await unitOfWork.OfficialHolidays.GetById(id);

            if (holiday is null)
                return NotFound($"There is no official holiday with ID: {id}");

            holiday = dto.Adapt(holiday);

            unitOfWork.OfficialHolidays.Update(holiday);

            unitOfWork.Complete();

            return Ok(holiday);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoliday(int id)
        {
            var holiday = await unitOfWork.OfficialHolidays.GetById(id);

            if (holiday is null)
                return NotFound($"The official holiday with ID: {id} doesn't exist!!!");

            unitOfWork.OfficialHolidays.Delete(holiday);

            unitOfWork.Complete();

            return Ok(holiday);
        }
    }
}
