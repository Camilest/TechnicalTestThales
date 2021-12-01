using CristhianPerezE.Models;
using CristhianPerezE.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CristhianPerezE.Controllers
{
    public class EmployeeApiController : ApiController
    {
        string EmployeeURL = "http://dummy.restapiexample.com/api/v1/employees";
        static HttpClient Client = new HttpClient();

        /// <summary>
        /// Obtener los datos del servicio web.
        /// </summary>
        /// <returns></returns>
        public List<data> GetEmployees()
        {
            DataInformation dataInformation = null;
            List<data> dataEmployee = new List<data>();
            var getDataFromService = new RestClient().GetApiData(this.EmployeeURL);
            if (!string.IsNullOrEmpty(getDataFromService))
            {
                dataInformation = JsonConvert.DeserializeObject<DataInformation>(getDataFromService);
                if (dataInformation.data.Any())
                {
                    dataEmployee = dataInformation.data.ToList();
                    foreach (var item in dataEmployee)
                    {
                        item.employee_anual_salary = item.employee_salary * 12;
                    }
                }
            }
            return dataEmployee;
        }

        /// <summary>
        /// Obtener los datos de un empleado especifico.
        /// </summary>
        /// <returns></returns>
        public data GetEmployeById(int id)
        {
            data employee = null;
            var getEmploye = this.GetEmployees().Where(x => x.id.Equals(id)).FirstOrDefault();
            if (getEmploye != null)
            {
                employee = getEmploye;
            }
            return employee;
        }
    }
}