namespace CarsPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CarsPlatform.Data.Common.Repositories;
    using CarsPlatform.Data.Models;
    using CarsPlatform.Services.Mapping;

    public class ForumCategoriesService : IForumCategoriesService
    {
        private readonly IDeletableEntityRepository<ForumCategory> forumCategoriesRepository;

        public ForumCategoriesService(
            IDeletableEntityRepository<ForumCategory> forumCategoriesRepository)
        {
            this.forumCategoriesRepository = forumCategoriesRepository;
        }

        public IEnumerable<T> AllCategories<T>(int? count = null)
        {
            IQueryable<ForumCategory> query =
                this.forumCategoriesRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T CategoryByTitle<T>(string title)
        {
            var forumCategory = this.forumCategoriesRepository.All()
                .Where(x => x.Title == title)
                .To<T>().FirstOrDefault();
            return forumCategory;
        }
    }
}
