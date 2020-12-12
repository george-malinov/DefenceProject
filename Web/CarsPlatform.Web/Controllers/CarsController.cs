namespace CarsPlatform.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using CarsPlatform.Data.Common.Repositories;
    using CarsPlatform.Data.Models;
    using CarsPlatform.Services.Data;
    using CarsPlatform.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;
        private readonly IRepository<Image> imageRepository;

        public CarsController(
            ICarsService carsService,
            ICategoriesService categoriesService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment,
            IRepository<Image> imageRepository)
        {
            this.carsService = carsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
            this.environment = environment;
            this.imageRepository = imageRepository;
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

        [Authorize]
        public IActionResult CreateCar()
        {
            var viewModel = new CreateCarInputModel();
            viewModel.Categories = this.categoriesService.AllCategories();
            return this.View(viewModel);
        }

        [Authorize]
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

            return this.Redirect("/Cars/All");
        }

        public IActionResult SingleCar(int id)
        {
            var car = this.carsService.GetCarById<SingleCarViewModel>(id);
            var imageUrls = this.imageRepository.AllAsNoTracking();
            List<string> imgeUrls = new List<string>();

            foreach (var image in imageUrls)
            {
                if (image.CarId == id)
                {
                    var physicalPath = $"/images/cars/{image.Id}.{image.Extention}";
                    imgeUrls.Add(physicalPath);
                }
            }

            car.ImageUrls = new List<string>(imgeUrls);

            return this.View(car);
        }
    }
}
