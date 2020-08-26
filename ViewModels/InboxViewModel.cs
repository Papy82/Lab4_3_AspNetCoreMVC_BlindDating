using Lab4_3_AspNetCoreMVC_BlindDating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using MailMessage = Lab4_3_AspNetCoreMVC_BlindDating.Models.MailMessage;

namespace Lab4_3_AspNetCoreMVC_BlindDating.ViewModels
{
    public class InboxViewModel
    {
        public IEnumerable<MailMessage> mailMessage;
        public IEnumerable<DatingProfile> fromProfiles;
    }
}
