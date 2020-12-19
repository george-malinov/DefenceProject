namespace CarsPlatform.Web.ViewModels.Cars
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CarsPlatform.Data.Models.Enums;
    using Ganss.XSS;
    using Microsoft.AspNetCore.Http;

    public class CreateCarInputModel
    {
        [Required]
        [MinLength(3)]
        public string Model { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Manufacture")]
        public DateTime DateOfManufacture { get; set; }

        [Range(300, 1000000)]
        public int Prize { get; set; }

        [Range(40, 1500)]
        [Display(Name = "Horse power of the car")]
        public int Power { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Range(0, 500000)]
        public int Miles { get; set; }

        [Required]
        [MinLength(3)]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Aditional information about car")]
        [MaxLength(300)]
        public string AditionalInformation { get; set; }

        public CarLocationViewModel Location { get; set; }

        [Display(Name = "Engine Type")]
        public EngineType EngineTypes { get; set; }

        [Display(Name = "Transmission Type")]
        public TransmissionType TransmissionTypes { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}
