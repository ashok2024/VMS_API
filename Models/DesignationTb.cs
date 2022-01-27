using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class DesignationTb
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? DepartmentId { get; set; }
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
    }
}
