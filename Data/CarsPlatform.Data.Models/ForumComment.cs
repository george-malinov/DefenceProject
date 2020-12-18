namespace CarsPlatform.Data.Models
{
    using CarsPlatform.Data.Common.Models;

    public class ForumComment : BaseDeletableModel<int>
    {
        public int ForumPostId { get; set; }

        public virtual ForumPost ForumPost { get; set; }

        public int ParentId { get; set; }

        public virtual ForumComment Parent { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
