using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    public interface IMessageResourceReader
    {
        string GeneralError(int languageId);
        string PassOrUserNotValid(int languageId);

        string DataUpdatedSuccessfully(int language);
        string NotDataFound(int languageId);

        string DataDeletedSuccessfully(int language);
        string DataAddededSuccessfully(int language);
       
    }
}
