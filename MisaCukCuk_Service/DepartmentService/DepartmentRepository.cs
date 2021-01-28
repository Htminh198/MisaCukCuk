using Microsoft.EntityFrameworkCore;
using MisaCukCuk_Data;
using MisaCukCuk_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Service.DepartmentService
{
    public class DepartmentRepository : IDepartmentRepository
    {
        MisaCukCukDbContext _db;
        public DepartmentRepository(MisaCukCukDbContext misaCukCukDbContext)
        {
            _db = misaCukCukDbContext;
        }
        public async Task<int> CheckDepartmentName(DepartmentRequest Request)
        {
            var rs = await _db.Department.Where(x => x.DepartmentId == Request.DepartmentId).Select(x => new DepartmentResponse()
            {
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName,
                Description = x.Description
            }).FirstOrDefaultAsync();
            if (rs == null)
            {
                return 1;
            }
            if (rs.DepartmentName == Request.DepartmentName)
            {
                return 0;
            }
            return 1;
        }

        public async Task<bool> Create(DepartmentRequest Request)
        {
            try
            {
                var department = new Department()
                {
                    DepartmentId = Request.DepartmentId,
                    DepartmentName = Request.DepartmentName,
                    Description = Request.Description
                };
                await _db.Department.AddAsync(department);
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
                var rs = await _db.Department.Where(x => x.DepartmentId == Guid.Parse(id)).FirstOrDefaultAsync();
                if (rs == null)
                {
                    return false;
                }
                _db.Department.Remove(rs);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<List<DepartmentResponse>> GetAll()
        {
            var rs = await _db.Department.Select(x => new DepartmentResponse()
            {
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName,
                Description = x.Description
            }).ToListAsync();
            return rs;
        }

        public async Task<DepartmentResponse> GetByID(string id)
        {
            var rs = await _db.Department.Where(x => x.DepartmentId == Guid.Parse(id)).Select(x => new DepartmentResponse()
            {
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName,
                Description = x.Description
            }).FirstOrDefaultAsync();
            return rs;
        }

        public async Task<bool> Update(DepartmentRequest Request)
        {
            try
            {
                var rs = await _db.Department.Where(x => x.DepartmentId == Request.DepartmentId).FirstOrDefaultAsync();
                if (rs == null)
                {
                    return false;
                }
                rs.DepartmentId = Request.DepartmentId;
                rs.DepartmentName = Request.DepartmentName;
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
