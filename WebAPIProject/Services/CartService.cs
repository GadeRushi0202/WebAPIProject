using WebAPIProject.Models;
using WebAPIProject.Repositories;

namespace WebAPIProject.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository repo;
        public CartService(ICartRepository repo)
        {
            this.repo = repo;
        }

        public Task<int> AddToCart(cart carts)
        {
            return repo.AddToCart(carts);
        }

        public Task<IEnumerable<cart>> GetCart(int Userid)
        {
            return repo.GetCart(Userid);
        }
    }
}
