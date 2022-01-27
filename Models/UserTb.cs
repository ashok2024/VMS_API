using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class UserTb
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public string? Photo { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string? UserType { get; set; }
        public string? Company { get; set; }
        public string? Designation { get; set; }
        public string? Department { get; set; }
        public int? CompanyId { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
        public int? BranchId { get; set; }
        public string? EmpCode { get; set; }
        public string? IdProof { get; set; }
        public string? IdProofNumber { get; set; }
        public int? DeviceId { get; set; }
        public string? CardNo { get; set; }
    }
}
