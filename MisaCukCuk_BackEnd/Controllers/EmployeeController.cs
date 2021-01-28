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
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm]EmployeeRequest Request)
        {
            try
            {
                var check = await _Rep.CheckEmployeeCode(Request);
                if(check == 0)
                {
                    return BadRequest("Trùng mã nhân viên!");
                }
                else
                {
                    if (check == 1)
                    {
                        var rs = await _Rep.Create(Request);
                        return Ok("Thêm mới thành công!");
                    }
                    return BadRequest("Có lỗi xảy ra!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Có lỗi xảy ra!");
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] EmployeeRequest Request)
        {
            try
            {
                var rs = await _Rep.Update(Request);
                if(rs == false)
                {
                    return BadRequest("Cập nhập thất bại!");
                }
                return Ok("Cập nhập thành công!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Có lỗi xảy ra!");
            }
        }
    }
}
