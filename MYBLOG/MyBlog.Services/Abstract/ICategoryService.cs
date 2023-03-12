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
        Task<IDataResult<CategoryDto>> GetAsync(int categoryId);
        /// <summary>
        /// Verilen ID parametresine ait kategorinin CategoryUpdateDtoTemsilini döner.
        /// </summary>
        /// <param name="categoryId">0'dan büyük intager bir id değeri</param>
        /// <returns>Asenkron bir operasyon ile task olarak işlem sonucunu DataResult tipinde geri döner</returns>
        Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAllAsync();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<CategoryListDto>> GetAllByDeletedAsync();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActiveAsync();
        // burada bahsedilen dto-> data transfer oject denebilir. Bu sınıflar sadece frondend tarafında kullanılacak olan alanları kapsar.
        Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdByName); //Iresult dönülecek ve kategorinin tamamını değil sadece frontend tarafını kullanıcıdan istiyor olacağız.
        Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IDataResult<CategoryDto>> DeleteAsync(int categoriId, string modifiedByName); // veritabınından silmez, pasif yapar.
        Task<IDataResult<CategoryDto>> UndoDeleteAsync(int categoriId, string modifiedByName); // veritabınından silmez, pasif yapar.
        Task<IResult> HardDeleteAsync(int categoriId); // veritabanından siler.
        Task<IDataResult<int>> CountAsync(); // veritabanından siler.
        Task<DataResult<int>> CountByNonDeletedAsync();


    }
}
