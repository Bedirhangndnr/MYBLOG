using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IArticleRepository Articles { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
  // Kullanım örneği -> unitofwork.Categories.AddAsync();
        //unitofwork.categories.addasync();
        //unitofwork.users.addasync();
        //unitofwork.SaveAsync();
        Task<int> SaveAsync();
    }
}
