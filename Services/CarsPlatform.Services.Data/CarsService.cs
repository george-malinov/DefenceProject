namespace CarsPlatform.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CarsPlatform.Data.Common.Repositories;
    using CarsPlatform.Data.Models;
    using CarsPlatform.Data.Models.Enums;
    using CarsPlatform.Services.Mapping;
    using CarsPlatform.Web.ViewModels.Cars;

    public class CarsService : ICarsService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Car> carRepository;

        public CarsService(
            IDeletableEntityRepository<Car> carRepository)
        {
            this.carRepository = carRepository;
        }

        public IEnumerable<T> All<T>(int page, int itemsPerPage = 10)
        {
            var cars = this.carRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();

            return cars;
        }

        public async Task CreateAsync(CreateCarInputModel input, string userId, string imagePath)
        {
            var car = new Car
            {
                Model = input.Model,
                DateOfManufacture = input.DateOfManufacture,
                Prize = input.Prize,
                Power = input.Power,
                Miles = input.Miles,
                Collor = input.Color,
                AditionalInformation = input.AditionalInformation,
                AddedByUserId = userId,
                CategoryId = input.CategoryId,
            };

            foreach (var engine in input.EngineTypes)
            {
                car.EngineType = engine;
            }

            foreach (var transmission in input.TransmissionTypes)
            {
                car.TransmissionType = transmission;
            }

            Directory.CreateDirectory($"{imagePath}/cars/");
            foreach (var image in input.Images)
            {
                var extention = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extention.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extention}");
                }

                var dbImage = new Image
                {
                    AddedbyUserId = userId,
                    Extention = extention,
                };
                car.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/cars/{dbImage.Id}.{extention}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.carRepository.AddAsync(car);
            await this.carRepository.SaveChangesAsync();
        }

        public T GetCarById<T>(int id)
        {
            var car = this.carRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return car;
        }

        public int GetCount()
        {
            return this.carRepository.All().Count();
        }
    }
}
