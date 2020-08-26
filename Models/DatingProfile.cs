using System;
using System.Collections.Generic;

namespace Lab4_3_AspNetCoreMVC_BlindDating.Models
{
    public partial class DatingProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Bio { get; set; }
        public string UserAccountId { get; set; }
        public string PhotoPath { get; internal set; }
        public object DisplayName { get; internal set; }
        public IEnumerable<MailMessage> MailMessageFromProfile { get; internal set; }
        public IEnumerable<MailMessage> MailMessageToProfile { get; internal set; }
    }
}
