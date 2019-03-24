using com.application.contracts.Common;
using com.application.entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.application.resources
{
    public class ErrorMessages : IErrorMessages
    {
        public Message GetDataCantEmpty() => new Message
        {
            Code = "E001",
            Description = string.Format(Error.E001)
        };


        public Message CheckEmployeeEmailIsExists() => new Message
        {
            Code = "E002",
            Description = string.Format(Error.E002)
        };

       
    }
}
