using com.application.entities;
using com.application.entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.application.contracts.Managers
{
    public interface IEmployeeManager
    {
        ServiceResponse GetEmployeeList();

        ServiceResponse Save(Employee employee);

        ServiceResponse GetEmployeeById(int id);
    }
}
