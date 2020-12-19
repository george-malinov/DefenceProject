namespace CarsPlatform.Web.ViewModels.ForumPosts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CarsPlatform.Data.Models;
    using CarsPlatform.Services.Mapping;

    public class ForumPostCreateInputModel : IMapTo<ForumPost>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Category")]
        public int ForumCategoryId { get; set; }

        public IEnumerable<ForumCategoryDropDownViewModel> ForumCategories { get; set; }
    }
}
