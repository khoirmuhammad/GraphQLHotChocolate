using GraphQL.NETClient.Models;
using GraphQL.NETClient.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.NETClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _departmentService.GetAllAsync();
                return Ok(response);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var response = await _departmentService.GetById(id);
                return Ok(response);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertDepartmentModel input)
        {
            try
            {
                var response = await _departmentService.CreateDepartment(input);
                return StatusCode(201, response);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid id, UpdateDepartmentModel input)
        {
            try
            {
                var response = await _departmentService.UpdateDepartment(id, input);
                return NoContent();
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var response = await _departmentService.DeleteDepartment(id);
                return NoContent();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
