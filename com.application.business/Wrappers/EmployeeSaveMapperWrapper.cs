using com.application.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.application.business.Wrappers
{
    public class EmployeeSaveMapperWrapper
    {
        public Employee Employee { get; set; }

        public string User { get; set; }

        public bool IsEdit { get; set; }
    }
}
