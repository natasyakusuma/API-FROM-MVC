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

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _articleData.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticleByCategory(int categoryId)
        {
            var articles = await _articleData.GetArticleByCategory(categoryId);
            var articleDtos = _mapper.Map<IEnumerable<ArticleDTO>>(articles);
            return articleDtos;
        }

        public async Task<ArticleDTO> GetArticleById(int id)
        {
            var article = await _articleData.GetById(id);
            var articleDto = _mapper.Map<ArticleDTO>(article);
            return articleDto;
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticleWithCategory()
        {
            var articles = await _articleData.GetArticleWithCategory();
            var articleDtos = _mapper.Map<IEnumerable<ArticleDTO>>(articles);
            return articleDtos;
        }

        public async Task<int> GetCountArticles()
        {
            return await _articleData.GetCountArticles();
        }

        public Task<IEnumerable<ArticleDTO>> GetWithPaging(int categoryId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<ArticleDTO> Insert(ArticleCreateDTO article)
        {
            try
            {
                var articleInsert = _mapper.Map<Article>(article);
                var articleInserted = await _articleData.Insert(articleInsert);
                var articleDto = _mapper.Map<ArticleDTO>(articleInserted);
                return articleDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<int> InsertWithIdentity(ArticleCreateDTO article)
        {
            throw new NotImplementedException();
        }

        public async Task<ArticleDTO> Update(int id, ArticleUpdateDTO article)
        {
            try
            {
                var updateArticle = _mapper.Map<Article>(article);
                var articleUpdated = await _articleData.Update(id, updateArticle);
                var articleDto = _mapper.Map<ArticleDTO>(articleUpdated);
                return articleDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
