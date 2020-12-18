namespace CarsPlatform.Data.Models
{
    using System.Collections.Generic;

    using CarsPlatform.Data.Common.Models;

    public class ForumCategory : BaseDeletableModel<int>
    {
        public ForumCategory()
        {
            this.ForumPosts = new HashSet<ForumPost>();
        }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ForumPost> ForumPosts { get; set; }
    }
}
