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
                IEnumerable<Department> response = await _departmentService.GetAllAsync();
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
                Department response = await _departmentService.GetById(id);
                return Ok(response);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
