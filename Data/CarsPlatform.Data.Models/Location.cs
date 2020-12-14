namespace CarsPlatform.Data.Models
{
    using System.Collections.Generic;

    using CarsPlatform.Data.Common.Models;

    public class Location : BaseModel<int>
    {
        public Location()
        {
            this.Cars = new HashSet<Car>();
        }

        public string Region { get; set; }

        public string Town { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
