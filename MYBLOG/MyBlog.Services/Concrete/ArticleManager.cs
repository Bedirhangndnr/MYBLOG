using AutoMapper;
using MyBlog.Data.Abstract;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.Dtos;
using MyBlog.Services.Abstract;
using MyBlog.Services.Utilities;
using MyBlog.Shared.Utilities.Results;
using MyBlog.Shared.Utilities.Results.Abstract;
using MyBlog.Shared.Utilities.Results.ComplexTypes;
using MyBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Concrete
{
    public class ArticleManager :ManagerBase, IArticleService
    {
        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResult> AddAsync(ArticleAddDto ArticleAddDto, string createdByName, int userId)
        {
            var article= Mapper.Map<Article>(ArticleAddDto);
            article.CreatedByName= createdByName;
            article.ModifiedByName= createdByName;
            article.UserId = userId;// sessiondan id çekene kadar manuel olarak kalacak.
            await UnitOfWork.Articles.AddAsync(article);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Article.Add(article.Title)); 
        }

        public async Task<IDataResult<ArticleDto>> GetAsync(int articleId)
        {
            var article = await UnitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Category);
            if (article!=null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article= article,
                    ResultStatus= ResultStatus.Success,
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, null, Messages.Article.NotFound(false));

        }

        public async Task<IDataResult<ArticleListDto>> GetAllAsync()
        {
            var articles = await UnitOfWork.Articles.GetAllAsync(null, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, null, Messages.Article.NotFound(false));
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategoryAsync(int categoryId)
        {
            var ısAnyCategory = await UnitOfWork.Categories.AnyAsync(c=>c.Id==categoryId);
            if (ısAnyCategory)
            {
                var articles = await UnitOfWork.Articles.GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive, a => a.User, a => a.Category);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success,
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, null, Messages.Article.NotFound(false));
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, null, Messages.Article.NotFound(false));
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAsync()
        {
            var articles = await UnitOfWork.Articles.GetAllAsync(a => !a.IsDeleted, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, null, Messages.Article.NotFound(false));
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var articles=await UnitOfWork.Articles.GetAllAsync(a=>!a.IsDeleted && a.IsActive, a=> a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, null, Messages.Article.NotFound(false));
        }

        public Task<IDataResult<IList<Article>>> GetAll_Generic(Article t)
        {
            throw new NotImplementedException();
        }
        public async Task<IResult> DeleteAsync(int articleId, string modifiedByName)
        {
            var value=await UnitOfWork.Articles.AnyAsync(x=>x.Id==articleId);
            if (value)
            {
                var article = await UnitOfWork.Articles.GetAsync(a => a.Id == articleId);
                article.IsDeleted = true;
                article.ModifiedByName=modifiedByName;
                article.ModifiedDate=DateTime.Now;
                await UnitOfWork.Articles.UpdateAsync(article).ContinueWith(t => UnitOfWork.SaveAsync());
                return new Result(resultStatus: ResultStatus.Success, Messages.Article.Update(article.Title));
            }
            return new Result(resultStatus: ResultStatus.Error, Messages.Article.NotFound(false));
        }
        public async Task<IResult> HardDeleteAsync(int articleId)
        {
            var value = await UnitOfWork.Articles.AnyAsync(x => x.Id == articleId);
            string articleName;
            if (value)
            {
                var article = await UnitOfWork.Articles.GetAsync(a => a.Id == articleId);
                articleName = article.Title;
                await UnitOfWork.Articles.DeleteAsync(article).ContinueWith(t => UnitOfWork.SaveAsync());
                return new Result(resultStatus: ResultStatus.Success, Messages.Article.Delete(articleName));
            }
            return new Result(resultStatus: ResultStatus.Error, Messages.Article.NotFound(false));
        }

        public async Task<IResult> UpdateAsync(ArticleUpdateDto ArticleUpdateDto, string modifiedByName)
        {
            var oldArticle=await UnitOfWork.Articles.GetAsync(a=>a.Id== ArticleUpdateDto.Id);
            var article=Mapper.Map<ArticleUpdateDto, Article>(ArticleUpdateDto, oldArticle);
            article.ModifiedByName = modifiedByName;
            await UnitOfWork.Articles.UpdateAsync(article).ContinueWith(t=>UnitOfWork.SaveAsync());
            return new Result(resultStatus: ResultStatus.Success, Messages.Article.Update(article.Title));
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var articlesCount = await UnitOfWork.Articles.CountAsync();
            if (articlesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, articlesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, -1, Messages.General.UnKnownError());
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var articlesCount = await UnitOfWork.Articles.CountAsync(x=>!x.IsDeleted);
            if (articlesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, articlesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, -1, Messages.General.UnKnownError());
            }
        }

        public async Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDtoAsync(int articleId)
        {
            var result = await UnitOfWork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await UnitOfWork.Articles.GetAsync(a => a.Id == articleId);
                var articleUpdateDto = Mapper.Map<ArticleUpdateDto>(article);
                return new DataResult<ArticleUpdateDto>(ResultStatus.Success, articleUpdateDto);
            }
            else
            {
                return new DataResult<ArticleUpdateDto>(ResultStatus.Error, null, Messages.Article.NotFound(isPlural: false));
            }
        }

        public async Task<IResult> UndoDeleteAsync(int articleId, string modifiedByName)
        {
            var result = await UnitOfWork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await UnitOfWork.Articles.GetAsync(a => a.Id == articleId);
                article.IsDeleted = false;
                article.IsActive = true;
                article.ModifiedByName = modifiedByName;
                article.ModifiedDate = DateTime.Now;
                await UnitOfWork.Articles.UpdateAsync(article);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Article.UndoDelete(article.Title));
            }
            return new Result(ResultStatus.Error, Messages.Article.NotFound(isPlural: false));
        }
        public async Task<IDataResult<ArticleListDto>> GetAllByDeletedAsync()
        {
            var articles =
                await UnitOfWork.Articles.GetAllAsync(a => a.IsDeleted, ar => ar.User,
                    ar => ar.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, null, Messages.Article.NotFound(isPlural: true));
        }
    }
}
