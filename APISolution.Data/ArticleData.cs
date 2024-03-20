using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APISolution.Data.Interfaces.Data;
using APISolution.Domain;
using Microsoft.EntityFrameworkCore;

namespace APISolution.Data
{
	public class ArticleData : IArticleData
	{
		private readonly AppDbContext _context;
		public ArticleData(AppDbContext context)
		{
			_context = context;
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Article>> GetAll()
		{
			throw new NotImplementedException();
		}


		public Task<IEnumerable<Article>> GetArticleByCategory(int categoryId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Article>> GetArticleWithCategory()
		{
			var articles = await _context.Articles.Include(a => a.Category).ToListAsync();
			return articles;
		}

		public async Task<Article> GetById(int id)
		{
			var articles = await _context.Articles.Include(a => a.Category).FirstOrDefaultAsync(a => a.ArticleId == id);
			return articles;
		}

		public Task<int> GetCountArticles()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Article>> GetWithPaging(int categoryId, int pageNumber, int pageSize)
		{
			throw new NotImplementedException();
		}

		public Task<Article> Insert(Article entity)
		{
			throw new NotImplementedException();
		}

		public Task InsertArticleWithCategory(Article article)
		{
			throw new NotImplementedException();
		}

		public Task<int> InsertWithIdentity(Article article)
		{
			throw new NotImplementedException();
		}

		public Task<Article> Update(int id, Article entity)
		{
			throw new NotImplementedException();
		}
	}
}
