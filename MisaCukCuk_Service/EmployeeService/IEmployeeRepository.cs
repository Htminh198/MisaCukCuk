using MisaCukCuk_Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Service.EmployeeService
{
    public interface IEmployeeRepository
    {
        public Task<bool> Create(EmployeeRequest Request);
        public Task<bool> Delete(string id);
        public Task<bool> Update(EmployeeRequest Request);
        public Task<List<EmployeeResponse>> GetAll();
        public Task<EmployeeResponse> GetByID(string id);
        public Task<int> CheckEmployeeCode(EmployeeRequest Request);
    }
}
