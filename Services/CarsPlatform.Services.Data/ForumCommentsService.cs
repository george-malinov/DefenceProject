namespace CarsPlatform.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using CarsPlatform.Data.Common.Repositories;
    using CarsPlatform.Data.Models;

    public class ForumCommentsService : IForumCommendsService
    {
        private readonly IDeletableEntityRepository<ForumComment> forumCommentsRepository;

        public ForumCommentsService(IDeletableEntityRepository<ForumComment> forumCommentsRepository)
        {
            this.forumCommentsRepository = forumCommentsRepository;
        }

        public async Task CreateForumComment(int forumPostId, string userId, string content, int? parentId = null)
        {
            var comment = new ForumComment
            {
                Content = content,
                ParentId = parentId,
                ForumPostId = forumPostId,
                UserId = userId,
            };
            await this.forumCommentsRepository.AddAsync(comment);
            await this.forumCommentsRepository.SaveChangesAsync();
        }

        public bool IsInForumPostId(int forumCommentId, int forumPostId)
        {
            var forumCommentPostId = this.forumCommentsRepository.All().Where(x => x.Id == forumCommentId)
                .Select(x => x.ForumPostId).FirstOrDefault();
            return forumCommentPostId == forumPostId;
        }
    }
}
