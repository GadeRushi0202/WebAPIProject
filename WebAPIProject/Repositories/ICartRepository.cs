using WebAPIProject.Models;

namespace WebAPIProject.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddToCart(cart carts);
        Task<IEnumerable<cart>> GetCart(int Userid);
    }
}
