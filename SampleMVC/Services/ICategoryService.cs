using APISolution.BLL.DTOs;

namespace SampleMVC.Services
{
	public interface ICategoryService
	{
		Task<IEnumerable<CategoryDTO>> GetAll();
		Task<CategoryDTO> GetById(int id);
        Task<int> GetCount();
        Task<IEnumerable<CategoryDTO>> GetByPage(int page, int pageSize);
        Task <CategoryDTO> Insert(CategoryCreateDTO categoryCreateDTO);
		Task<CategoryDTO> Update(int id,CategoryUpdateDTO categoryUpdateDTO);
		Task Delete(int id);
	}
}
