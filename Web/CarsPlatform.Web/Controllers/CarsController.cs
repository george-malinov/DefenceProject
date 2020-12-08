namespace CarsPlatform.Web.Controllers
{
    using CarsPlatform.Services.Data;
    using CarsPlatform.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        private readonly ICarsService carsService;

        public CarsController(ICarsService carsService)
        {
            this.carsService = carsService;
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 10;

            var viewModel = new CarsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                CarsCount = this.carsService.GetCount(),
                Cars = this.carsService.All<CarsInListViewModel>(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult SingleCar(int id)
        {
            var car = this.carsService.GetCarById<SingleCarViewModel>(id);
            return this.View(car);
        }
    }
}
