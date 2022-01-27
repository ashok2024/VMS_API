using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class DbsettingTb
    {
        public int Id { get; set; }
        public string? DataSource { get; set; }
        public string? Dbname { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }
    }
}
