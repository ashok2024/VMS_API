using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class VisitorTb
    {
        public int Id { get; set; }
        public string? VisitorId { get; set; }
        public string? Name { get; set; }
        public string? EmailId { get; set; }
        public string? Contact { get; set; }
        public string? Photo { get; set; }
        public string? Company { get; set; }
    }
}
