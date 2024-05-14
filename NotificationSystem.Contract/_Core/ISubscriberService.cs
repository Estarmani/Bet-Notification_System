using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Contract;

public interface ISubscriberService
{
    Task<string> Subscription(SubscriberDto subscriber, SubscriptionDto subscription, VoucherDto voucher);
}
