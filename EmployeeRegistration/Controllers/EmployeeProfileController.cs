using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnehaProject.Models;

namespace SnehaProject.Controllers
{
    public class EmployeeProfileController : Controller
    {
        // GET: EmployeeProfile
        public ActionResult Index(Employee emp)
        {
            try
            {
                Employee Logemp = (Employee)Session["LoginEmp"];
                if (emp.UserName == Logemp.UserName && emp.Password == Logemp.Password)
                {
                    return View(emp);
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}