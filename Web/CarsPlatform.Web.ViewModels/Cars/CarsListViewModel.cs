namespace CarsPlatform.Web.ViewModels.Cars
{
    using System.Collections.Generic;

    public class CarsListViewModel : PagingViewModel
    {
        public IEnumerable<CarsInListViewModel> Cars { get; set; }

        public string SearchString { get; set; }
    }
}
