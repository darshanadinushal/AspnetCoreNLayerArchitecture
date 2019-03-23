using com.application.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.application.contracts.Repository
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartmentList();
    }
}
