using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyWebApplication1.Areas.Identity.Data
{
    public class MyWebApplication1IdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public MyWebApplication1IdentityDbContext(DbContextOptions<MyWebApplication1IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>().HasData(new IdentityUser()
                {UserName = "admin", PasswordHash = "anvarhash", Id = "1"});
            builder.Entity<IdentityRole>().HasData(new IdentityRole() {Name = "ADMIN"}, new IdentityRole() {Name = "USER"});
        }
    }
}
