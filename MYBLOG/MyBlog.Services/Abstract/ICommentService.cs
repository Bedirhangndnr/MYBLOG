using MyBlog.Shared.Utilities.Results;
using MyBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Abstract
{
    public interface ICommentService
    {
        Task<IDataResult<int>> Count();
        Task<IDataResult<int>> CountByIsDeleted();
    }
}
