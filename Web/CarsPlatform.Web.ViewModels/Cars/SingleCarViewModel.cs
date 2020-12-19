namespace CarsPlatform.Web.ViewModels.Cars
{
    using System;
    using System.Collections.Generic;

    using CarsPlatform.Data.Models;
    using CarsPlatform.Data.Models.Enums;
    using CarsPlatform.Services.Mapping;
    using Ganss.XSS;

    public class SingleCarViewModel : IMapFrom<Car>
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public DateTime DateOfManufacture { get; set; }

        public EngineType EngineType { get; set; }

        public int Power { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int Miles { get; set; }

        public string Collor { get; set; }

        public int Prize { get; set; }

        public int LocationId { get; set; }

        public string LocationRegion { get; set; }

        public string LocationTown { get; set; }

        public string AddedByUserId { get; set; }

        public string AddedByUserEmail { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AddedByUserFirstName { get; set; }

        public string AddedByUserLastName { get; set; }

        public string FullName => this.AddedByUserFirstName + " " + this.AddedByUserLastName;

        public string AddedByUserPhoneNumber { get; set; }

        public string AditionalInformation { get; set; }

        public string SanitizedInfo => new HtmlSanitizer().Sanitize(this.AditionalInformation);

        public ICollection<string> ImageUrls { get; set; }
    }
}
