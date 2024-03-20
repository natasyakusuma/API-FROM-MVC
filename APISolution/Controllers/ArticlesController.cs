using APISolution.BLL.DTOs;
using APISolution.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APISolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        // GET: api/<ArticlesController>   
        private readonly IArticleBLL _articleBLL;

        public ArticlesController(IArticleBLL articleBLL)
        {
            _articleBLL = articleBLL;
        }
        [HttpGet]
        public async Task<IEnumerable<ArticleDTO>> GetArticleWithCategory()
		{
			var  articles = await _articleBLL.GetArticleWithCategory();
			return articles;
		}


		//[HttpGet]
		//public IActionResult GetAll()
		//{
		//    var articles = _articleBLL.GetArticleWithCategory();
		//    return Ok(articles);
		//}

		////[HttpGet("{id}")]
		////public ArticleDTO GetArticleById(int id)
		////{
		////    return _articleBLL.GetArticleById(id);
		////}

		//[HttpPost]
		//public IActionResult Post(ArticleCreateDTO article)
		//{
		//    try
		//    {
		//        _articleBLL.Insert(article);
		//        return Ok("Data berhasil ditambahkan");
		//    }
		//    catch (Exception ex)
		//    {
		//        return BadRequest(ex.Message);
		//    }
		//}

		//[HttpPut]
		//public IActionResult Put(ArticleUpdateDTO article)
		//{
		//    try
		//    {
		//        _articleBLL.Update(article);
		//        return Ok("Data berhasil diubah");
		//    }
		//    catch (Exception ex)
		//    {
		//        return BadRequest(ex.Message);
		//    }
		//}

		////[HttpDelete("{id}")]
		////public IActionResult Delete(int id)
		////{
		////    var result = GetArticleById(id);
		////    if (result == null)
		////    {
		////        return BadRequest("Data tidak ditemukan");
		////    }
		////    _articleBLL.Delete(id);
		////    return Ok("Data Article ID : {id} berhasil di delete");
		////}

	}
}
