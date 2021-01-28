using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCukCuk_Service.PositionService
{
    public class PositionResponse
    {
        public Guid PositionId { get; set; }
        public string PositionName { get; set; }
        public string Description { get; set; }
    }
}
