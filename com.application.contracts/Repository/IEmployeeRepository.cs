using com.application.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.application.contracts.Repository
{
   public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();

        Employee Save(Employee employee);

        Employee GetEmployeeById(int id);
    }
}
