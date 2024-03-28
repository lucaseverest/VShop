using Microsoft.EntityFrameworkCore;
using System.Net;
using VShop.ProductAPI.Context;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByID(int id)
        {
            return await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Category>> GetCategoryProducts()
        {
            return await _context.Categories.Include(c => c.Products).ToListAsync();

        }

        public async Task<Category> Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Delete(int id)
        {
            var category = await GetByID(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
