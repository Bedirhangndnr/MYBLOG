using MyBlog.Entities.Dtos;
using MyBlog.Shared.Entities.Concrete;
using MyBlog.Shared.Utilities.Results.Abstract;
using MyBlog.Shared.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Entities.Concrete;
using MyBlog.Shared.Utilities.Results.Concrete;

namespace MyBlog.Services.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
        Task<IDataResult<ArticleDto>> GetAsync(int articleId);
        Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDtoAsync(int articleId);
        Task<IDataResult<ArticleListDto>> GetAllAsync();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<ArticleListDto>> GetAllByDeletedAsync();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActiveAsync ();
        Task<IDataResult<ArticleListDto>> GetAllByCategoryAsync (int categoryId);
        Task<IResult> AddAsync(ArticleAddDto ArticleAddDto, string createdByName, int userId); 
        Task<IResult> UpdateAsync(ArticleUpdateDto ArticleUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int ArticleId, string modifiedByName);
        Task<IResult> UndoDeleteAsync(int ArticleId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int ArticleId); 
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();

    }
}
