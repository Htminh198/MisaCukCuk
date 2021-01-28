using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCukCuk_Service.EmployeeService
{
    public class EmployeeResponse
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeId_ { get { return EmployeeId.ToString(); } }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public int? Gender { get; set; }
        public string GenderName
        {
            get
            {
                switch (Gender)
                {
                    case 0: return "Nam";
                    case 1: return "Nữ";
                    case 2: return "Khác";
                    default: return "Không xác định";
                }
            }
        }
        public DateTime? DateOfBirth { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? IdentityDate { get; set; }
        public string IdentityPlace { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid PositionId { get; set; }
        public string PositionId_ { get { return PositionId.ToString(); } }
        public Guid DepartmentId { get; set; }
        public string DepartmentId_ { get { return DepartmentId.ToString(); } }
        public string PersonalTaxCode { get; set; }
        public int? Salary { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? JobStatus { get; set; }
        public string JobStatusName
        {
            get
            {
                switch (Gender)
                {
                    case 0: return "Đang làm việc";
                    case 1: return "Đã nghỉ việc";
                    case 2: return "Đang thử việc";
                    default: return "Không xác định";
                }
            }
        }
    }
}
