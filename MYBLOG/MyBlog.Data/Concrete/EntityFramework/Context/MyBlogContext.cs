using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Concrete.EntityFramework.Mappings;
using MyBlog.Entities.Concrete;
using MyBlog.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Concrete.EntityFramework.Context
{
    public class MyBlogContext:IdentityDbContext<User, Role, int,UserClaim, UserRole,UserLogin, RoleClaim, UserToken>
    {
        public MyBlogContext(DbContextOptions<MyBlogContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new RoleClaimMap());
            modelBuilder.ApplyConfiguration(new UserClaimMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.ApplyConfiguration(new UserTokenMap());
            modelBuilder.ApplyConfiguration(new UserLoginMap());
        }
        public DbSet<Article> Articles{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Comment> Comments{ get; set; }
        //public DbSet<Role> Roles{ get; set; }
        //public DbSet<User> Users{ get; set; }
    }
}
