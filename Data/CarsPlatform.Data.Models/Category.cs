namespace CarsPlatform.Data.Models
{
    using System.Collections.Generic;

    using CarsPlatform.Data.Common.Models;

    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.Cars = new HashSet<Car>();
        }

        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
