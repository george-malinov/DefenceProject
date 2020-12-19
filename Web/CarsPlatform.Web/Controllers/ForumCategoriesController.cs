namespace CarsPlatform.Web.Controllers
{
    using System;

    using CarsPlatform.Services.Data;
    using CarsPlatform.Web.ViewModels.ForumCategories;
    using Microsoft.AspNetCore.Mvc;

    public class ForumCategoriesController : BaseController
    {
        private const int ItemsPerPage = 5;
        private readonly IForumCategoriesService forumCategoriesService;
        private readonly IForumPostsService forumPostsService;

        public ForumCategoriesController(
            IForumCategoriesService forumCategoriesService,
            IForumPostsService forumPostsService)
        {
            this.forumCategoriesService = forumCategoriesService;
            this.forumPostsService = forumPostsService;
        }

        public IActionResult IndexForum()
        {
            var viewModel = new IndexViewModel
            {
                ForumCategories =
                    this.forumCategoriesService.AllCategories<IndexForumCategoryViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult GetForumCategoryByTitle(string title, int page = 1)
        {
            var viewModel =
                this.forumCategoriesService.CategoryByTitle<ForumCategoryViewModel>(title);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            viewModel.ForumPosts = this.forumPostsService
                .GetPostByCategoryId<PostInForumCategoryViewModel>(viewModel.Id, ItemsPerPage, (page - 1) * ItemsPerPage);

            var count = this.forumPostsService.GetPostCountByCategoryId(viewModel.Id);
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);
            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }
    }
}
