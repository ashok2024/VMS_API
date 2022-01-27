using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class EmployeePunchTb
    {
        public int Id { get; set; }
        public string? Major { get; set; }
        public string? Minor { get; set; }
        public DateTime? Time { get; set; }
        public string? EmployeeNoString { get; set; }
        public string? CardNo { get; set; }
        public string? CardReaderNo { get; set; }
        public string? DoorNo { get; set; }
        public string? CurrentVerifyMode { get; set; }
        public string? SerialNo { get; set; }
        public string? Type { get; set; }
        public string? Mask { get; set; }
        public string? Name { get; set; }
        public string? UserType { get; set; }
        public string? DeviceIndex { get; set; }
        public string? DeviceAccountId { get; set; }
    }
}
