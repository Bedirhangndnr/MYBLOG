using MyBlog.Entities.Dtos;
using MyBlog.Shared.Utilities.Results;

namespace MyBlog.Mvc.Halpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<UploadedImageDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName="userImages");
        IDataResult<UploadedImageDto> Delete(string pictureName);
    }
}
