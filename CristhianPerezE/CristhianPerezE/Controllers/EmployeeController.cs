using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CristhianPerezE.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeApiController Employee = new EmployeeApiController();
        /// <summary>
        /// Create a partial view Index.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEmployees()
        {
            var test = this.Employee.GetEmployeesAsync().Result;
            return Json("test", JsonRequestBehavior.AllowGet);
        }
    }
}