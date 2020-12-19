namespace CarsPlatform.Web.Controllers
{
    using System.Threading.Tasks;

    using CarsPlatform.Data.Models;
    using CarsPlatform.Services.Data;
    using CarsPlatform.Web.ViewModels.ForumComments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ForumCommentsController : BaseController
    {
        private readonly IForumCommendsService forumCommendsService;
        private readonly UserManager<ApplicationUser> userManager;

        public ForumCommentsController(
            IForumCommendsService forumCommendsService,
            UserManager<ApplicationUser> userManager)
        {
            this.forumCommendsService = forumCommendsService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateForumCommentInputModel input)
        {
            var parentId =
                input.ParentId == 0 ?
                    (int?)null :
                    input.ParentId;

            if (parentId.HasValue)
            {
                if (!this.forumCommendsService.IsInForumPostId(parentId.Value, input.ForumPostId))
                {
                    return this.BadRequest();
                }
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.forumCommendsService.CreateForumComment(input.ForumPostId, userId, input.Content, parentId);
            return this.RedirectToAction("GetPostById", "ForumPosts", new { id = input.ForumPostId });
        }
    }
}
