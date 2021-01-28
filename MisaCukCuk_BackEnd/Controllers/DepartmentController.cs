using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MisaCukCuk_Data;
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
        private readonly MisaCukCukDbContext _db;
        public DepartmentController(MisaCukCukDbContext misaCukCukDbContext)
        {
            _db = misaCukCukDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rs = await _db.Department.ToListAsync();
            return Ok(rs);
        }
    }
}
