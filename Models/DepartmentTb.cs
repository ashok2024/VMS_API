using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class DepartmentTb
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
    }
}
