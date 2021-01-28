using Microsoft.EntityFrameworkCore;
using MisaCukCuk_Data;
using MisaCukCuk_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Service.PositionService
{
    public class PositionRepository : IPositionRepository
    {
        MisaCukCukDbContext _db;
        public PositionRepository(MisaCukCukDbContext misaCukCukDbContext)
        {
            _db = misaCukCukDbContext;
        }
        public async Task<int> CheckPositionName(PositionRequest Request)
        {
            var rs = await _db.Position.Where(x => x.PositionId == Request.PositionId).Select(x => new PositionResponse()
            {
                PositionId = x.PositionId,
                PositionName = x.PositionName,
                Description = x.Description
            }).FirstOrDefaultAsync();
            if (rs == null)
            {
                return 1;
            }
            if (rs.PositionName == Request.PositionName)
            {
                return 0;
            }
            return 1;
        }

        public async Task<bool> Create(PositionRequest Request)
        {
            try
            {
                var posotion = new Position()
                {
                    PositionId = Request.PositionId,
                    PositionName = Request.PositionName,
                    Description = Request.Description
                };
                await _db.Position.AddAsync(posotion);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var rs = await _db.Position.Where(x => x.PositionId == Guid.Parse(id)).FirstOrDefaultAsync();
                if (rs == null)
                {
                    return false;
                }
                _db.Position.Remove(rs);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<List<PositionResponse>> GetAll()
        {
            var rs = await _db.Position.Select(x => new PositionResponse()
            {
                PositionId = x.PositionId,
                PositionName = x.PositionName,
                Description = x.Description
            }).ToListAsync();
            return rs;
        }

        public async Task<PositionResponse> GetByID(string id)
        {
            var rs = await _db.Position.Where(x => x.PositionId == Guid.Parse(id)).Select(x => new PositionResponse()
            {
                PositionId = x.PositionId,
                PositionName = x.PositionName,
                Description = x.Description
            }).FirstOrDefaultAsync();
            return rs;
        }

        public async Task<bool> Update(PositionRequest Request)
        {
            try
            {
                var rs = await _db.Position.Where(x => x.PositionId == Request.PositionId).FirstOrDefaultAsync();
                if (rs == null)
                {
                    return false;
                }
                rs.PositionId = Request.PositionId;
                rs.PositionName = Request.PositionName;
                rs.Description = Request.Description;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
