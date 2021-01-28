using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCukCuk_Data.Entities
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentId_
        {
            get
            {
                return DepartmentId.ToString();
            }
        }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
    }
}
