using Microsoft.EntityFrameworkCore;
using NotificationSystem.Contract;
using NotificationSystem.Domain.Subscription;
using NotificationSystem.Infrastructure._Core;
using NotificationSystem.Utilities;
using NotificationSystem.Utilities._Core;
using NotificationSystem.Utilities.ResponseUtils;
using System.Numerics;




namespace NotificationSystem.Service;

public class SubscriberService : ISubscriberService
{
    private readonly INotificationSystemContext _Context;
    private readonly IValidatorHelper _Validator;
    
    public AppStatusInfo Status { get; set; }
    public SubscriberService(INotificationSystemContext context, IValidatorHelper validator)
    {
        _Context = context;
        _Validator = validator;
        
        Status = new AppStatusInfo
        {
            IsSuccess = false,
            Message = new AppMessage()
        };
    }

    public async Task<string> Subscription(SubscriberDto subscriber, SubscriptionDto subscription, VoucherDto voucher)
    {
        //validate mobile number
        if (!subscriber.MobileNumber.IsMobileNoValid())
        {
            Status.IsSuccess = false;
            return Status.Message.FriendlyMessage = "Invalid mobile number";
        }
        //var isValidMobileNumber = await _Validator.ValidateMobileNumber(subscriber.MobileNumber);
        //if (isValidMobileNumber == false)
        //{
        //    Status.IsSuccess = false;
        //    return Status.Message.FriendlyMessage = "Invalid mobile number";
        //}

        //Validate pin number
        var isValidPinNumber = await _Validator.ValidatePinNumber(voucher.PinNumber);
        if (isValidPinNumber == false)
        {
            Status.IsSuccess = false;
            return Status.Message.FriendlyMessage = "Invalid pin number";
        }

        // check if subscriber exist
        var thisSubscriber = await _Context.Subscribers.FirstOrDefaultAsync(x => x.MobileNumber == subscriber.MobileNumber);
        if (thisSubscriber == null)
        {
            thisSubscriber = Subscriber.CreateSubscriber(subscriber.MobileNumber);
        }


        //Validate Pin Status is active

        var thisPinNumber = await _Context.VouchersProductions.Include(vp => vp.Vouchers)
        .Where(vp => vp.Vouchers.Any(v => v.PinNumber == voucher.PinNumber))
        .FirstOrDefaultAsync();
        if (thisPinNumber == null || thisPinNumber.Vouchers == null)
        {
            Status.IsSuccess = false;
            Status.Message.FriendlyMessage = "Pin number does not exist";
            return "";
        }
        if(thisPinNumber.Vouchers.Count(v => v.Status == VoucherStatus.InActive) > 0)
        {
            Status.IsSuccess = false;
        }
        if(thisPinNumber.Vouchers.Count(v => v.Status == VoucherStatus.Used) > 0)
        {
            Status.IsSuccess= false;
        }
       

        //Update Voucher status to used and the number that used it
        var updatedVoucher = thisPinNumber.UpdateVoucher(voucher.PinNumber, thisSubscriber.MobileNumber);
        thisSubscriber.CreditWallet(updatedVoucher.Amount, thisSubscriber.SubscriberId);

        //Mapping packages to their monetry value
        decimal subscriptionAmount = 0;
        switch (subscription.Package)
        {
            case SubscriptionPackage.WeeklyHalfPackage:
                subscriptionAmount = WeeklyHalfPackage;
                break;
            case SubscriptionPackage.WeeklyFullPackage:
                subscriptionAmount = WeeklyFullPackage;
                break;
            case SubscriptionPackage.MonthlyHalfPlusPackage:
                subscriptionAmount = MonthlyHalfPlusPackage;
                break;
            case SubscriptionPackage.MonthlyFullPackage:
                subscriptionAmount = MonthlyFullPackage;
                break;
            case SubscriptionPackage.MonthlyFullPlusPackage:
                subscriptionAmount = MonthlyFullPlusPackage;
                break;
            default:
                return Status.Message.FriendlyMessage = "Invalid Subscription type ";

        }

        //Calculation for only similar package
        int maxSubscriptions = 0;
        decimal totalSubscriptionAmount = 0;

        if (updatedVoucher.Amount % subscriptionAmount != 0)
        {
             maxSubscriptions = (int)(updatedVoucher.Amount / subscriptionAmount);
             totalSubscriptionAmount = maxSubscriptions * subscriptionAmount;
            for (int i = 0; i < maxSubscriptions; i++)
            {
                thisSubscriber.AddSubscription(subscriptionAmount, subscription.SubscriptionType, subscription.Package);
                thisSubscriber.DebitWallet(subscriptionAmount, thisSubscriber.SubscriberId);
            }
        }

        maxSubscriptions = (int)(updatedVoucher.Amount / subscriptionAmount);
        totalSubscriptionAmount = maxSubscriptions * subscriptionAmount;
        for (int i = 0; i < maxSubscriptions; i++)
        {
            thisSubscriber.AddSubscription(subscriptionAmount, subscription.SubscriptionType, subscription.Package);
            thisSubscriber.DebitWallet(subscriptionAmount, thisSubscriber.SubscriberId);
        }

        try
        {
            var result = await _Context.Subscribers.AddAsync(thisSubscriber);
            await _Context.SaveChangesAsync();
            if(result.Entity.SubscriberId < 1)
            {
                Status.IsSuccess = false;
                return Status.Message.FriendlyMessage = "Operation failed please try again later";
            }
        }
        catch (Exception ex)
        {
            Status.Message.TechMessage = ex.GetBaseException().Message;
            return Status.Message.FriendlyMessage = "Process Failed! Please try again later";
        }

        Status.IsSuccess = true;
        return Status.Message.FriendlyMessage = "Subscription successful";


    }


    private decimal WeeklyHalfPackage = 200;
    private decimal WeeklyFullPackage = 500;
    private decimal MonthlyHalfPlusPackage = 850;
    private decimal MonthlyFullPackage = 1000;
    private decimal MonthlyFullPlusPackage = 1200;
}
