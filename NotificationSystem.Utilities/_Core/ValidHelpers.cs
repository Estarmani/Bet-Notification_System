using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NotificationSystem.Utilities;

public static class ValidHelpers
{
    public static bool IsMobileNoValid(this string mobileNumber)
    {
        if (mobileNumber == null) { return false; }
        string pattern = @"^\d{11}$";
        return Regex.IsMatch(mobileNumber, pattern);
    }
}
