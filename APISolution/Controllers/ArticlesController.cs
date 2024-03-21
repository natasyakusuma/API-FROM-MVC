using APISolution.BLL.DTOs;
using APISolution.BLL.Interfaces;
using APISolution.Models;
using FluentValidation;
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
        private readonly IValidator<ArticleCreateDTO> _validatorArticleCreateDto;
        private readonly IValidator<ArticleUpdateDTO> _validatorArticleUpdateDto;

        public ArticlesController(IArticleBLL articleBLL, IValidator<ArticleUpdateDTO> validatorArticleUpdateDto, IValidator<ArticleCreateDTO> validatorArticleCreateDto)
        {
            _articleBLL = articleBLL;
            _validatorArticleUpdateDto = validatorArticleUpdateDto;
            _validatorArticleCreateDto = validatorArticleCreateDto;
        }
        [HttpGet]
        public async Task<IEnumerable<ArticleDTO>> Get()
        {
            var articles = await _articleBLL.GetArticleWithCategory();
            return articles;
        }
        [HttpGet("{id}")]
        public async Task<ArticleDTO> Get(int id)
        {
            var articles = await _articleBLL.GetArticleById(id);
            return articles;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ArticleCreateDTO articleCreateDTO)
        {
            var validationResult = _validatorArticleCreateDto.Validate(articleCreateDTO);
            if (!validationResult.IsValid)
            {
                Helpers.Extensions.AddToModelState(validationResult, ModelState);
                return BadRequest(ModelState);
            }

            var article = await _articleBLL.Insert(articleCreateDTO);
            return CreatedAtAction(nameof(Get), new { id = article.ArticleID }, article);
        }


        [HttpPost("upload")]
        public async Task<IActionResult> Post([FromForm] ArticleWithFile articleWithFile)
        {
            if (articleWithFile.file == null || articleWithFile.file.Length == 0)
            {
                return BadRequest("File is required");
            }
            var newName = $"{Guid.NewGuid()}_{articleWithFile.file.FileName}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await articleWithFile.file.CopyToAsync(stream);
            }

            var articleCreateDTO = new ArticleCreateDTO
            {
                CategoryID = articleWithFile.CategoryId,
                Title = articleWithFile.Title,
                Details = articleWithFile.Details,
                IsApproved = articleWithFile.IsApproved.HasValue ? articleWithFile.IsApproved.Value : false,
                Pic = newName,

            };

            var article = await _articleBLL.Insert(articleCreateDTO);
            return CreatedAtAction(nameof(Get), new { id = article.ArticleID }, article);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ArticleUpdateDTO articleUpdateDTO)
        {
            var validationResult = _validatorArticleUpdateDto.Validate(articleUpdateDTO);
            if (!validationResult.IsValid)
            {
                Helpers.Extensions.AddToModelState(validationResult, ModelState);
                return BadRequest(ModelState);
            }
            var article = await _articleBLL.Update(id, articleUpdateDTO);
            return Ok(article);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _articleBLL.Delete(id);
            if (result)
            {
                return Ok("Data berhasil dihapus");
            }
            return NotFound("Data tidak ditemukan");
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
