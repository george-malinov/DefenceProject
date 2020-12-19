namespace CarsPlatform.Web.ViewModels.ForumComments
{
    public class CreateForumCommentInputModel
    {
        public int ForumPostId { get; set; }

        public int ParentId { get; set; }

        public string Content { get; set; }
    }
}
