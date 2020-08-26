﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4_3_AspNetCoreMVC_BlindDating.Models;
using Lab4_3_AspNetCoreMVC_BlindDating.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_3_AspNetCoreMVC_BlindDating.Controllers
{
    public class MessagesController : Controller
    {
        private BlindDatingContext _context;
        private UserManager<IdentityUser> _userManager;
        //private UserManager<IdentityUser> userManager;

        public MessagesController(BlindDatingContext context, UserManager<IdentityUser>userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Inbox()
        {
           
            DatingProfile profile = _context.DatingProfile.FirstOrDefault(IdentityBuilder => IdentityBuilder.UserAccountId == _userManager.GetUserId(User));

            InboxViewModel inbox = new InboxViewModel();
            inbox.mailMessage = _context.MailMessage.Where(to => to.ToProfileId == profile.Id).ToList();

            List<DatingProfile> fromList = new List<DatingProfile>();
            foreach(var msg in inbox.mailMessage)
            {
                fromList.Add(_context.DatingProfile.FirstOrDefault(from => from.Id == msg.FromProfileId));
            }

            inbox.fromProfiles = fromList;
            return View(inbox);
                
         
        }

        public IActionResult NewMessage(int id)
        {
            ViewBag.ToProfileId = id;
            return View();
        }

        public IActionResult Read(int id)
        {
            MailMessage mail = _context.MailMessage.FirstOrDefault(m => m.Id == id);
            mail.IsRead = true;
            _context.Update(mail);
            _context.SaveChanges();
            return View(mail);
        }

    }
}
