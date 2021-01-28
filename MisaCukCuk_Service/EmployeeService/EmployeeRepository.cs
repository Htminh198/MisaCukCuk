using Microsoft.EntityFrameworkCore;
using MisaCukCuk_Data;
using MisaCukCuk_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Service.EmployeeService
{
    public class EmployeeRepository : IEmployeeRepository
    {
        MisaCukCukDbContext _db;
        public EmployeeRepository(MisaCukCukDbContext misaCukCukDbContext)
        {
            _db = misaCukCukDbContext;
        }
        public async Task<bool> Create(EmployeeRequest Request)
        {
            try
            {
                var employee = new Employee()
                {
                    EmployeeId = Request.EmployeeId,
                    EmployeeCode = Request.EmployeeCode,
                    FullName = Request.FullName,
                    Gender = Request.Gender,
                    DateOfBirth = Request.DateOfBirth,
                    IdentityNumber = Request.IdentityNumber,
                    IdentityDate = Request.IdentityDate,
                    IdentityPlace = Request.IdentityPlace,
                    Email = Request.Email,
                    PhoneNumber = Request.PhoneNumber,
                    PositionId = Request.PositionId,
                    DepartmentId = Request.DepartmentId,
                    PersonalTaxCode = Request.PersonalTaxCode,
                    Salary = Request.Salary,
                    JoinDate = Request.JoinDate,
                    JobStatus = Request.JobStatus,
                };
                await _db.Employee.AddAsync(employee);
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
                var rs = await _db.Employee.Where(x => x.EmployeeId == Guid.Parse(id)).FirstOrDefaultAsync();
                if (rs == null)
                {
                    return false;
                }
                _db.Employee.Remove(rs);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<List<EmployeeResponse>> GetAll()
        {
            var rs = await _db.Employee.Select(x => new EmployeeResponse()
            {
                EmployeeId = x.EmployeeId,
                EmployeeCode = x.EmployeeCode,
                FullName = x.FullName,
                Gender = x.Gender,
                DateOfBirth = x.DateOfBirth,
                IdentityNumber = x.IdentityNumber,
                IdentityDate = x.IdentityDate,
                IdentityPlace = x.IdentityPlace,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                PositionId = x.PositionId,
                DepartmentId = x.DepartmentId,
                PersonalTaxCode = x.PersonalTaxCode,
                Salary = x.Salary,
                JoinDate = x.JoinDate,
                JobStatus = x.JobStatus,
            }).ToListAsync();
            return rs;
        }

        public async Task<EmployeeResponse> GetByID(string id)
        {
            var rs = await _db.Employee.Where(x => x.EmployeeId == Guid.Parse(id)).Select(x => new EmployeeResponse()
            {
                EmployeeId = x.EmployeeId,
                EmployeeCode = x.EmployeeCode,
                FullName = x.FullName,
                Gender = x.Gender,
                DateOfBirth = x.DateOfBirth,
                IdentityNumber = x.IdentityNumber,
                IdentityDate = x.IdentityDate,
                IdentityPlace = x.IdentityPlace,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                PositionId = x.PositionId,
                DepartmentId = x.DepartmentId,
                PersonalTaxCode = x.PersonalTaxCode,
                Salary = x.Salary,
                JoinDate = x.JoinDate,
                JobStatus = x.JobStatus,
            }).FirstOrDefaultAsync();
            return rs;
        }

        public async Task<bool> Update(EmployeeRequest Request)
        {
            try
            {
                var rs = await _db.Employee.Where(x => x.EmployeeId == Request.EmployeeId).FirstOrDefaultAsync();
                if(rs == null)
                {
                    return false;
                };
                rs.EmployeeId = Request.EmployeeId;
                rs.EmployeeCode = Request.EmployeeCode;
                rs.FullName = Request.FullName;
                rs.Gender = Request.Gender;
                rs.DateOfBirth = Request.DateOfBirth;
                rs.IdentityNumber = Request.IdentityNumber;
                rs.IdentityDate = Request.IdentityDate;
                rs.IdentityPlace = Request.IdentityPlace;
                rs.Email = Request.Email;
                rs.PhoneNumber = Request.PhoneNumber;
                rs.PositionId = Request.PositionId;
                rs.DepartmentId = Request.DepartmentId;
                rs.PersonalTaxCode = Request.PersonalTaxCode;
                rs.Salary = Request.Salary;
                rs.JoinDate = Request.JoinDate;
                rs.JobStatus = Request.JobStatus;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }
        public async Task<int> CheckEmployeeCode(EmployeeRequest Request)
        {
            var rs = await _db.Employee.Where(x => x.EmployeeId == Request.EmployeeId).Select(x => new EmployeeResponse()
            {
                EmployeeId = x.EmployeeId,
                EmployeeCode = x.EmployeeCode,
                FullName = x.FullName,
                Gender = x.Gender,
                DateOfBirth = x.DateOfBirth,
                IdentityNumber = x.IdentityNumber,
                IdentityDate = x.IdentityDate,
                IdentityPlace = x.IdentityPlace,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                PositionId = x.PositionId,
                DepartmentId = x.DepartmentId,
                PersonalTaxCode = x.PersonalTaxCode,
                Salary = x.Salary,
                JoinDate = x.JoinDate,
                JobStatus = x.JobStatus,
            }).FirstOrDefaultAsync();
            if(rs == null)
            {
                return 1;
            }
            if (rs.EmployeeCode == Request.EmployeeCode)
            {
                return 0;
            }
            return 1;
        }
    }
}

