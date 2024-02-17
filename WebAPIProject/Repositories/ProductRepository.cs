using WebAPIProject.Data;
using WebAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPIProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddCategory(Category category)
        {
            int result = 0;
            await db.Categorys.AddAsync(category);
            result = await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> AddProduct(Product product)
        {
            int result = 0;
            await db.Products.AddAsync(product);
            result = await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteCategory(int id)
        {
            int result = 0;
            var category = await db.Categorys.Where(x => x.c_id == id).FirstOrDefaultAsync();
            if (category != null)
            {
                db.Categorys.Remove(category);
                result = await db.SaveChangesAsync();
            }
            return result;
        }

        public async Task<int> DeleteProduct(int id)
        {
            int result = 0;
            var product = await db.Products.Where(x => x.P_id == id).FirstOrDefaultAsync();
            if (product != null)
            {
                db.Products.Remove(product);
                result = await db.SaveChangesAsync();
            }
            return result;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await db.Categorys.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await db.Categorys.Where(x => x.c_id == id).FirstOrDefaultAsync();
            return category;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await db.Products.Where(x => x.P_id == id).FirstOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var res = await (from p in db.Products
                             join c in db.Categorys
                             on p.c_id equals c.c_id
                             select new Product
                             {
                                 P_id = p.P_id,
                                 P_name = p.P_name,
                                 Price = p.Price,
                                 Image = p.Image,
                                 c_id = p.c_id,
                                 c_name = c.c_name,
                             }).ToListAsync();
            return res;
        }

        public async Task<int> UpdateCategory(Category category)
        {
            int result = 0;
            var c = await db.Categorys.Where(x => x.c_id == category.c_id).FirstOrDefaultAsync();
            if (c != null)
            {

                c.c_id = category.c_id;
                c.c_name = category.c_name;
                result = await db.SaveChangesAsync();
            }
            return result;
        }

        public async Task<int> UpdateProduct(Product product)
        {
            int result = 0;
            var p = await db.Products.Where(x => x.P_id == product.P_id).FirstOrDefaultAsync();
            if (p != null)
            {
                p.P_name = product.P_name;
                p.Price = product.Price;
                p.Image = product.Image; 
                p.c_id = product.c_id;
                result = await db.SaveChangesAsync();
            }
            return result;
        }
    }
}
