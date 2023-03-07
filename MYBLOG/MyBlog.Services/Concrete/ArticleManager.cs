using AutoMapper;
using MyBlog.Data.Abstract;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.Dtos;
using MyBlog.Services.Abstract;
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
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(ArticleAddDto ArticleAddDto, string createdByName)
        {
            var article= _mapper.Map<Article>(ArticleAddDto);
            article.CreatedByName= createdByName;
            article.ModifiedByName= createdByName;
            article.UserId = 1;// sessiondan id çekene kadar manuel olarak kalacak.
            await _unitOfWork.Articles.AddAsync(article).ContinueWith(t=>_unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{ArticleAddDto.Title} Başlıklı Makale Başarıyla Eklenmiştir."); 
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Category);
            if (article!=null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article= article,
                    ResultStatus= ResultStatus.Success,
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, null, "Böyle bir makale bulunamadı");

        }

        public async Task<IDataResult<ArticleListDto>> GetAll(int ArticleId)
        {

            var articles = await _unitOfWork.Articles.GetAllAsync(null, a => a.User, a => a.Category, a=>a.User);
            if (articles.Count>-1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, null, "Böyle bir makale bulunamadı");
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var ısAnyCategory = await _unitOfWork.Categories.AnyAsync(c=>c.Id==categoryId);
            if (ısAnyCategory)
            {
                var articles = await _unitOfWork.Articles.GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive, a => a.User, a => a.Category);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success,
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, null, "Böyle Bir Makale Bulunamadı");
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, null, "Böyle Bir Kategori Bulunamadı");
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted(int articleId)
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, null, "Böyle bir makale bulunamadı");
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive(int articleId)
        {
            var articles=await _unitOfWork.Articles.GetAllAsync(a=>!a.IsActive && a.IsActive, a=> a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, null, "Böyle bir makale bulunamadı");
        }

        public Task<IDataResult<IList<Article>>> GetAll_Generic(Article t)
        {
            throw new NotImplementedException();
        }
        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var value=await _unitOfWork.Articles.AnyAsync(x=>x.Id==articleId);
            if (value)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
                article.IsDeleted = true;
                article.ModifiedByName=modifiedByName;
                article.ModifiedDate=DateTime.Now;
                await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(resultStatus: ResultStatus.Success, $"{article.Title} Başlıklı Makale Başarıyla Güncellenmiştir");
            }
            return new Result(resultStatus: ResultStatus.Error, "Böyle Bir Makale Bulunamadı");
        }
        public async Task<IResult> HardDelete(int articleId)
        {
            var value = await _unitOfWork.Articles.AnyAsync(x => x.Id == articleId);
            string articleName;
            if (value)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
                articleName = article.Title;
                await _unitOfWork.Articles.DeleteAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(resultStatus: ResultStatus.Success, $"{articleName} Başlıklı Makale Başarıyla Veritabanından Silinmiştir");
            }
            return new Result(resultStatus: ResultStatus.Error, "Böyle Bir Makale Bulunamadı");
        }

        public async Task<IResult> Update(ArticleUpdateDto ArticleUpdateDto, string modifiedByName)
        {
            var article=_mapper.Map<Article>(ArticleUpdateDto);
            article.ModifiedByName = modifiedByName;
            await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(t=>_unitOfWork.SaveAsync());
            return new Result(resultStatus: ResultStatus.Success, $"{ArticleUpdateDto.Title} Başlıklı Makale Başarıyla Güncellenmiştir");
        }
    }
}
