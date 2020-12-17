namespace CarsPlatform.Web.ViewModels.Cars
{
    using System.Linq;

    using AutoMapper;
    using CarsPlatform.Data.Models;
    using CarsPlatform.Services.Mapping;

    public class MyCarsInListViewModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Model { get; set; }

        public int Prize { get; set; }

        public string Miles { get; set; }

        public int LocationId { get; set; }

        public string LocationTown { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Car, MyCarsInListViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "/images/cars/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extention));
        }
    }
}
