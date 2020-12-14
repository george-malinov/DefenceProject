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
        private readonly IRepository<Location> locationRepository;

        public CarsService(
            IDeletableEntityRepository<Car> carRepository,
            IRepository<Location> locationRepository)
        {
            this.carRepository = carRepository;
            this.locationRepository = locationRepository;
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
                EngineType = input.EngineTypes,
                TransmissionType = input.TransmissionTypes,
                AditionalInformation = input.AditionalInformation,
                AddedByUserId = userId,
                CategoryId = input.CategoryId,
            };

            var location = this.locationRepository.All().FirstOrDefault(x => x.Region == input.Location.Region && x.Town == input.Location.Town);
            if (location == null)
            {
                location = new Location
                {
                    Region = input.Location.Region,
                    Town = input.Location.Town,
                };
            }

            car.Location = location;

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

        public async Task DeleteAsync(int id)
        {
            var car = this.carRepository.All().FirstOrDefault(x => x.Id == id);
            this.carRepository.Delete(car);
            await this.carRepository.SaveChangesAsync();
        }

        public async Task EditCarAsync(int id, EditCarInputModel input)
        {
            var car = this.carRepository.All().FirstOrDefault(x => x.Id == id);
            car.Model = input.Model;
            car.DateOfManufacture = input.DateOfManufacture;
            car.Prize = input.Prize;
            car.Power = input.Power;
            car.Miles = input.Miles;
            car.Collor = input.Collor;
            car.EngineType = input.EngineTypes;
            car.TransmissionType = input.TransmissionTypes;
            car.AditionalInformation = input.AditionalInformation;
            car.CategoryId = input.CategoryId;
            await this.carRepository.SaveChangesAsync();
        }
    }
}
