using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Service.DepartmentService
{
    public interface IDepartmentRepository
    {
        public Task<bool> Create(DepartmentRequest Request);
        public Task<bool> Delete(string id);
        public Task<bool> Update(DepartmentRequest Request);
        public Task<List<DepartmentResponse>> GetAll();
        public Task<DepartmentResponse> GetByID(string id);
        public Task<int> CheckDepartmentName(DepartmentRequest Request);
    }
}
