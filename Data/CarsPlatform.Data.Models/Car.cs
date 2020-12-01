namespace CarsPlatform.Data.Models
{
    using System.Collections.Generic;

    using CarsPlatform.Data.Common.Models;
    using CarsPlatform.Data.Models.Enums;

    public class Car : BaseDeletableModel<int>
    {
        public Car()
        {
            this.Images = new HashSet<Image>();
        }

        public string Model { get; set; }

        public int Prize { get; set; }

        public EngineType EngineType { get; set; }

        public int Power { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int Miles { get; set; }

        public string Collor { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
