using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class DeviceLogsTb
    {
        public int LogId { get; set; }
        public int? DeviceAccountId { get; set; }
        public DateTime? DownloadDate { get; set; }
        public DateTime? AttendDate { get; set; }
        public string? PunchStatus { get; set; }
        public int? EmpId { get; set; }
        public string? AccessCardNo { get; set; }
        public DateTime? Adate { get; set; }
        public TimeSpan? Atime { get; set; }
    }
}
