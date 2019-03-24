using com.application.contracts.Common;
using com.application.entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.application.common.Mappers
{
    public class ServiceErrorMapper : IMapper<IList<Message>, ServiceResponse>
    {
        public ServiceResponse Map(IList<Message> input) => new ServiceResponse
        {
            IsError = true,
            Messages = input
        };
    }
}
