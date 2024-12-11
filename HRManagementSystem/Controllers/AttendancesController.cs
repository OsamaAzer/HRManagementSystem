using Mapster;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.DTOs;
using RepositoryPatternWithUOW.Core.Models;

namespace HRManagementSystem.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AttendancesController(IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var attendance = await unitOfWork.Attendences.GetById(id);

            if (attendance == null)
                return NotFound($"Attendance with ID: {id} not found");

            return Ok(attendance);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var attendances = await unitOfWork.Attendences.Find(["Employee"]);

            if (attendances.Count() == 0)
                return NotFound("No attendances found!");

            IEnumerable<AttendanceDTO> attendancesDto = new List<AttendanceDTO>();

            attendancesDto = attendances.Adapt(attendancesDto);

            return Ok(attendancesDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AttendanceDTO dto)
        {
            var attendance = dto.Adapt<Attendance>();

            await unitOfWork.Attendences.Add(attendance);

            unitOfWork.Complete();

            return Ok(attendance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] AttendanceDTO dto)
        {
            var attendance = await unitOfWork.Attendences.GetById(id);

            if (attendance is null)
                return NotFound($"There is no attendance with ID: {id}");

            attendance = dto.Adapt(attendance);

            attendance = unitOfWork.Attendences.Update(attendance);

            unitOfWork.Complete();

            return Ok(attendance);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var attendance = await unitOfWork.Attendences.GetById(id);

            if (attendance is null)
                return NotFound($"The attendance doesn't exist!!!");

            unitOfWork.Attendences.Delete(attendance);

            unitOfWork.Complete();

            return Ok(attendance);
        }
    }
}
