namespace CarsPlatform.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CarsPlatform.Data.Models;

    public class ForumCategoiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ForumCategories.Any())
            {
                return;
            }

            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "Audi",
                Description = "Audi Discussions",
                Title = "Audi Club",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "BMW",
                Description = "BMW Discussions",
                Title = "BMW Club",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "Ford",
                Description = "Ford Discussions",
                Title = "Ford Club",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "Mercedes",
                Description = "Mercedes Discussions",
                Title = "Mercedes Club",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "Opel",
                Description = "Opel Discussions",
                Title = "Opel Club",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "Peugeto",
                Description = "Peugeto Discussions",
                Title = "Peugeto Club",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "Renault",
                Description = "Renault Discussions",
                Title = "Renault Club",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "Subaru",
                Description = "Subaru Discussions",
                Title = "Subaru Club",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "VW",
                Description = "VW Discussions",
                Title = "VW Club",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
