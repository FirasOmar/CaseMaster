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
           var item = _roleManager.GetFirstOrDefault(r => r.Name==role.Name);
            if(item == null)
            {
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
              
            }
            else
            {
                msg = "Role Name Already Exists !";
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
        public IActionResult Edit(Role role)
        {
            string msg = "";
            var item = _roleManager.Get(r => r.Name==role.Name);

            if(item.Count <= 1) 
            { 
            var isUpdated = _roleManager.Update(role);
            if (isUpdated)
            {
                    msg = "Role Updated Successfully !";
                    return RedirectToAction("Index");
            }
            }
            else
            {
                msg = "Role Name Already Exists !";
            }
            ViewBag.Msg = msg;
            return View(role);
        }
        public ActionResult Details(string id)
        {
            var role = _roleManager.GetFirstOrDefault(c => c.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }
        public ActionResult Delete(string id)
        {
            var role = _roleManager.GetFirstOrDefault(c => c.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(Role role)
        {
          //  var result = await _roleManager.FindByIdAsync(user.Id);

            bool isDeleted = _roleManager.Delete(role);
            if (isDeleted)
            {
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}
