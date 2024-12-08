using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.DTOs;

namespace HRManagementSystem.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SpecialLeavesController(IUnitOfWork unitOfWork) : ControllerBase
    {
        //[HttpGet("{id}")]
        //[Route("GetById")]
        //public async Task<IActionResult> GetByIdAsync(int id)
        //{
        //   return Ok(await unitOfWork.SpecialLeaves.GetById(id));
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllAsync()
        //{
        //    return Ok(await unitOfWork.SpecialLeaves.GetAll());
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateAsync(SpecialLeaveDTO dto)
        //{
           
        //}
    }
}
