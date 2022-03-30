namespace Bccupass_CoreMVC.Repositories.Interface
{
    public interface ITicketRepository : IDBRepository
    {
        public void CreateTicketOrder(int userId);
        public void CreateOrderDetail(int ticketOrderId);
    }
}
