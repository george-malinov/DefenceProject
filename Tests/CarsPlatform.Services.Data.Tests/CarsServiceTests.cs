namespace CarsPlatform.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CarsPlatform.Data.Common.Repositories;
    using CarsPlatform.Data.Models;
    using CarsPlatform.Web.ViewModels.Cars;
    using Moq;
    using Xunit;

    public class CarsServiceTests
    {
        [Fact]
        public void GetCountReturnsTheRightCountOfCars()
        {
            var listCars = new List<Car>();

            var mocRepoCar = new Mock<IDeletableEntityRepository<Car>>();
            var mocRepoLocation = new Mock<IRepository<Location>>();

            mocRepoCar.Setup(x => x.All()).Returns(listCars.AsQueryable());
            mocRepoCar.Setup(x => x.AddAsync(It.IsAny<Car>())).Callback((Car car) => listCars.Add(car));

            var carService = new CarsService(mocRepoCar.Object, mocRepoLocation.Object);

            var location = new Location { Region = "test1", Town = "test2" };
            var car = new Car { Model = "Car1", Location = location };
            listCars.Add(car);
            listCars.Add(car);
            listCars.Add(car);

            var count = carService.GetCount();

            Assert.Equal(3, count);
        }

        [Fact]
        public void TEST()
        {
            var listCars = new List<Car>();
            var listLocations = new List<Location>();

            var mocRepoCar = new Mock<IDeletableEntityRepository<Car>>();
            var mocRepoLocation = new Mock<IRepository<Location>>();

            mocRepoCar.Setup(x => x.All()).Returns(listCars.AsQueryable());
            mocRepoCar.Setup(x => x.AddAsync(It.IsAny<Car>())).Callback((Car car) => listCars.Add(car));

            var carService = new CarsService(mocRepoCar.Object, mocRepoLocation.Object);

            var car = new Car
            {
                Id = 1,
            };

            listCars.Add(car);

            var car1 = carService.GetCarById<Car>(1);

            Assert.True(car.Id == car1.Id, "Error");
        }
    }
}
