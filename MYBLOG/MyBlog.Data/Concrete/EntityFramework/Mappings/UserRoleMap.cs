using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Concrete.EntityFramework.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => x.RoleId);
            builder.ToTable("AspNetUserRoles");
            builder.HasData(
                new UserRole
                {
                    RoleId = 1, // admin role admin user
                    UserId = 1
                },
                new UserRole
                {
                    RoleId = 2,
                    UserId = 2
                }
            );
        }
    }
}
