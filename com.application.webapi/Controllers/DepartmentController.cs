using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.application.contracts.Managers;
using com.application.entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace com.application.webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/Department")]
    public class DepartmentController : Controller
    {
        
        private readonly IDepartmentManager _departmentManager;

        public DepartmentController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            try
            {
                var result = _departmentManager.GetDepartmentList();

                return result;
            }
            catch (System.Exception)
            {
                throw;
            }

        }


    }
}
