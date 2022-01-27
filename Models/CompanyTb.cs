using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class CompanyTb
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ContactPerson { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
