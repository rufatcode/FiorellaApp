using System;
using FrontoBack.DAL;
using Microsoft.EntityFrameworkCore;

namespace FrontoBack
{
	public static class ServiceRegistration
	{
		public static void Registration(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddControllersWithViews();
			services.AddDbContext<AppDbContext>(option =>
			{
				option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
				//service.UseSqlServer(configuration["ConnectionString:DefaultConnection"]);
			});
		}
	}
}

