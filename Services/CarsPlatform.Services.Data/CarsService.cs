namespace CarsPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CarsPlatform.Data.Common.Repositories;
    using CarsPlatform.Data.Models;
    using CarsPlatform.Services.Mapping;

    public class CarsService : ICarsService
    {
        private readonly IDeletableEntityRepository<Car> carRepository;

        public CarsService(IDeletableEntityRepository<Car> carRepository)
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

        public int GetCount()
        {
            return this.carRepository.All().Count();
        }
    }
}
