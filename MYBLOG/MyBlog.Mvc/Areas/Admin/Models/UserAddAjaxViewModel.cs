using MyBlog.Entities.Dtos;

namespace MyBlog.Mvc.Areas.Admin.Models
{
    public class UserAddAjaxViewModel
    {
        public UserAddDto UserAddDto{ get; set; }
        //ajax ile post işlemi yaptığımızda dönecek model.
        public string UserAddPartial{ get; set; }
        public UserDto UserDto{ get; set; }
    }
}
