using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnehaProject.Models;

namespace SnehaProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Session["LoginEmp"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Employee emp)
        {
            List<Employee> lstemp = (List<Employee>)Session["Employee"];
            if (lstemp != null)
            {
                Employee result = lstemp.SingleOrDefault(emppoyee => emppoyee.UserName == emp.UserName && emppoyee.Password == emp.Password);
                if (result == null)
                {
                    ViewBag.JavaScriptFunction = string.Format("ShowMessage('Invalid User Name or Password.');");
                }
                else
                {
                    Session["LoginEmp"] = result;
                    return RedirectToAction("Index", "EmployeeProfile",result);
                }

            }
            else
            {
                ViewBag.JavaScriptFunction = string.Format("ShowMessage('Invalid User Name or Password.');");
            }
            return View();
        }

    }
}