using Microsoft.EntityFrameworkCore;
using WebAPIProject.Data;
using WebAPIProject.Models;

namespace WebAPIProject.Repositories
{
    public class OrdersRepo : IOrdersRepo
    {
        private readonly ApplicationDbContext db;
        public OrdersRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Orders>> MyOrders(int Rid)
        {
            var result = await (from o in db.Orders
                                join p in db.Products
                                on o.Id equals p.P_id
                                where o.Rid == Rid
                                select new Orders
                                {
                                    Id = p.P_id,
                                    p_name = p.P_name,
                                    Price = p.Price,
                                    Image = p.Image,
                                }).ToListAsync();
            return result;
        }


        public async Task<int> BuyNow(Orders orders)
        {
            int result = 0;
            orders.Qty = 1;
            await db.Orders.AddAsync(orders);
            result = await db.SaveChangesAsync();
            return result;
        }
    }
}
