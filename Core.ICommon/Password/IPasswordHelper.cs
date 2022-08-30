using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Password
{
    public interface IPasswordHelper
    {
        string CreateHash(string password);

        bool ValidatePassword(string password, string correctHash);
    }
}
