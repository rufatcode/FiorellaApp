using System;
using FrontoBack.Core.Models;
using FrontoBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FrontoBack.DAL
{
	public class AppDbContext:IdentityDbContext<AppUser>
	{
		public DbSet<Slider> Sliders { get; set; }
		public DbSet<SliderContent> SliderContents { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Catagorie> Catagories { get; set; }
		public DbSet<FlowerExpert> FlowerExperts { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Accordion> Accordions { get; set; }
		public DbSet<NavBar> NavBars { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Ganre> Ganres { get; set; }
		public DbSet<BookImages> BookImages { get; set; }
		public DbSet<BookAuthor> BookAuthors { get; set; }
		public DbSet<BookGanre> BookGanres { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Street> Streets { get; set; }
		public DbSet<Check> Checks { get; set; }
		public DbSet<CheckProduct> CheckProducts { get; set; }
		public AppDbContext(DbContextOptions options):base(options)
		{
		}
        protected override void OnModelCreating(ModelBuilder builder)
        {
			string AdminId = Guid.NewGuid().ToString();
			string AdminRoleId = Guid.NewGuid().ToString();
			string SupperAdminId = Guid.NewGuid().ToString();
			string SupperAdminRoleId = Guid.NewGuid().ToString();
			string UserRoleId = Guid.NewGuid().ToString();
			builder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Name = "Admin",
				NormalizedName = "ADMIN",
				Id = AdminRoleId,
				ConcurrencyStamp = AdminRoleId
            });
			builder.Entity<IdentityRole>().HasData(new IdentityRole {
				Name="SupperAdmin",
				NormalizedName="SUPPERADMIN",
				Id=SupperAdminRoleId,
				ConcurrencyStamp=SupperAdminRoleId
			});
			builder.Entity<IdentityRole>().HasData(new IdentityRole {
				Name="User",
				NormalizedName="USER",
				Id=UserRoleId,
				ConcurrencyStamp=UserRoleId
			});
            var Admin = new AppUser
			{
				Id = AdminId,
				Email = "rufatri@code.edu.az",
				UserName = "Rufat123",
				FullName = "RufatCode",
				NormalizedUserName = "RUFAT123",
				NormalizedEmail="RUFATRI@CODE.EDU.AZ",
				EmailConfirmed = true

			};

			PasswordHasher<AppUser> passwordHash = new PasswordHasher<AppUser>();
			Admin.PasswordHash = passwordHash.HashPassword(Admin, "Rufat123123");
			builder.Entity<AppUser>().HasData(Admin);

			var SuperAdmin = new AppUser
			{
				Id=SupperAdminId,
				UserName="Rufat8899",
				FullName="RufatConputerScience",
				Email="rft.smayilov@mail.ru",
				NormalizedEmail="RFT.SMAYILOV@MAIL.RU",
				NormalizedUserName="RUFAT8899",
			};

			SuperAdmin.PasswordHash = passwordHash.HashPassword(SuperAdmin, "Rufat123123");
			builder.Entity<AppUser>().HasData(SuperAdmin);
			builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId=AdminId,RoleId= AdminRoleId });
			builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId= SupperAdminId, RoleId=SupperAdminRoleId});
			
            base.OnModelCreating(builder);	
        }
    }
}

