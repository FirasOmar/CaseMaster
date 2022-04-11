using CaseMaster.Manager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager _roleManager;
        public RoleController(RoleManager roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.GetAll();
            return View(roles);
        }
    }
}
