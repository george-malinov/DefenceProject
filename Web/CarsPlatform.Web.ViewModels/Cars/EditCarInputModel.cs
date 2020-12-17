namespace CarsPlatform.Web.ViewModels.Cars
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CarsPlatform.Data.Models;
    using CarsPlatform.Data.Models.Enums;
    using CarsPlatform.Services.Mapping;

    public class EditCarInputModel : IMapFrom<Car>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Model { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Manufacture")]
        public DateTime DateOfManufacture { get; set; }

        [Range(300, 1000000)]
        public int Prize { get; set; }

        [Range(40, 1500)]
        [Display(Name ="Horse power of the car")]
        public int Power { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public int Miles { get; set; }

        [Required]
        [MinLength(3)]
        public string Collor { get; set; }

        [Required]
        [Display(Name = "Aditional information about car")]
        [MaxLength(300)]
        public string AditionalInformation { get; set; }

        public int LocationId { get; set; }

        [Display(Name = "Region")]
        public string LocationRegion { get; set; }

        [Display(Name = "Town")]
        public string LocationTown { get; set; }

        [Display(Name = "Engine Type")]
        public EngineType EngineTypes { get; set; }

        [Display(Name = "Transmission Type")]
        public TransmissionType TransmissionTypes { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }
    }
}
