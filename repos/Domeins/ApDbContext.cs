using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using repos.Domeins.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;




namespace repos.Domeins
{
    public class ApDbContext:IdentityDbContext<IdentityUser>
    {
        public ApDbContext(DbContextOptions<ApDbContext> options) : base(options) { }
        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id= "CCEE197B-3B9D-4FB3-80B9-4FE93657B753",
                Name="admin",
                NormalizedName="ADMIN"
            });
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id= "01579C9D-AD25-4F6F-A255-D296BAB6209A",
                UserName="admin",
                NormalizedUserName="ADMIN",
                Email="274@mail.ru",
                NormalizedEmail="274@MAIL.RU",
                EmailConfirmed=true,
                PasswordHash=new PasswordHasher<IdentityUser>().HashPassword(null,"superpassword"),
                SecurityStamp=string.Empty
                
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            { RoleId = "CCEE197B-3B9D-4FB3-80B9-4FE93657B753",
                UserId = "01579C9D-AD25-4F6F-A255-D296BAB6209A",
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id=new Guid("8270BB7B-3F94-4ACE-BEE9-96F690688834"),
                CodeWord="PageIndex",
                Title="Главная"

            });
            modelBuilder.Entity<ServiceItem>().HasData(new ServiceItem
            {
                Id = new Guid("08C8E5CB-DB4B-4B05-A562-ED66FFBD451B"),
                CodeWord = "PageServises",
                Title = "Наши услуги"

            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("600542F7-2DE7-4C5B-95F5-38F767C29C84"),
                CodeWord = "PageContacts",
                Title = "Контакты"

            });
        }

    }
}
