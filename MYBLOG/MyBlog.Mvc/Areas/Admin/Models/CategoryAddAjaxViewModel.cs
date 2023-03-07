using MyBlog.Entities.Dtos;

namespace MyBlog.Mvc.Areas.Admin.Models
{
    public class CategoryAddAjaxViewModel
    {
        public CategoryAddDto CategoryAddDto{ get; set; }
        //ajax ile post işlemi yaptığımızda dönecek model.
        public string CategoryAddPartial{ get; set; }
        public CategoryDto CategoryDto{ get; set; }
    }
}
