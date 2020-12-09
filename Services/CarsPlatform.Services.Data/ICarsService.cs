namespace CarsPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarsPlatform.Web.ViewModels.Cars;

    public interface ICarsService
    {
        IEnumerable<T> All<T>(int page, int itemsPerPage = 10);

        int GetCount();

        T GetCarById<T>(int id);

        Task CreateAsync(CreateCarInputModel input, string userId, string imagePath);
    }
}
