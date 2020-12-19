namespace CarsPlatform.Web.Controllers
{
    using System.Threading.Tasks;

    using CarsPlatform.Data.Models;
    using CarsPlatform.Services.Data;
    using CarsPlatform.Web.ViewModels.ForumPosts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ForumPostsController : BaseController
    {
        private readonly IForumCategoriesService forumCategoriesService;
        private readonly IForumPostsService forumPostsService;
        private readonly UserManager<ApplicationUser> userManager;

        public ForumPostsController(
            IForumCategoriesService forumCategoriesService,
            IForumPostsService forumPostsService,
            UserManager<ApplicationUser> userManager)
        {
            this.forumCategoriesService = forumCategoriesService;
            this.forumPostsService = forumPostsService;
            this.userManager = userManager;
        }

        public IActionResult GetPostById(int id)
        {
            var postViewModel = this.forumPostsService.GetPostById<ForumPostViewModel>(id);
            if (postViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(postViewModel);
        }

        [Authorize]
        public IActionResult CreatePost()
        {
            var forumCategories = this.forumCategoriesService.AllCategories<ForumCategoryDropDownViewModel>();
            var viewModel = new ForumPostCreateInputModel
            {
                ForumCategories = forumCategories,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost(ForumPostCreateInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var postId = await this.forumPostsService.CreatePostAsync(input.Title, input.Content, input.ForumCategoryId, user.Id);
            this.TempData["InfoMessage"] = "Forum post created!";
            return this.RedirectToAction(nameof(this.GetPostById), new { id = postId });
        }
    }
}
