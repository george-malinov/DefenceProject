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
                ImageUrl = "https://moneyinc.com/wp-content/uploads/2018/06/Audi-Logo-750x422.jpg",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "BMW",
                Description = "BMW Discussions",
                Title = "BMW Club",
                ImageUrl = "https://images.fineartamerica.com/images/artworkimages/mediumlarge/2/bmw-emblem-ericamaxine-price.jpg",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "Ford",
                Description = "Ford Discussions",
                Title = "Ford Club",
                ImageUrl = "https://turbologo.com/articles/wp-content/uploads/2019/10/ford-logo-illustration-1280x720.jpg",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "Mercedes",
                Description = "Mercedes Discussions",
                Title = "Mercedes Club",
                ImageUrl = "https://i.ebayimg.com/images/g/lGcAAOSwVapfMBp9/s-l300.jpg",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "Opel",
                Description = "Opel Discussions",
                Title = "Opel Club",
                ImageUrl = "https://wallpaperaccess.com/full/3203626.jpg",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "Peugeto",
                Description = "Peugeto Discussions",
                Title = "Peugeto Club",
                ImageUrl = "https://lofrev.net/wp-content/photos/2016/06/peugeot_emblem_1.jpg",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "Renault",
                Description = "Renault Discussions",
                Title = "Renault Club",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/5f/Renault_logo.jpg",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "Subaru",
                Description = "Subaru Discussions",
                Title = "Subaru Club",
                ImageUrl = "https://cdn.wallpapersafari.com/14/47/MSs0P3.jpg",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Name = "VW",
                Description = "VW Discussions",
                Title = "VW Club",
                ImageUrl = "https://newsroom.vw.com/app/uploads/2020/04/2021_Atlas_SEL_Premium_4Motion-Large-11309-1024x683.jpg",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
