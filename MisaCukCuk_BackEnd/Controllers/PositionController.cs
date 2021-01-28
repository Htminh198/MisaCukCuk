using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MisaCukCuk_Service.PositionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MisaCukCuk_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionRepository _Rep;
        public PositionController(IPositionRepository positionRepository)
        {
            _Rep = positionRepository;
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
        public async Task<IActionResult> Create([FromForm]PositionRequest Request)
        {
            try
            {
                var check = await _Rep.CheckPositionName(Request);
                if (check == 0)
                {
                    return BadRequest("Trùng tên!");
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
        public async Task<IActionResult> Update([FromForm]PositionRequest Request)
        {
            try
            {
                var rs = await _Rep.Update(Request);
                if (rs == false)
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
