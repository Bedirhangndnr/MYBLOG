using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MyBlog.Entities.Concrete;
using MyBlog.Mvc.Areas.Admin.Models;

namespace MyBlog.Mvc.Areas.Admin.ViewComponents
{
    public class UserMenuViewComponent:ViewComponent
    {
        private readonly UserManager<User> _userManager;
        public UserMenuViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        // ----->>>> Viewlara gönderilen değerler her zaman bir dto ya da view model ile gitmelidir.
        public ViewViewComponentResult Invoke()
        {
            var user= _userManager.GetUserAsync(HttpContext.User).Result;
            return View(new UserViewModel
            {
                User=user
            });

        }
    }
}
