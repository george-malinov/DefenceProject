namespace CarsPlatform.Web.ViewModels.ForumCategories
{
    using System.Collections.Generic;

    using CarsPlatform.Data.Models;
    using CarsPlatform.Services.Mapping;

    public class ForumCategoryViewModel : IMapFrom<ForumCategory>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public IEnumerable<PostInForumCategoryViewModel> ForumPosts { get; set; }
    }
}
