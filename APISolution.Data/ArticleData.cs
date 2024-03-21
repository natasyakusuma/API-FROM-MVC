using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APISolution.Data.Interfaces.Data;
using APISolution.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace APISolution.Data
{
	public class ArticleData : IArticleData
	{
		private readonly AppDbContext _context;
		public ArticleData(AppDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Delete(int id)
		{
			try
			{
				var deleteArticle = await _context.Articles.SingleOrDefaultAsync(a => a.ArticleId == id);
				if (deleteArticle == null)
				{
					throw new ArgumentException("Data not found");
				}
				_context.Articles.Remove(deleteArticle);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<IEnumerable<Article>> GetAll()
		{
			var article = await _context.Articles
				.OrderBy(a => a.Title)
				.ToListAsync();
			return article;

		}


		public async Task<IEnumerable<Article>> GetArticleByCategory(int categoryId)
		{
			var articles = await _context.Articles
				.Where(a => a.CategoryId == categoryId)
				.OrderBy(a => a.Title)
				.ToListAsync();
			return articles;


		}

		public async Task<IEnumerable<Article>> GetArticleWithCategory()
		{
			var articles = await _context.Articles
				.Include(a => a.Category)
				.OrderBy(a => a.Title)
				.ToListAsync();
			return articles;
		}

		public async Task<Article> GetById(int id)
		{
			var articles = await _context.Articles.Include(a => a.Category).FirstOrDefaultAsync(a => a.ArticleId == id);
			if (articles == null)
			{
				throw new ArgumentException("Data not found");
			}
			return articles;
		}

		public async Task<int> GetCountArticles()
		{
			var count = await _context.Articles.CountAsync();
			return count;
		}

		public async Task<IEnumerable<Article>> GetWithPaging(int categoryId, int pageNumber, int pageSize)
		{
			var articles = await _context.Articles
				.Where(a => a.CategoryId == categoryId)
				.OrderBy(a => a.Title)
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();
			return articles;
		}

		public async Task<Article> Insert(Article entity)
		{
			try
			{
				await _context.AddAsync(entity);
				await _context.SaveChangesAsync();
				return entity;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<Task> InsertArticleWithCategory(Article article)
		{
			//Pak Erick Code
			try
			{
				_context.Categories.Add(article.Category);
				_context.Articles.Add(article);
				await _context.SaveChangesAsync();
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}


			//MY CODE
			//var category = await _context.Categories.FindAsync(article.CategoryId);
			//if (category == null)
			//{
			//	throw new ArgumentException("Category not found");
			//}
			//var newarticle = new Article //instance
			//{
			//	Title = article.Title,
			//	Details = article.Details,
			//	CategoryId = article.CategoryId,
			//	Category = category,
			//	Pic = article.Pic
			//};
			//_context.Articles.Add(article);
			//await _context.SaveChangesAsync();

		}

		public async Task<int> InsertWithIdentity(Article article)
		{
			throw new NotImplementedException();
		}

		public async Task<Article> Update(int id, Article entity)
		{
			try
			{
				var UpdateArticle = _context.Articles.SingleOrDefault(a => a.ArticleId == id);
				if (UpdateArticle == null)
				{
					throw new Exception("Article Not Found");

				}
				UpdateArticle.Title = entity.Title;
				UpdateArticle.Details = entity.Details;
				UpdateArticle.PublishDate = entity.PublishDate;
				UpdateArticle.IsApproved = entity.IsApproved;
				UpdateArticle.Pic = entity.Pic;
				UpdateArticle.CategoryId = entity.CategoryId;

				await _context.SaveChangesAsync();
				return UpdateArticle;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
