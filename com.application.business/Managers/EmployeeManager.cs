using com.application.business.Wrappers;
using com.application.contracts.Common;
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

        private readonly IMapper<EmployeeSaveMapperWrapper, Employee> _employeeSaveMapper;

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository , IMapper<EmployeeSaveMapperWrapper, Employee> employeeSaveMapper)
        {
            _employeeRepository = employeeRepository;
            _employeeSaveMapper = employeeSaveMapper;
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
                var saveObject = _employeeSaveMapper.Map(new EmployeeSaveMapperWrapper
                {
                    Employee = employee,
                    User = "Admin",
                    IsEdit = employee.Id == 0 ? false : true,

                });

                return _employeeRepository.Save(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
