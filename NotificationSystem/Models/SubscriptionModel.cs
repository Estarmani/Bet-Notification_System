using NotificationSystem.Utilities;

namespace NotificationSystem.Models
{
    public class SubscriptionModel
    {
       
        public SubscriptionPackage Package { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
        public string PinNumber { get; set; } = string.Empty ;
    }
}
