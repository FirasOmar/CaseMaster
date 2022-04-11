using CaseMaster.Manager;
using CaseMaster.Models;
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Role role)
        {
            string msg = "";
            role.Created = DateTime.Now;
            role.CreatedBy = User.Identity.Name;
            bool isSaved = _roleManager.Add(role);
            if (isSaved)
            {
                msg = "saved successfuly.";
                return RedirectToAction("index");
            }
            else
            {
                msg = "Failed to Save.";
            }
            ViewBag.Msg = msg;
            return View();
        }
        public IActionResult Edit(string id)
        {

            var role = _roleManager.GetFirstOrDefault(c => c.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Role role)
        {
            //var result = await _roleManager.FindByIdAsync(role.Id);

            //result.UserName = user.UserName;
            //result.Email = user.Email;
            //result.PhoneNumber = user.PhoneNumber;
            //result.IsActive = user.IsActive;

            var isUpdated = _roleManager.Update(role);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}
