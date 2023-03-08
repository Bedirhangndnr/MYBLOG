using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Abstract;
using MyBlog.Data.Concrete.EntityFramework.Context;
using MyBlog.Entities.Concrete;
using MyBlog.Shared.Data.Concrete.EntityFramework;
using MyBlog.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Category> GetById(int id)
        {
            return await MyBlogContext.Categories.SingleOrDefaultAsync(x => x.Id == id);
        }

        private MyBlogContext MyBlogContext
        {
            get
            {
                return _context as MyBlogContext;
            }
        }
    }
}
