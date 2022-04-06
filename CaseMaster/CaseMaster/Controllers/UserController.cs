using CaseMaster.Data;
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserViewModel userVM)
        {
            string msg = "";
            userVM.Created = DateTime.Now;
            userVM.CreatedBy = User.Identity.Name;
            bool isSaved = _ApplicationUserManager.Add(userVM);
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
            var user = _ApplicationUserManager.GetFirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel user)
        {
         

            var isUpdated = _ApplicationUserManager.Update(user);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public ActionResult Details(string id)
        {
            var user = _ApplicationUserManager.GetFirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        public ActionResult Delete(string id)
        {
            var user = _ApplicationUserManager.GetFirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult Delete(UserViewModel user)
        {
            bool isDeleted = _ApplicationUserManager.Delete(user);
            if (isDeleted)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}
