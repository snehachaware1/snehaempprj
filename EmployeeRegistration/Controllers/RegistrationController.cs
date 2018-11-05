using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnehaProject.Models;
using System.Collections;

namespace SnehaProject.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Employee emp)
        {
            List<Employee> lstEmp;// = new List<Employee>();
            if (Session["Employee"] != null)
            {
                lstEmp = (List<Employee>)Session["Employee"];
                lstEmp.Add(emp);                
            }
            else
            {
                lstEmp = new List<Employee>();
                lstEmp.Add(emp);    
            }
            Session["Employee"] = lstEmp;
            ViewBag.JavaScriptFunction = string.Format("ShowMessage();");               
            ModelState.Clear();
            return View();
        }
    }
}