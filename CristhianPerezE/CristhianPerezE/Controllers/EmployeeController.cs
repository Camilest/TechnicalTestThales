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
            List<CristhianPerezE.Models.data> dataEmpleyees = null;
            var employeesResult = this.Employee.GetEmployees();
            if (employeesResult.Any())
            {
                return Json(new { EmployeesResult = employeesResult }, JsonRequestBehavior.AllowGet);
            }
            return Json(dataEmpleyees, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetEmployeById(int id)
        {
            List<CristhianPerezE.Models.data> dataEmpleyees = null;
            var employeeResult = this.Employee.GetEmployeById(id);
            if (employeeResult != null)
            {
                return Json(employeeResult, JsonRequestBehavior.AllowGet);
            }
            return Json(dataEmpleyees, JsonRequestBehavior.AllowGet);
        }

    }
}