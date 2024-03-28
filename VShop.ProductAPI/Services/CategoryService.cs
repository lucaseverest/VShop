using AutoMapper;
using VShop.ProductAPI.DTOs;
using VShop.ProductAPI.Models;
using VShop.ProductAPI.Repositories;

namespace VShop.ProductAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
        {
            var categoriesEntity = await _categoryRepository.GetCategoryProducts();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetCategoryByID(int id)
        {
            var categoryEntity = await _categoryRepository.GetByID(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }
        public async Task AddCategory(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Create(categoryEntity);
            categoryDTO.Id = categoryEntity.Id;
        }

        public async Task UpdateCategory(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Update(categoryEntity);
        }
        public async Task DeleteCategory(int id)
        {
            var categoryEntity = _categoryRepository.GetByID(id).Result;
            await _categoryRepository.Delete(categoryEntity.Id);
        }
    }
}
