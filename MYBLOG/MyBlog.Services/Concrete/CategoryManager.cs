﻿using AutoMapper;
using MyBlog.Data.Abstract;
using MyBlog.Entities.Dtos;
using MyBlog.Services.Abstract;
using MyBlog.Shared.Entities.Concrete;
using MyBlog.Shared.Utilities.Results;
using MyBlog.Shared.Utilities.Results.Abstract;
using MyBlog.Shared.Utilities.Results.ComplexTypes;
using MyBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            var addedCategory= await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveAsync();
            //await _unitOfWork.Categories.AddAsync(new Category()
            //{

            //    Name = categoryAddDto.Name,
            //    Description = categoryAddDto.Description,
            //    Note = categoryAddDto.Note,
            //    IsActive = categoryAddDto.IsActive,
            //    CreatedByName = createdByName,
            //    CreatedDate = DateTime.Now,
            //    ModifiedByName = createdByName,
            //    ModifiedDate = DateTime.Now,
            //    IsDeleted = false
            //}).ContinueWith(t => _unitOfWork.SaveAsync());
            return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
            {
                Category=addedCategory,
                ResultStatus=ResultStatus.Success,
                Message=$"{categoryAddDto.Name} adlı kategori başarıyla eklenmiştir"
            }, $"{categoryAddDto.Name} adlı kategori başarıyla eklenmiştir");
        }
        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var oldCategory = await _unitOfWork.Categories.GetAsync(x=>x.Id==categoryUpdateDto.Id);

            var category = _mapper.Map<CategoryUpdateDto, Category>(categoryUpdateDto,oldCategory);
            category.ModifiedByName = modifiedByName;
            var updatedCategory= await _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
            {
                Category = updatedCategory,
                ResultStatus = ResultStatus.Success,
                Message = $"{categoryUpdateDto.Name} Adlı kategori başarıyla güncellenmiştir."
            }, $"{categoryUpdateDto.Name} Adlı kategori başarıyla güncellenmiştir.");
        }


        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == categoryId, x => x.Articles);
            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<CategoryDto>(ResultStatus.Error, new CategoryDto
                {
                    Category = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Boyle Bir Kategori Bulunamadı"
                }, "Kategori Bulunamadı.");
            }
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, x => x.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, new CategoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message= "Kategori Bulunamadı.",
            }, 
            "Kategori Bulunamadı.");


        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(x => !x.IsDeleted, x => x.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, new CategoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = "Kategori Bulunamadı.",
            },
            "Kategori Bulunamadı.");
        }

        public async Task<IDataResult<CategoryDto>> Delete(int categoriId, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoriId);
            if (category!=null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate=DateTime.Now;
                await _unitOfWork.Categories.DeleteAsync(category);

                var deletedCategory = await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = deletedCategory,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{deletedCategory.Name} adlı kategori başarıyla silinmiştir."
                }, $"{deletedCategory.Name} adlı kategori başarıyla silinmiştir.");
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, new CategoryDto
            {
                Category=null,
                ResultStatus = ResultStatus.Error,
                Message= "Kategori Silinemedi"
            }, "Böyle bir kategori bulunamadı");
        }
        public async Task<IResult> HardDelete(int categoriId)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == categoriId);

            if (category != null)
            {
                category.IsDeleted = true;
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{category.Name} Adlı kategori kalıcı olarak başarıyla silinmiştir.");
                //return new Result(ResultSktatus.Success, $"{category.Name} Adlı kategori kalıcı olarak başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Kategori Bulunamadı.");
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(x => !x.IsDeleted && x.IsActive, x => x.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<CategoryListDto>(ResultStatus.Error, null, "Kategori Bulunamadı.");
            }
        }

        public async Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDto(int categoryId)
        {
            var result=await _unitOfWork.Categories.AnyAsync(x => x.Id == categoryId);
            if (result)
            {
                var category = await _unitOfWork.Categories.GetAsync(x => x.Id == categoryId);
                var categoryUpdateDto=_mapper.Map<CategoryUpdateDto>(category);
                return new DataResult<CategoryUpdateDto>(ResultStatus.Success, categoryUpdateDto);
            }
            return new DataResult<CategoryUpdateDto>(ResultStatus.Error, null, "Kategori bulunamadı");
        }
    }
}
