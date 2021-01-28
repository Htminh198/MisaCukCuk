using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MisaCukCuk_Data;
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
        private readonly MisaCukCukDbContext _db;
        public PositionController(MisaCukCukDbContext misaCukCukDbContext)
        {
            _db = misaCukCukDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rs = await _db.Position.ToListAsync();
            return Ok(rs);
        }
    }
}
