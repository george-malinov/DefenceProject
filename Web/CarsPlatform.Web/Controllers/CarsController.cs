namespace CarsPlatform.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using CarsPlatform.Data.Models;
    using CarsPlatform.Services.Data;
    using CarsPlatform.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public CarsController(
            ICarsService carsService,
            ICategoriesService categoriesService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.carsService = carsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
            this.environment = environment;
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

        public IActionResult CreateCar()
        {
            var viewModel = new CreateCarInputModel();
            viewModel.Categories = this.categoriesService.AllCategories();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Categories = this.categoriesService.AllCategories();
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.carsService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.Categories = this.categoriesService.AllCategories();
                return this.View(input);
            }

            return this.Redirect("/");
        }

        public IActionResult SingleCar(int id)
        {
            var car = this.carsService.GetCarById<SingleCarViewModel>(id);
            return this.View(car);
        }
    }
}
