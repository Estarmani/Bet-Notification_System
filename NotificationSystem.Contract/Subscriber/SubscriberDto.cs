using NotificationSystem.Utilities;


namespace NotificationSystem.Contract;

public class SubscriberDto
{
    public string MobileNumber { get; set; } = string.Empty; 
}
public class SubscriptionDto
{
    public SubscriptionPackage Package { get;  set; }
    public SubscriptionType SubscriptionType { get; set; }
}
public class VoucherDto
{
    public string PinNumber { get; set; } = string.Empty ;
}
public class NewSubscriptionDto
{
    public SubscriberDto Subscriber { get; set; }
    public VoucherDto Voucher { get; set; }
    public SubscriptionDto Subscriptions { get; set; }
}
