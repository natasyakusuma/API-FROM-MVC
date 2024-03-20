
using APISolution.BLL.DTOs;
using System.Collections.Generic;

namespace APISolution.BLL.Interfaces
{
    public interface IArticleBLL
    {
        Task Insert(ArticleCreateDTO article);
        Task <IEnumerable<ArticleDTO>> GetArticleWithCategory();
        Task <IEnumerable<ArticleDTO>> GetArticleByCategory(int categoryId);
        Task <int> InsertWithIdentity(ArticleCreateDTO article);
        Task Update(ArticleUpdateDTO article);
        Task Delete(int id);
        Task <ArticleDTO> GetArticleById(int id);
        Task<IEnumerable<ArticleDTO>> GetWithPaging(int categoryId, int pageNumber, int pageSize);
        Task <int> GetCountArticles();
    }
}
