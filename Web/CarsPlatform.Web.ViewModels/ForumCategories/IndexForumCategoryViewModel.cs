namespace CarsPlatform.Web.ViewModels.ForumCategories
{
    using CarsPlatform.Data.Models;
    using CarsPlatform.Services.Mapping;

    public class IndexForumCategoryViewModel : IMapFrom<ForumCategory>
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int ForumPostsCount { get; set; }

        public string Url => $"/{this.Title}";
    }
}
