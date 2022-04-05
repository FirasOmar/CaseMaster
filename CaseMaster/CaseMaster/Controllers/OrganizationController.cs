using CaseMaster.Data;
using CaseMaster.Interfaces.Manager;
using CaseMaster.Manager;
using CaseMaster.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Controllers
{
    public class OrganizationController : Controller
    {
        private OrganizationManager _OrganizationManager;
        public OrganizationController(OrganizationManager organizationManager)
        {
            _OrganizationManager = organizationManager;
        }
        public IActionResult Index()
        {
            var organizations = _OrganizationManager.GetAll();
            return View(organizations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Organization organization)
        {

            string msg = "";
            organization.Created = DateTime.Now;
            bool isSaved = _OrganizationManager.Add(organization);
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

        public ActionResult Edit(int id)
        {
            var organization = _OrganizationManager.GetFirstOrDefault(c => c.Id == id);
            if(organization == null)
            {
                return NotFound();
            }
            return View(organization);
        }

        [HttpPost]
        public ActionResult Edit(Organization organization)
        {
            var isUpdated = _OrganizationManager.Update(organization);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        public ActionResult Details(int id)
        {
            var organization = _OrganizationManager.GetFirstOrDefault(c => c.Id == id);
            if(organization == null)
            {
                return NotFound();
            }
            return View(organization);
        }
        public ActionResult Delete(int id)
        {
            var organization = _OrganizationManager.GetFirstOrDefault(c => c.Id==id);
            if(organization == null)
            {
                return NotFound();
            }
            return View(organization);
        }
        [HttpPost]
        public ActionResult Delete(Organization organization)
        {
            bool isDeleted = _OrganizationManager.Delete(organization);
            if (isDeleted)
            {
                return RedirectToAction("Index");
            }
            return View(organization);
        }
    }
}
