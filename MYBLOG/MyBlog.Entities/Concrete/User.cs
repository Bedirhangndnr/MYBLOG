using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MyBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Concrete
{
    public class User: IdentityUser<int>
    {

        public string Picture{ get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
