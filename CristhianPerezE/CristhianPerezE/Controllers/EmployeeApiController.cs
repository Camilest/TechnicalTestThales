using CristhianPerezE.Models;
using CristhianPerezE.Util;
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

        // GET api/<controller>
        public IEnumerable<string> GetEmployees()
        {
            string test = this.EmployeeURL;
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string GetEmployeById(int id)
        {
            return "value";
        }


        public async Task<string> GetEmployeesAsync()
        {
            var test = await new RestClient().GetAsync<string>(this.EmployeeURL);
            return test;
        }
    }
}