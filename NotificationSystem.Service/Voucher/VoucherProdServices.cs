using NotificationSystem.Contract._Core;
using NotificationSystem.Contract.Vouchers;
using NotificationSystem.Domain.Voucher;
using NotificationSystem.Infrastructure._Core;
using NotificationSystem.Utilities;
using NotificationSystem.Utilities.ResponseUtils;


namespace NotificationSystem.Service;

public class VoucherProdServices : IVoucherProdServices
{
    private readonly INotificationSystemContext _Context;
    public AppStatusInfo Status { get; set; }

    public VoucherProdServices(INotificationSystemContext context)
    {
        _Context = context;
        Status = new AppStatusInfo
        {
            IsSuccess = false,
            Message = new AppMessage()
        };
    }
    public async Task<string> CreateVoucher(VoucherProductionDto productionDto)
    {
        var batchNumber = GenBatchNumber();
        if (string.IsNullOrEmpty(batchNumber)) return Status.Message.FriendlyMessage = "Unable to create Batch Number";
        var newProduction = VoucherProduction.CreateProduction(productionDto.QuantityProduced, batchNumber, productionDto.Title);
        if (newProduction == null) return Status.Message.FriendlyMessage = "Unable to create Voucher production";
        newProduction.AddVouchers(productionDto.Amount);
        try
        {
            var newVouchers = await _Context.VouchersProductions.AddAsync(newProduction);
            await _Context.SaveChangesAsync();
            if(newVouchers.Entity.VoucherProductionId < 1)
            {
                Status.IsSuccess = false;
                return Status.Message.FriendlyMessage = "Operation failed please try again later";
            }

            Status.IsSuccess = true;
            return Status.Message.FriendlyMessage = "Voucher production successful";
        }
        catch (Exception ex)
        {

            Status.Message.TechMessage = ex.GetBaseException().Message;
            return Status.Message.FriendlyMessage = "Process Failed! Please try again later";
             
        }
    }

   

    private string GenBatchNumber()
    {
        var batchNumber = AutoGens.GenerateBatchNumber();
        return batchNumber;

    }
}
