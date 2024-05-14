using NotificationSystem.Contract.Vouchers;


namespace NotificationSystem.Contract._Core
{
    public interface IVoucherProdServices
    {
        Task<string> CreateVoucher(VoucherProductionDto productionDto);
       
    }
}
