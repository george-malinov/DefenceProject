namespace CarsPlatform.Web.ViewModels.Cars
{
    using System.Collections.Generic;

    public class MyCarsViewModel : PagingViewModel
    {
        public IEnumerable<MyCarsInListViewModel> Cars { get; set; }
    }
}
