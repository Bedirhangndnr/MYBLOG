using MyBlog.Entities.Dtos;
using MyBlog.Mvc.Halpers.Abstract;
using MyBlog.Shared.Utilities.Extensions;
using MyBlog.Shared.Utilities.Results;
using MyBlog.Shared.Utilities.Results.ComplexTypes;
using MyBlog.Shared.Utilities.Results.Concrete;

namespace MyBlog.Mvc.Halpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;
        private readonly string imgFolder = "img";

        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath;
        }

        public IDataResult<ImageDeletedDto> Delete(string pictureName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/{imgFolder}", pictureName);
            if (System.IO.File.Exists(fileToDelete))
            {
                var fileInfo=new FileInfo(fileToDelete);
                var imageDeletedDto = new ImageDeletedDto
                {
                    FullName = pictureName,
                    Extension = fileInfo.Extension,  
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                System.IO.File.Delete(fileToDelete);
                return new DataResult<ImageDeletedDto>(ResultStatus.Success, imageDeletedDto);
            }
            else
            {
                return new DataResult<ImageDeletedDto>(ResultStatus.Success, null, $"Böyle bir resim bulunamadı");
            }
        }

        public async Task<IDataResult<ImageUploadedDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName)
        {
            if (!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}");
            }
            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);
            string fileExtension = Path.GetExtension(pictureFile.FileName);
            DateTime dateTime = DateTime.Now;
            string newFileName = $"{userName}_{dateTime.FullDateAndTimeStringWithUnderScore()}{fileExtension}";
            var path = Path.Combine($"{_wwwroot}/{imgFolder}/{folderName}", newFileName);
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);
            }

            return new DataResult<ImageUploadedDto>(ResultStatus.Success,
                new ImageUploadedDto
                {
                    FullName = $"{folderName}/{newFileName}",
                    OldName = oldFileName,
                    Extension = fileExtension,
                    FolderName = folderName,
                    Path = path,
                    Size = pictureFile.Length
                }
            , $"{userName} adlı kullanıcının resmi başarıyla yüklenmiştir."
        );
        }
    }
}
