using APISolution.BLL.DTOs;

namespace SampleMVC.Services
{
	public interface ICategoryService
	{
		Task<IEnumerable<CategoryDTO>> GetAll();
		Task<CategoryDTO> GetById(int id);
		Task <CategoryDTO> Insert(CategoryCreateDTO categoryCreateDTO);
		Task<CategoryDTO> Update(int id,CategoryUpdateDTO categoryUpdateDTO);
		Task<bool> Delete(int id);
	}
}
