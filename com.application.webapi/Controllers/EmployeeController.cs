using System.Collections.Generic;
using com.application.contracts.Managers;
using com.application.entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace com.application.webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            try
            {
                var result = _employeeManager.GetEmployeeList();

                return result;
            }
            catch (System.Exception)
            {
                throw;
            }
       
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _employeeManager.GetEmployeeById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public Employee Post([FromBody]Employee employee)
        {
            try
            {
                return _employeeManager.Save(employee);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
