namespace Bccupass_CoreMVC.Repositories.Interface
{
    public interface ITicketDetailOrderDetails:IDBRepository
    {
        public int getTicketCount(int ticketDetailId);
    }
}
