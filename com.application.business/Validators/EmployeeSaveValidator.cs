using com.application.business.Wrappers;
using com.application.contracts.Common;
using com.application.entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.application.business.Validators
{
    public class EmployeeSaveValidator : IValidator<EmployeeSaveValidatorWrapper>
    {

        
        private readonly IErrorMessages _errorMessages;
       
        public EmployeeSaveValidator(IErrorMessages errorMessages)
        {
            _errorMessages = errorMessages;
        }


       

        public bool Validate(EmployeeSaveValidatorWrapper obj, out IList<Message> messages)
        {
            messages = new List<Message>();
            bool validator = true;


            //data can't be null
            if (string.IsNullOrWhiteSpace(obj.Request.FirstName) || obj.Request.DepartmentId == 0
                || !(obj.Request.Email != null ) )
            {
                messages.Add(_errorMessages.GetDataCantEmpty());
            }

            if (obj.IsEmailReferenceExists)
            {
                messages.Add(_errorMessages.CheckEmployeeEmailIsExists());
                return false;
            }

            return validator = (messages.Count > 0) ? false : true;
        }



        public void Dispose()
        {
          
        }
    }
}
