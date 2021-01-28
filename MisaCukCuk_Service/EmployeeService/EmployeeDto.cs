using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCukCuk_Service.EmployeeService
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? IdentityDate { get; set; }
        public string IdentityPlace { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid PositionId { get; set; }
        public Guid DepartmentId { get; set; }
        public string PersonalTaxCode { get; set; }
        public int? Salary { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? JobStatus { get; set; }
    }
}
