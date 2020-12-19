namespace CarsPlatform.Services.Data
{
    using System.Threading.Tasks;

    public interface IForumCommendsService
    {
        Task CreateForumComment(int postId, string userId, string content, int? parentId = null);

        bool IsInForumPostId(int commentId, int postId);
    }
}
