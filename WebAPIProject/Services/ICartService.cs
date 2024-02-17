using WebAPIProject.Models;

namespace WebAPIProject.Services
{
    public interface ICartService
    {
        Task<int> AddToCart(cart carts);
        Task<IEnumerable<cart>> GetCart(int Userid);
    }
}
