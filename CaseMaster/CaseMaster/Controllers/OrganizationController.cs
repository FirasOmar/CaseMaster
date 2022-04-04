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
        private AppDBContext _dbContext;
        private IOrganizationManager _OrganizationManager;
        public OrganizationController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
            _OrganizationManager = new OrganizationManager(_dbContext);
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
    }
}
