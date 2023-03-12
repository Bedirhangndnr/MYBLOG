using MyBlog.Entities.ComplexTypes;
using MyBlog.Entities.Dtos;
using MyBlog.Shared.Utilities.Results;

namespace MyBlog.Mvc.Halpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile,PictureType pictureType, string folderName=null);
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}
