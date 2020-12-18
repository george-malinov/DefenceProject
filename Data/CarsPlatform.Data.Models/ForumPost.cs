namespace CarsPlatform.Data.Models
{
    using System.Collections.Generic;

    using CarsPlatform.Data.Common.Models;

    public class ForumPost : BaseDeletableModel<int>
    {
        public ForumPost()
        {
            this.ForumComments = new HashSet<ForumComment>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int ForumCategoryId { get; set; }

        public virtual ForumCategory ForumCategory { get; set; }

        public virtual ICollection<ForumComment> ForumComments { get; set; }
    }
}
