using MyBlog.Shared.Entities.Concrete;
using MyBlog.Shared.Utilities.Results;
using MyBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Abstract
{
    public interface IGenericService<T>
    {
        //Task<IDataResult<IList<T>>> GetAll_Generic(T t_generc);
        //Task<IResult> Delete_generic(int id, string modifiedByName_generic); // veritabınından silmez, pasif yapar.

    }
}
