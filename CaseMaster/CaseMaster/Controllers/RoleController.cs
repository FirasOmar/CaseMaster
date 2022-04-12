﻿using CaseMaster.Manager;
using CaseMaster.Models;
using CaseMaster.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Controllers
{   
    [Authorize]
    public class RoleController : Controller
    {
        private RoleManager _roleManager;
        private ApplicationUserManager _userManager;
        private UserRoleManager _userRoleManager;
        public RoleController(RoleManager roleManager, ApplicationUserManager userManager,UserRoleManager userRoleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userRoleManager = userRoleManager;
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
        public ActionResult Delete(Role role)
        {

            bool isDeleted = _roleManager.Delete(role);
            if (isDeleted)
            {
                return RedirectToAction("Index");
            }
            return View(role);
        }
        public ActionResult Assign()
        {
            ViewData["UserId"] = new SelectList(_userManager.GetAll().ToList(), "Id", "UserName");
          
           ViewData["RoleId"] = new SelectList(_roleManager.GetAll().ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Assign(UserRoleVM userRole)
        {
            var isCheckRoleAssign = _userRoleManager.Get(c 
                => c.UserId == userRole.UserId && c.RoleId==userRole.RoleId);
            var msg = "";
            if (isCheckRoleAssign.Count > 0)
            {
                msg = "This user already assign to this role.";
                ViewData["UserId"] = new SelectList(_userManager.GetAll().ToList(), "Id", "UserName");
                ViewData["RoleId"] = new SelectList(_roleManager.GetAll().ToList(), "Id", "Name");

            }
            else
            {
                userRole.Created = DateTime.Now;
                userRole.CreatedBy = User.Identity.Name;
                bool isSaved = _userRoleManager.Add(userRole);
                if (isSaved)
                {
                    msg = "User Role Saved Successfully!";
                    return RedirectToAction("AssignUserRole");
                }
                else
                {
                    msg = "User Role Failed To Save!";
                }
            }
           
            ViewBag.msg = msg;
            return View();
        }

        public ActionResult AssignUserRole()
        {
            var result = from ur in _userRoleManager.GetAll()
                         join r in _roleManager.GetAll()
                         on ur.RoleId equals r.Id
                         join u in _userManager.GetAll() on ur.UserId equals u.Id
                         
                         select new UserRoleMappingViewModel()
                         {
                             UserId=ur.UserId,
                             RoleId=ur.RoleId,
                             UserName=u.UserName,
                             RoleName=r.Name
                         };
            ViewBag.userRoles = result;
            return View();
        }
        public ActionResult DeleteAssignedRole(string userId, string roleId)
        {
            var userRole = _userRoleManager.GetFirstOrDefault(c => c.UserId == userId && c.RoleId== roleId);
            var _UserName = _userManager.GetFirstOrDefault(c => c.Id == userId).UserName;
            var _RoleName = _roleManager.GetFirstOrDefault(c => c.Id == roleId).Name;
            var userRoleVM = new UserRoleMappingViewModel()
            {
                RoleId= roleId,
                UserId= userId,
                UserName=_UserName,
                RoleName = _RoleName
            };
            if (userRoleVM == null)
            {
                return NotFound();
            }
            return View(userRoleVM);
        }
        [HttpPost]
        public ActionResult DeleteAssignedRole(UserRoleMappingViewModel ur)
        {
            var userRole = _userRoleManager.GetFirstOrDefault(c => c.UserId == ur.UserId && c.RoleId == ur.RoleId);
            bool isDeleted = _userRoleManager.Delete(userRole);
            if (isDeleted)
            {
                return RedirectToAction("AssignUserRole");
            }
            return View(ur);
        }
    }
}
