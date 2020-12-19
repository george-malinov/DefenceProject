namespace CarsPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarsPlatform.Data.Common.Repositories;
    using CarsPlatform.Data.Models;
    using CarsPlatform.Services.Mapping;

    public class ForumPostsService : IForumPostsService
    {
        private readonly IDeletableEntityRepository<ForumPost> forumPostRepository;

        public ForumPostsService(IDeletableEntityRepository<ForumPost> forumPostRepository)
        {
            this.forumPostRepository = forumPostRepository;
        }

        public async Task<int> CreatePostAsync(string title, string content, int forumCategoryId, string userId)
        {
            var forumPost = new ForumPost
            {
                ForumCategoryId = forumCategoryId,
                Content = content,
                Title = title,
                UserId = userId,
            };

            await this.forumPostRepository.AddAsync(forumPost);
            await this.forumPostRepository.SaveChangesAsync();
            return forumPost.Id;
        }

        public IEnumerable<T> GetPostByCategoryId<T>(int forumCategoryId, int? take = null, int skip = 0)
        {
            var query = this.forumPostRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.ForumCategoryId == forumCategoryId).Skip(skip);
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetPostById<T>(int id)
        {
            var forumPost = this.forumPostRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return forumPost;
        }

        public int GetPostCountByCategoryId(int forumCategoryId)
        {
            return this.forumPostRepository.All().Count(x => x.ForumCategoryId == forumCategoryId);
        }
    }
}
