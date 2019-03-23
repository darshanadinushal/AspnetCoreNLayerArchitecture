using com.application.business.Wrappers;
using com.application.contracts.Common;
using com.application.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.application.business.Mappers
{
    public class EmployeeSaveMapper : IMapper<EmployeeSaveMapperWrapper, Employee>
    {
        public Employee Map(EmployeeSaveMapperWrapper input)
        {
            var currentDate = DateTime.Now;

            if (input.Employee != null)
            {

                if (input.IsEdit)
                {
                    input.Employee.IsActive = input.Employee.IsActive;
                    input.Employee.UpdatedBy = input.User;
                    input.Employee.UpdatedDate = currentDate;
                    input.Employee.UpdatedBy = input.User;
                    input.Employee.UpdatedDate = currentDate;
                }
                else
                {
                    input.Employee.IsActive = true;
                    input.Employee.CreatedBy = input.User;
                    input.Employee.CreatedDate = currentDate;
                }
            }
            return input.Employee;
        }
    }
}
