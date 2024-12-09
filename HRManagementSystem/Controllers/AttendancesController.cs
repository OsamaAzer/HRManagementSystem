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
            var attendances = await unitOfWork.Attendences.Find();

            if (attendances.Count() == 0)
                return NotFound("No attendances found!");

            return Ok(attendances);
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

            attendance.ArrivingTime = dto.ArrivingTime;
            attendance.LeavingTime = dto.LeavingTime;
            attendance.Status = dto.Status;
            attendance.LateTimeHours = dto.LateTimeHours;
            attendance.OverTimeHours = dto.OverTimeHours;
            attendance.AttendanceDay = dto.AttendanceDay;
            attendance.Date = dto.Date;
            attendance.EmployeeId = dto.EmployeeId;

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
