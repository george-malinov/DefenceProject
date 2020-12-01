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

        await dbContext.Categories.AddAsync(new Category { Name = "Седан" });
        await dbContext.Categories.AddAsync(new Category { Name = "Хечбек" });
        await dbContext.Categories.AddAsync(new Category { Name = "Комби" });
        await dbContext.Categories.AddAsync(new Category { Name = "Кабриолет" });
        await dbContext.Categories.AddAsync(new Category { Name = "Лимузина" });
        await dbContext.Categories.AddAsync(new Category { Name = "Кросоувър" });
        await dbContext.Categories.AddAsync(new Category { Name = "Купе" });

        await dbContext.SaveChangesAsync();
    }
}