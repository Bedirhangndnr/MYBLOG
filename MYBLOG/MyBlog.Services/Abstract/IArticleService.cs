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
        Task<IDataResult<ArticleDto>> Get(int articleId);
        Task<IDataResult<ArticleListDto>> GetAll();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeleted();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive ();
        Task<IDataResult<ArticleListDto>> GetAllByCategory (int categoryId);
        Task<IResult> Add(ArticleAddDto ArticleAddDto, string createdByName); 
        Task<IResult> Update(ArticleUpdateDto ArticleUpdateDto, string modifiedByName);
        Task<IResult> Delete(int ArticleId, string modifiedByName);
        Task<IResult> HardDelete(int ArticleId); 
        Task<IDataResult<int>> Count();
        Task<DataResult<int>> CountByIsDeleted();

    }
}
