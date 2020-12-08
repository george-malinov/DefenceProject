using System;
using System.Linq;
using System.Threading.Tasks;

using CarsPlatform.Data;
using CarsPlatform.Data.Models;
using CarsPlatform.Data.Seeding;

public class CategoriesSeeder : ISeeder
{
    public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
    {
        if (dbContext.Categories.Any())
        {
            return;
        }

        await dbContext.Categories.AddAsync(new Category { Name = "Sedan" });
        await dbContext.Categories.AddAsync(new Category { Name = "Hatchback" });
        await dbContext.Categories.AddAsync(new Category { Name = "Station Wagon" });
        await dbContext.Categories.AddAsync(new Category { Name = "Cabriolet" });
        await dbContext.Categories.AddAsync(new Category { Name = "Limousine" });
        await dbContext.Categories.AddAsync(new Category { Name = "CUV" });
        await dbContext.Categories.AddAsync(new Category { Name = "Coupe" });

        await dbContext.SaveChangesAsync();
    }
}
