namespace CarsPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IForumPostsService
    {
        Task<int> CreatePostAsync(string title, string content, int categoryId, string userId);

        T GetPostById<T>(int id);

        IEnumerable<T> GetPostByCategoryId<T>(int categoryId, int? take = null, int skip = 0);

        int GetPostCountByCategoryId(int categoryId);
    }
}
