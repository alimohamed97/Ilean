using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
   public class MessageResourceReader : IMessageResourceReader
    {
        public string DataAddededSuccessfully(int language) => ("Data Addeded Successfully");
        public string DataUpdatedSuccessfully(int language) => ("Data Updated Successfully");
        public string DataDeletedSuccessfully(int language) => ("Data Deleted Successfully");
        public string GeneralError(int languageId) =>("GeneralError");
        public string NotDataFound(int languageId) => ("NotDataFound");
   
        public string PassOrUserNotValid(int languageId) => ("PassOrUserNotValid");

    }
}
