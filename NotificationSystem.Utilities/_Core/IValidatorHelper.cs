using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Utilities._Core
{
    public interface IValidatorHelper
    {
        Task<bool> ValidateMobileNumber(string mobileNumber);
        Task<bool> ValidatePinNumber(string pinNumber);
    }
}
