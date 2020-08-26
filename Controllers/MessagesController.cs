using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4_3_AspNetCoreMVC_BlindDating.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_3_AspNetCoreMVC_BlindDating.Controllers
{
    public class MessagesController : Controller
    {
        private BlindDatingContext _context;
        private UserManager<IdentityUser> _userManager;
        private UserManager<IdentityUser> userManager;

        public MessagesController(BlindDatingContext context, UserManager<IdentityUser>userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
