using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APISolution.BLL.DTOs;
using APISolution.BLL.Interfaces;
using APISolution.Data.Interfaces.Data;
using APISolution.Domain;
using AutoMapper;

namespace APISolution.BLL
{
	public class ArticleBLL : IArticleBLL
	{

		private readonly IArticleData _articleData;
		private readonly IMapper _mapper;
		public ArticleBLL(IArticleData articleData, IMapper mapper)
		{
			_articleData = articleData;
			_mapper = mapper;
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ArticleDTO>> GetArticleByCategory(int categoryId)
		{
			throw new NotImplementedException();
		}

		public async Task<ArticleDTO> GetArticleById(int id)
		{
			var article = await _articleData.GetById(id);
			var articleDTO = _mapper.Map<ArticleDTO>(article);
			return articleDTO;
		}

		public async Task<IEnumerable<ArticleDTO>> GetArticleWithCategory()
		{
			var articles = await _articleData.GetArticleWithCategory();
			var articlesDTO = _mapper.Map<IEnumerable<ArticleDTO>>(articles);
			return articlesDTO;
		}

		public Task<int> GetCountArticles()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ArticleDTO>> GetWithPaging(int categoryId, int pageNumber, int pageSize)
		{
			throw new NotImplementedException();
		}

		public async Task Insert(ArticleCreateDTO article)
		{
			var articleEntity= _mapper.Map<Article>(article);
			await _articleData.InsertArticleWithCategory(articleEntity);


		}


		public async Task<int> InsertWithIdentity(ArticleCreateDTO article)
		{
			throw new NotImplementedException();
		}

		public Task Update(ArticleUpdateDTO article)
		{
			throw new NotImplementedException();
		}
	}
}
