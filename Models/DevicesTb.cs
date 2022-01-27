using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class DevicesTb
    {
        public int DeviceId { get; set; }
        public string? DeviceName { get; set; }
        public string? DeviceSerialNo { get; set; }
        public string? Ipaddress { get; set; }
        public string? DeviceStatus { get; set; }
        public DateTime? DownloadDate { get; set; }
        public string? DeviceLocation { get; set; }
        public string? DeviceAccountId { get; set; }
        public string? DeviceDirection { get; set; }
        public string? DeviceIpaddress { get; set; }
        public string? Port { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
