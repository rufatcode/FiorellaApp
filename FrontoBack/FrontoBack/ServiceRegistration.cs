using System;
using FrontoBack.DAL;
using FrontoBack.Services;
using Microsoft.EntityFrameworkCore;

namespace FrontoBack
{
	public static class ServiceRegistration
	{
		public static void Registration(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddControllersWithViews();
//.AddNewtonsoftJson(options =>
//options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
//);

            services.AddDbContext<AppDbContext>(option =>
			{
				option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
				//service.UseSqlServer(configuration["ConnectionString:DefaultConnection"]);
			});
			services.AddSession(option =>
			{
				option.IdleTimeout = TimeSpan.FromMinutes(10);
			});
			services.AddHttpContextAccessor();
			services.AddScoped<IBasketServices, BasketServices>();
			//services.AddSingleton<IAddProductService, AddProductService>();
			//services.AddTransient<IAddProductService, AddProductService>();
		}
	}
}

