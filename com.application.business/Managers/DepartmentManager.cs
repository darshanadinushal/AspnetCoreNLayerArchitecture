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
   public  class DepartmentManager : IDepartmentManager
    {

        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

   

        public IEnumerable<Department> GetDepartmentList()
        {
            try
            {
                return _departmentRepository.GetDepartmentList();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
