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

        bool IsEmailReferenceExists(Employee employee, bool isUpdate);

        Employee Save(Employee employee);

        Employee GetEmployeeById(int id);
    }
}
