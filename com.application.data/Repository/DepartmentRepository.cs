using com.application.contracts.Common;
using com.application.contracts.Repository;
using com.application.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.application.data.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        

        private readonly universaldbEntities _universalEntities;

        private readonly IEntityMapper _entityMapper;

        public DepartmentRepository(universaldbEntities universalEntities, IEntityMapper entityMapper)
        {
            _universalEntities = universalEntities;
            _entityMapper = entityMapper;

        }

       

        public IEnumerable<Department> GetDepartmentList()
        {
            try
            {
                var returnObj = _universalEntities.App_T_Department.Where(x=>x.IsActive==true).ToList();

                return _entityMapper.Map<IList<App_T_Department>, List<Department>>(returnObj);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
