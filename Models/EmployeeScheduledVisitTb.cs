using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class EmployeeScheduledVisitTb
    {
        public int Id { get; set; }
        public int? VisitId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
