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
   public  class DepartmentManager : IDepartmentManager
    {

        private readonly IDepartmentRepository _departmentRepository;

        private readonly IMapper<Object, ServiceResponse> _serviceResponseMapper;

        private readonly IMapper<IList<Message>, ServiceResponse> _serviceResponseErrorMapper;

        public DepartmentManager(IDepartmentRepository departmentRepository , IMapper<Object, ServiceResponse> serviceResponseMapper)
        {
            _departmentRepository = departmentRepository;
            _serviceResponseMapper = serviceResponseMapper;
        }

   

        public ServiceResponse GetDepartmentList()
        {
            try
            {
                var returnObject= _departmentRepository.GetDepartmentList();

                return _serviceResponseMapper.Map(returnObject);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
