using WebAPIProject.Models;

namespace WebAPIProject.Repositories
{
    public interface IOrdersRepo
    {
        Task<int> BuyNow(Orders orders);
        Task<IEnumerable<Orders>> MyOrders(int Rid);
    }
}
