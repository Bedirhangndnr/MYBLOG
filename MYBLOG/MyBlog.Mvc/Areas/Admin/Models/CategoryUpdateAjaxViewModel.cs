using MyBlog.Entities.Dtos;

namespace MyBlog.Mvc.Areas.Admin.Models
{
    public class CategoryUpdateAjaxViewModel
    {
        public CategoryUpdateDto CategoryUpdateDto{ get; set; }
        //ajax ile post işlemi yaptığımızda dönecek model.
        public string CategoryUpdatePartial{ get; set; }
        public CategoryDto CategoryDto{ get; set; }
    }
}
