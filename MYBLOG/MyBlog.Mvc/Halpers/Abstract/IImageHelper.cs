using MyBlog.Entities.Dtos;
using MyBlog.Shared.Utilities.Results;

namespace MyBlog.Mvc.Halpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName="userImages");
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}
