using MyBlog.Entities.Dtos;

namespace MyBlog.Mvc.Areas.Admin.Models
{
    public class UserUpdateAjaxViewModel
    {
        public UserUpdateDto UserUpdateDto{ get; set; }
        //ajax ile post işlemi yaptığımızda dönecek model.
        public string UserUpdatePartial{ get; set; }
        public UserDto UserDto{ get; set; }
    }
}
