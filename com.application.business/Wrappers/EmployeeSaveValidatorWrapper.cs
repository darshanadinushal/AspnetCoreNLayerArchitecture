using com.application.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.application.business.Wrappers
{
    public class EmployeeSaveValidatorWrapper
    {
        
        public Employee Request { get; set; }
       
        public bool IsEmailReferenceExists { get; set; }
    }
}
