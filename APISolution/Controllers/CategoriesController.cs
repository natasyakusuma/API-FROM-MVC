using APISolution.BLL.DTOs;
using APISolution.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APISolution.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		// GET: api/<CategoriesController>
		private readonly ICategoryBLL _categoryBLL;

		public CategoriesController(ICategoryBLL categoryBLL)
		{
			_categoryBLL = categoryBLL;
		}

		[HttpGet]
		public async Task<IEnumerable<CategoryDTO>> Get()
		{
			var results = await _categoryBLL.GetAll();
			return results;
		}

		[HttpGet("{id}")]
		public async Task<CategoryDTO> GetById(int id)
		{
			return await _categoryBLL.GetById(id);
		}

		[HttpGet("/api/Categories/ByName/{name}")]
		public async Task<IEnumerable<CategoryDTO>> GetByName(string name)
		{
			return await _categoryBLL.GetByName(name);
		}

		[HttpPost]
		public async Task<CategoryDTO> Insert(CategoryCreateDTO entity)
		{
			return await _categoryBLL.Insert(entity);
		}

		[HttpPut("/api/categories")]
		public async Task<CategoryDTO> Update(int id, CategoryUpdateDTO entity)
		{
			return await _categoryBLL.Update(id,entity);
		}

		[HttpDelete("{id}")]
		public async Task<bool> Delete(int id)
		{
			return await _categoryBLL.Delete(id);

		}



		//[HttpGet("{id}")]  //karena ini nerima jadi tipe function gini aja gitu
		//public CategoryDTO GetById(int id)
		//{
		//    return _categxoryBLL.GetById(id);
		//}



		//[HttpPost]
		//public IActionResult Post(CategoryCreateDTO category)  //karena ini lebih customizeable jadi iactionresult
		//{
		//	try
		//	{
		//		_categoryBLL.Insert(category);
		//		return Ok("Data berhasil ditambahkan");
		//	}
		//	catch (Exception ex)
		//	{
		//		return BadRequest(ex.Message);
		//	}
		//}

		//[HttpPut]
		//public IActionResult Put(CategoryUpdateDTO category)
		//{
		//	try
		//	{
		//		_categoryBLL.Update(category);
		//		return Ok("Data berhasil diubah");
		//	}
		//	catch (Exception ex)
		//	{
		//		return BadRequest(ex.Message);
		//	}
		//}

		////[HttpDelete("{id}")]
		////public IActionResult Delete(int id)
		////{
		////    var result = GetById(id);
		////    if (result == null)
		////    {
		////        return BadRequest("Data tidak ditemukan");
		////    }
		////    _categoryBLL.Delete(id);
		////    return Ok("Data Category ID : {id} berhasil di delete");
		////}



	}
}
