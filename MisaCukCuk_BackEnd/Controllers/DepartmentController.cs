using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MisaCukCuk_Service.DepartmentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCukCuk_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _Rep;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _Rep = departmentRepository;
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
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm]DepartmentRequest Request)
        {
            try
            {
                var check = await _Rep.CheckDepartmentName(Request);
                if (check == 0)
                {
                    return BadRequest("Trùng tên phòng ban!");
                }
                else
                {
                    if (check == 1)
                    {
                        var rs = await _Rep.Create(Request);
                        if (rs == false)
                        {
                            return BadRequest("Thêm mới thất bại!");
                        }
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
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var rs = await _Rep.Delete(id);
                if (rs == false)
                {
                    return BadRequest("Xóa thất bại!");
                }
                return Ok("Xóa thành công!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Có lỗi xảy ra!");
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm]DepartmentRequest Request)
        {
            try
            {
                var rs = await _Rep.Update(Request);
                if (rs == false)
                {
                    return BadRequest("Cập nhâp thất bại!");
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
