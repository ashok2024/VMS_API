using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class VisitorStatusTb
    {
        public int Id { get; set; }
        public int? VisitId { get; set; }
        public int? UserId { get; set; }
        public string? Status { get; set; }
        public string? Remark { get; set; }
    }
}
