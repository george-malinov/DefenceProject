namespace CarsPlatform.Services.Data
{
    using System.Collections.Generic;

    public interface ICarsService
    {
        IEnumerable<T> All<T>(int page, int itemsPerPage = 10);

        int GetCount();

    }
}
