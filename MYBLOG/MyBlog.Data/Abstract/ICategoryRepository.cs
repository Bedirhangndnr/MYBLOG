﻿using MyBlog.Shared.Data.Abstract;
using MyBlog.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Abstract
{
    public interface ICategoryRepository:IEntityRepository<Category>
    {
        Task <Category> GetById (int id);
    }
}
