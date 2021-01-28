using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisaCukCuk_Service.EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCukCuk_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _Rep;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _Rep = employeeRepository;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var rs = await _Rep.GetAll();
                return Ok(rs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Có lỗi xảy ra!");
            }

        }
        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID(string id)
        {
            try
            {
                var rs = await _Rep.GetByID(id);
                return Ok(rs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Có lỗi xảy ra!");
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var rs = await _Rep.Delete(id);
                if(rs == false)
                {
                    return BadRequest("Xóa thất bại");
                }
                return Ok("Xóa thành công");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Có lỗi xảy ra!");
            }
        }
    }
}
