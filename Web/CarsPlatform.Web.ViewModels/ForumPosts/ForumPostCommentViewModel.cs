namespace CarsPlatform.Web.ViewModels.ForumPosts
{
    using System;

    using CarsPlatform.Data.Models;
    using CarsPlatform.Services.Mapping;
    using Ganss.XSS;

    public class ForumPostCommentViewModel : IMapFrom<ForumComment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }
    }
}
