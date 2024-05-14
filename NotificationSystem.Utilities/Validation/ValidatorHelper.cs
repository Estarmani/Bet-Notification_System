using NotificationSystem.Utilities._Core;
using System.Text.RegularExpressions;


namespace NotificationSystem.Utilities;


public class ValidatorHelper : IValidatorHelper
{
    public async Task<bool> ValidateMobileNumber(string mobileNumber)
    {
        if (string.IsNullOrEmpty(mobileNumber)) return false;
        string pattern = @"^\d{11}$";
        return Regex.IsMatch(mobileNumber, pattern);
    }
    public async Task<bool> ValidatePinNumber(string pinNumber)
    {
        if (string.IsNullOrEmpty(pinNumber)) return false;
        string pattern = @"^[1-9]\d{11}$";
        return Regex.IsMatch(pinNumber, pattern);
    }
}
