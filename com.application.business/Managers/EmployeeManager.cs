using com.application.business.Wrappers;
using com.application.contracts.Common;
using com.application.contracts.Managers;
using com.application.contracts.Repository;
using com.application.entities;
using com.application.entities.Common;
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

        private readonly IValidator<EmployeeSaveValidatorWrapper> _employeeValidator;

        private readonly IMapper<IList<Message>, ServiceResponse> _serviceResponseErrorMapper;

        private readonly IMapper<Object, ServiceResponse> _serviceResponseMapper;

        public EmployeeManager(IEmployeeRepository employeeRepository , IMapper<EmployeeSaveMapperWrapper, Employee> employeeSaveMapper
            ,IValidator<EmployeeSaveValidatorWrapper> employeeValidator , IMapper<IList<Message>, ServiceResponse> serviceResponseErrorMapper,
            IMapper<Object, ServiceResponse> serviceResponseMapper)
        {
            _employeeRepository = employeeRepository;
            _employeeSaveMapper = employeeSaveMapper;
            _employeeValidator = employeeValidator;
            _serviceResponseMapper = serviceResponseMapper;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
        }

        public ServiceResponse GetEmployeeById(int id)
        {
            try
            {
                var returnObject= _employeeRepository.GetEmployeeById(id);

                return _serviceResponseMapper.Map(returnObject);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ServiceResponse GetEmployeeList()
        {
            try
            {
                var returnObject= _employeeRepository.GetEmployees();

                return _serviceResponseMapper.Map(returnObject);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public ServiceResponse Save(Employee employee)
        {
            try
            {
                var isEdit = employee.Id == 0 ? false : true;

                //validation
                if (!_employeeValidator.Validate(
                    new EmployeeSaveValidatorWrapper
                    {
                        Request = employee,
                        IsEmailReferenceExists = _employeeRepository.IsEmailReferenceExists(employee, isEdit)
                    }
                    , out IList<Message> messages))
                {
                    return _serviceResponseErrorMapper.Map(messages);
                }


                var saveObject = _employeeSaveMapper.Map(new EmployeeSaveMapperWrapper
                {
                    Employee = employee,
                    User = "Admin",
                    IsEdit = employee.Id == 0 ? false : true,

                });

               
                var returnObject= _employeeRepository.Save(employee);

                return _serviceResponseMapper.Map(returnObject);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
