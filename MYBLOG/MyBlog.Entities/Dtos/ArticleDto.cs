using MyBlog.Entities.Concrete;
using MyBlog.Shared.Utilities.Results.ComplexTypes;
using MyBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Dtos
{
    public class ArticleDto
    {
        public Article Article { get; set; }
        public ResultStatus ResultStatus { get; set; }
    }
}
