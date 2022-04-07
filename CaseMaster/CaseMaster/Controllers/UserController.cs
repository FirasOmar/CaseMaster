using AutoMapper;
using CaseMaster.Data;
using CaseMaster.Manager;
using CaseMaster.Models;
using CaseMaster.ViewModels;
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
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserController(ApplicationUserManager applicationUserManager, UserManager<User> userManager,IMapper mapper)
        {
            _ApplicationUserManager = applicationUserManager;
            _userManager = userManager;
            _mapper = mapper;
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
        public IActionResult Create(User user)
        {
            string msg = "";
            user.Created = DateTime.Now;
            user.CreatedBy = User.Identity.Name;
            bool isSaved = _ApplicationUserManager.Add(user);
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
        public async Task<ActionResult> Edit(User user)
        {    
            var result =  await _userManager.FindByIdAsync(user.Id);
            
            result.UserName = user.UserName;
            result.Email = user.Email;
            result.PhoneNumber = user.PhoneNumber;
            result.IsActive = user.IsActive;
            
            var isUpdated = _ApplicationUserManager.Update(result);
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
        public async Task<ActionResult> Delete(User user)
        {
            var result = await _userManager.FindByIdAsync(user.Id);

            bool isDeleted = _ApplicationUserManager.Delete(result);
            if (isDeleted)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}
