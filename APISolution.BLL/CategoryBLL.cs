using APISolution.BLL.DTOs;
using APISolution.BLL.Interfaces;
using APISolution.Data.Interfaces.Data;
using APISolution.Domain;
using AutoMapper;


namespace APISolution.BLL
{
	public class CategoryBLL : ICategoryBLL

	{
		private readonly ICategoryData _categoryData;
		private readonly IMapper _mapper;
		public CategoryBLL(ICategoryData categoryData, IMapper mapper)
		{
			_categoryData = categoryData;
			_mapper = mapper;
		}
		public async Task<bool> Delete(int id)
		{
			await _categoryData.Delete(id);
			return true;
		}

		public async Task<IEnumerable<CategoryDTO>> GetAll()
		{
			var categories = await _categoryData.GetAll();
			var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
			return categoriesDTO;
		}

		public async Task<CategoryDTO> GetById(int id)
		{
			var categories = await _categoryData.GetById(id);
			var categoriesDTO = _mapper.Map<CategoryDTO>(categories);
			return categoriesDTO;
		}

		public async Task<IEnumerable<CategoryDTO>> GetByName(string name)
		{
			var categories = await _categoryData.GetByName(name);
			var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
			return categoriesDTO;
		}

		public Task<int> GetCountCategories(string name)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<CategoryDTO>> GetWithPaging(int pageNumber, int pageSize, string name)
		{
			throw new NotImplementedException();
		}

		public async Task<CategoryDTO> Insert(CategoryCreateDTO entity)
		{
			var category = _mapper.Map<Category>(entity);
			await _categoryData.Insert(category);
			var categoryDTO = _mapper.Map<CategoryDTO>(category);
			return categoryDTO;
		}

	

		public async Task<CategoryDTO> Update(int id, CategoryUpdateDTO entity)
		{
			var category = _mapper.Map<Category>(entity);
			await _categoryData.Update(id, category);
			var categoryDTO = _mapper.Map<CategoryDTO>(category);
			return categoryDTO;
		}

	
	}
}
