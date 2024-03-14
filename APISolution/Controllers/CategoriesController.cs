using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;

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
        public IActionResult Get()
        {
            var categories = _categoryBLL.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]  //karena ini nerima jadi tipe function gini aja gitu
        public CategoryDTO GetById(int id)
        {
            return _categoryBLL.GetById(id);
        }

     

        [HttpPost]
        public IActionResult Post(CategoryCreateDTO category)  //karena ini lebih customizeable jadi iactionresult
        {
            try
            {
                _categoryBLL.Insert(category);
                return Ok("Data berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(CategoryUpdateDTO category)
        {
            try
            {
                _categoryBLL.Update(category);
                return Ok("Data berhasil diubah");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = GetById(id);
            if (result == null)
            {
                return BadRequest("Data tidak ditemukan");
            }
            _categoryBLL.Delete(id);
            return Ok("Data Category ID : {id} berhasil di delete");
        }



    }
}
