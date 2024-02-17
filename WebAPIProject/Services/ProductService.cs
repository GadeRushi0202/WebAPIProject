using WebAPIProject.Models;
using WebAPIProject.Repositories;

namespace WebAPIProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repo;
        public ProductService(IProductRepository repo)
        {
            this.repo = repo;
        }

        public async Task<int> AddCategory(Category category)
        {
            return await repo.AddCategory(category);
        }

        public async Task<int> AddProduct(Product product)
        {
            return await repo.AddProduct(product);
        }

        public async Task<int> DeleteCategory(int id)
        {
            return await repo.DeleteCategory(id);
        }

        public async Task<int> DeleteProduct(int id)
        {
            return await repo.DeleteProduct(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await repo.GetCategories();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await repo.GetCategoryById(id);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await repo.GetProductById(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await repo.GetProducts();
        }

        public async Task<int> UpdateCategory(Category category)
        {
            return await repo.UpdateCategory(category);
        }

        public async Task<int> UpdateProduct(Product product)
        {
            return await repo.UpdateProduct(product);
        }
    }
}
