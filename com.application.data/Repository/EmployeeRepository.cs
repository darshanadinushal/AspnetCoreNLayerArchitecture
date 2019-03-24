using com.application.contracts.Common;
using com.application.contracts.Repository;
using com.application.data.Mappers;
using com.application.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.application.data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly universaldbEntities _universalEntities;

        private readonly IEntityMapper _entityMapper;

        public EmployeeRepository(universaldbEntities universalEntities, IEntityMapper entityMapper)
        {
            _universalEntities = universalEntities;
            _entityMapper = entityMapper;

        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                var returnObj = _universalEntities.App_T_Employee.Where(c => c.Id == id).FirstOrDefault();
                return _entityMapper.Map<App_T_Employee, Employee>(returnObj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                var returnObj = _universalEntities.App_SP_EmployeeGet().ToList();

                return _entityMapper.Map<IList<App_SP_EmployeeGet_Result>, List<Employee>>(returnObj);
            }
            catch (Exception)
            {

                throw;
            }
      
        }

        public bool IsEmailReferenceExists(Employee employee ,bool isUpdate)
        {
            try
            {
                if (!isUpdate && employee!=null)
                {
                    var returnObj = _universalEntities.App_T_Employee.Where(x=>x.Email== employee.Email).FirstOrDefault();

                    if (returnObj!=null)
                    {
                        return true;
                    }
                }
                return false;
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
                var returnObj = _entityMapper.Map<Employee, App_T_Employee>(employee);

                if (employee.Id > 0)
                {
                    var result = _universalEntities.App_T_Employee.Attach(returnObj);

                    _universalEntities.Entry(result).State = EntityState.Modified;
                    _universalEntities.SaveChanges();

                    return _entityMapper.Map<App_T_Employee, Employee>(result);
                }
                else
                {
                   
                    var result = _universalEntities.App_T_Employee.Add(returnObj);
                    _universalEntities.SaveChanges();

                    return _entityMapper.Map<App_T_Employee, Employee>(result);
                }

                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
