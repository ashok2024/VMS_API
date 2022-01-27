using System;
using System.Collections.Generic;

namespace VMS_API.Models
{
    public partial class MailSettingTb
    {
        public int Id { get; set; }
        public string? Host { get; set; }
        public string? Smtpfrom { get; set; }
        public int? Port { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
