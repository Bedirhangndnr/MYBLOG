using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.AutoMapper.Profiles
{
        //    Identity yapısı ile ilgili manager'ları MVC katmanımızda kullandığımız için bu şekilde eklemeyi tercih ettik.
        //    Tabii ki, Services katmanımıza da ekleyebilirdik.

    public class ArticleProfile : Profile
    { 
        public ArticleProfile()
        {
            CreateMap<ArticleAddDto, Article>().ForMember(dest=>dest.CreatedDate,opt=>opt.MapFrom(x=>DateTime.Now)); // article dto'yu Article'a dönüştürme işlemi
            CreateMap<ArticleUpdateDto, Article>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now)); ; // article dto'yu Article'a dönüştürme işlemi
            CreateMap<Article, ArticleUpdateDto>();
        }
    }
}
