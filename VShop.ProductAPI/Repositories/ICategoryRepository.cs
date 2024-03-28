using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<IEnumerable<Category>> GetCategoryProducts();
        Task<Category> GetByID(int id);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(int id);

    }
}
