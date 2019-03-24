using com.application.contracts.Common;
using com.application.entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.application.common.Mappers
{
    public class ServiceResponseMapper : IMapper<Object, ServiceResponse>
    {
        public ServiceResponse Map(object input)
        {
            return new ServiceResponse
            {
                ReturnObject = input,
                IsError = false
            };
        }
    }
}
