using MyBlog.Entities.Dtos;
using MyBlog.Shared.Entities.Concrete;
using MyBlog.Shared.Utilities.Results;
using MyBlog.Shared.Utilities.Results.Abstract;
using MyBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Abstract
{
    public interface ICategoryService: IGenericService<Category>
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId);
        Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDto(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAll();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeleted();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive();
        // burada bahsedilen dto-> data transfer oject denebilir. Bu sınıflar sadece frondend tarafında kullanılacak olan alanları kapsar.
        Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdByName); //Iresult dönülecek ve kategorinin tamamını değil sadece frontend tarafını kullanıcıdan istiyor olacağız.
        Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IDataResult<CategoryDto>> Delete(int categoriId, string modifiedByName); // veritabınından silmez, pasif yapar.
        Task<IResult> HardDelete(int categoriId); // veritabanından siler.
        Task<IDataResult<int>> Count(); // veritabanından siler.
        Task<DataResult<int>> CountByIsDeleted();


    }
}
