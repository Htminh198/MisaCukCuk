using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Service.PositionService
{
    public interface IPositionRepository
    {
        public Task<bool> Create(PositionRequest Request);
        public Task<bool> Delete(string id);
        public Task<bool> Update(PositionRequest Request);
        public Task<List<PositionResponse>> GetAll();
        public Task<PositionResponse> GetByID(string id);
        public Task<int> CheckPositionName(PositionRequest Request);
    }
}
