using WebAPIProject.Models;
using WebAPIProject.Repositories;

namespace WebAPIProject.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepo repo;
        public OrdersService(IOrdersRepo repo)
        {
            this.repo = repo;
        }

        public Task<IEnumerable<Orders>> MyOrders(int Rid)
        {
            return repo.MyOrders(Rid);
        }

        public Task<int> BuyNow(Orders orders)
        {
            return repo.BuyNow(orders);
        }
    }
}
