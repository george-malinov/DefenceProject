using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CarsPlatform.Web.Areas.Identity.IdentityHostingStartup))]

namespace CarsPlatform.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
