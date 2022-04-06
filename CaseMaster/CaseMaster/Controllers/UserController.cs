using CaseMaster.Manager;
using CaseMaster.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Controllers
{
    public class UserController : Controller
    {
      private ApplicationUserManager _ApplicationUserManager;
        public UserController(ApplicationUserManager applicationUserManager)
        {
            _ApplicationUserManager = applicationUserManager;
        }
        public IActionResult Index()
        {
            var users = _ApplicationUserManager.GetAll();
            return View(users);
        }
    }
}
