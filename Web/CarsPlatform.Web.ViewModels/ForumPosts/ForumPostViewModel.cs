namespace CarsPlatform.Web.ViewModels.ForumPosts
{
    using System;
    using System.Collections.Generic;

    using CarsPlatform.Data.Models;
    using CarsPlatform.Services.Mapping;
    using Ganss.XSS;

    public class ForumPostViewModel : IMapFrom<ForumPost>, IMapTo<ForumPost>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }

        public int VotesCount { get; set; }

        public IEnumerable<ForumPostCommentViewModel> ForumComments { get; set; }
    }
}
