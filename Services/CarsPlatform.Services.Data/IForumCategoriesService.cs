namespace CarsPlatform.Services.Data
{
    using System.Collections.Generic;

    public interface IForumCategoriesService
    {
        IEnumerable<T> AllCategories<T>(int? count = null);

        T CategoryByTitle<T>(string title);
    }
}
