using VShop.ProductAPI.DTOs;

namespace VShop.ProductAPI.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();
        Task<CategoryDTO> GetCategoryByID(int id);
        Task AddCategory (CategoryDTO categoryDTO);
        Task UpdateCategory (CategoryDTO categoryDTO);
        Task DeleteCategory (int id);

    }
}
