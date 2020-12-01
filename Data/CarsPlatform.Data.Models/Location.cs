namespace CarsPlatform.Data.Models
{
    using System.Collections.Generic;

    public class Location
    {
        public Location()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        public string Region { get; set; }

        public string Town { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
