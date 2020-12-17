namespace CarsPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CarsPlatform.Data.Common.Repositories;
    using CarsPlatform.Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> AllCategories()
        {
            return this.categoriesRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
