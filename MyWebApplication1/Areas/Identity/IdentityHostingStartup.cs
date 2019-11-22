using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWebApplication1.Areas.Identity.Data;

[assembly: HostingStartup(typeof(MyWebApplication1.Areas.Identity.IdentityHostingStartup))]
namespace MyWebApplication1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<MyWebApplication1IdentityDbContext>(options =>
                    options.UseSqlite("Filename=movies_user.db"));
                services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<MyWebApplication1IdentityDbContext>()
                    .AddDefaultTokenProviders()
                    .AddDefaultUI();
//                services.AddDefaultIdentity<IdentityUser>()
//                    .AddEntityFrameworkStores<MyWebApplication1IdentityDbContext>();
            });
        }
    }
}