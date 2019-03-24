using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.application.entities.Common
{
    public class ServiceResponse
    {
        public Object ReturnObject { get; set; }

        public bool IsError { get; set; }

        public IList<Message> Messages { get; set; }
       
    }
}
