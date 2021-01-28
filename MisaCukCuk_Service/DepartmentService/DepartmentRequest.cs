using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCukCuk_Service.DepartmentService
{
    public class DepartmentRequest
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
    }
}
