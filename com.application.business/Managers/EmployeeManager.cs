using com.application.contracts.Managers;
using com.application.contracts.Repository;
using com.application.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.application.business.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                return _employeeRepository.GetEmployeeById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            try
            {
                return _employeeRepository.GetEmployees();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public Employee Save(Employee employee)
        {
            try
            {
                return _employeeRepository.Save(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
