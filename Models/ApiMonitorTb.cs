using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class ApiMonitorTb
    {
        public int Id { get; set; }
        public string? Page { get; set; }
        public string? Action { get; set; }
        public DateTime? Time { get; set; }
        public string? EmpCode { get; set; }
        public string? EmpName { get; set; }
        public string? DeviceSrno { get; set; }
        public string? DeviceName { get; set; }
        public string? Status { get; set; }
        public string? Command { get; set; }
    }
}
