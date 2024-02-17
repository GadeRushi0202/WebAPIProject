using Microsoft.EntityFrameworkCore;
using WebAPIProject.Data;
using WebAPIProject.Models;

namespace WebAPIProject.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext db;
        public CartRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddToCart(cart carts)
        {
            int result = 0;
            carts.Qty = 1;
            await db.carts.AddAsync(carts);
            result = await db.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<cart>> GetCart(int Userid)
        {
            var result = await (from c in db.carts
                                join p in db.Products
                                on c.p_id equals p.P_id
                                where c.Rid == c.Rid
                                select new cart
                                {
                                    p_name = p.P_name,
                                    Price = p.Price,
                                    Image = p.Image,
                                }).ToListAsync();
            return result;
        }
    }
}
