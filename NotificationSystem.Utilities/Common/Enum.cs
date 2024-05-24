

namespace NotificationSystem.Utilities;

public enum SubscriberStatus
{
    InActive = 0,
    Active = 1,
}
public enum SubscriptionStatus
{
    //Active = 1,
    //Expired = 2,
    Unknown,
    Pending,
    Success,
    Failed
}
public enum SubscriptionType
{
    None = 0,
    Weekly_Half = 200,
    Weekly_Full = 500,
    Monthly_Half = 850,
    Monthly_Full = 1000,
    Monthly_Full_Plus = 1200,

}
public enum SubscriptionPackage
{
    None = 0,
    Weekly_Half_Package = 10,
    Weekly_Full_Package = 35,
    Monthly_Half_Package = 55,
    Monthly_Full_Package = 80,
    Monthly_Full_Plus_Package = 100,

}

public enum WalletTransactionType
{
    Init,
    Credit,
    Debit
}


public enum VoucherStatus
{
    InActive = 0,
    Active = 1,
    Used = 2
}
public enum VPStatus
{
    InActive = 0, Active = 1,
}
