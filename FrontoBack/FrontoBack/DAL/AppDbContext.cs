using System;
using FrontoBack.Models;
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
		public AppDbContext(DbContextOptions options):base(options)
		{
		}
	}
}

