using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class CourierTb
    {
        public int Id { get; set; }
        public string? CourierNo { get; set; }
        public string? EmployeeName { get; set; }
        public string? CourierCompany { get; set; }
        public string? CourierPersonName { get; set; }
        public string? Time { get; set; }
        public DateTime? Date { get; set; }
        public int? UserId { get; set; }
        public string? Description { get; set; }
        public int? EmployeeId { get; set; }

        public string? PhotoPath { get; set; }
        public string? CertifactePath { get; set; }
    }
}
