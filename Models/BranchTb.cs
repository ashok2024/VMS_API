using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class BranchTb
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CompanyId { get; set; }
        public string? ContactPerson { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
