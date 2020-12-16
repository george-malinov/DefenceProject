namespace CarsPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarsPlatform.Web.ViewModels.Cars;

    public interface ICarsService
    {
        IEnumerable<T> All<T>(int page, int itemsPerPage = 6);

        int GetCount();

        T GetCarById<T>(int id);

        Task CreateAsync(CreateCarInputModel input, string userId, string imagePath);

        Task DeleteAsync(int id);

        Task EditCarAsync(int id, EditCarInputModel input);

        IEnumerable<T> GetUserCars<T>(string username, int page, int itemsPerPage = 6);
    }
}
