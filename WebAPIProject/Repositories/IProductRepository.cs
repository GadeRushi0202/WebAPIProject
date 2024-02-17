using WebAPIProject.Models;

namespace WebAPIProject.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<int> AddProduct(Product product);
        Task<int> UpdateProduct(Product product);
        Task<int> DeleteProduct(int id);

        // Category
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task<int> AddCategory(Category category);
        Task<int> UpdateCategory(Category category);
        Task<int> DeleteCategory(int id);
    }
}
