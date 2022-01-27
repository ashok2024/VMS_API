using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class VisitorEntryTb
    {
        public int Id { get; set; }
        public int? VisitId { get; set; }
        public string? VisitorId { get; set; }
        public string? Name { get; set; }
        public string? Company { get; set; }
        public string? Address { get; set; }
        public string? InTime { get; set; }
        public string? OutTime { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? EmailId { get; set; }
        public string? Contact { get; set; }
        public string? Purpose { get; set; }
        public string? Remark { get; set; }
        public string? Priority { get; set; }
        public int? UserId { get; set; }
        public int? EmployeeId { get; set; }
        public string? IdProof { get; set; }
        public string? IdProofNumber { get; set; }
        public string? Photo { get; set; }
        public string? Material { get; set; }
        public string? VehicleNo { get; set; }
        public string? VehicleType { get; set; }
        public string? VehiclePucno { get; set; }
        public DateTime? PucendDate { get; set; }
        public string? VisitorType { get; set; }
        public string? DeviceName { get; set; }
        public int? DeviceId { get; set; }
        public string? CardNo { get; set; }
        public string? CertificateImagePath { get; set; }
    }
}
