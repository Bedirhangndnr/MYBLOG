using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Entities.Concrete;
using MyBlog.Mvc.Areas.Admin.Models;
using MyBlog.Services.Abstract;
using MyBlog.Shared.Utilities.Results.ComplexTypes;

namespace MyBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Editor")]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly UserManager<User> _userManager;

        public HomeController(ICategoryService categoryService, IArticleService articleService, ICommentService commentService, UserManager<User> userManager)
        {
            _categoryService = categoryService;
            _articleService = articleService;
            _commentService = commentService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var categoriesCountResult= await _categoryService.CountByNonDeletedAsync();
            var articlesCountResult= await _articleService.CountByNonDeletedAsync();
            var commentsCountResult= await _commentService.CountByNonDeletedAsync();
            var usersCount= await _userManager.Users.CountAsync();
            var articlesResult= await _articleService.GetAllAsync();
            if (categoriesCountResult.ResultStatus==ResultStatus.Success&&
                articlesCountResult.ResultStatus==ResultStatus.Success&&
                commentsCountResult.ResultStatus==ResultStatus.Success&&
                articlesResult.ResultStatus==ResultStatus.Success)
            {
                return View(new DashboardViewModel
                {
                    ArticlesCount = articlesCountResult.Data,
                    CategoriesCount = categoriesCountResult.Data,
                    CommentsCount = commentsCountResult.Data,
                    UsersCount = usersCount,
                    Articles = articlesResult.Data
                });
            }
            return NotFound();
        }
    }
}
