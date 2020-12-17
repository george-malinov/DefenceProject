namespace CarsPlatform.Web.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;

    public class CarLocationViewModel
    {
        [Required]
        public string Region { get; set; }

        [Required]
        public string Town { get; set; }
    }
}
