namespace CarsPlatform.Data.Models
{
    using System;

    using CarsPlatform.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public string Extention { get; set; }

        public string RemoteImageUrl { get; set; }

        public string AddedbyUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
