namespace CarsPlatform.Web.ViewModels.ForumPosts
{
    using CarsPlatform.Data.Models;
    using CarsPlatform.Services.Mapping;

    public class ForumCategoryDropDownViewModel : IMapFrom<ForumCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
