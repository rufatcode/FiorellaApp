using System;
using FrontoBack.Business.Interfaces;
using FrontoBack.Business.Services;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Data.Implimentations;
using FrontoBack.Models;
using FrontoBack.Services;
using Microsoft.AspNetCore.Identity;
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
				option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
					opt =>
					
						opt.MigrationsAssembly("FrontoBack.Data")
					) ;
				//service.UseSqlServer(configuration["ConnectionString:DefaultConnection"]);
			});
			services.AddSession(option =>
			{
				option.IdleTimeout = TimeSpan.FromMinutes(10);
			});
			services.AddHttpContextAccessor();
			services.AddScoped<IBasketServices, BasketServices>();
			services.AddScoped<IStreetService, StreetService>();
			services.AddScoped<IStreetRepozitory, StreetRepozitory>();
			//services.AddSingleton<IAddProductService, AddProductService>();
			//services.AddTransient<IAddProductService, AddProductService>();
			services.AddIdentity<AppUser, IdentityRole>(option =>
			{
				option.Password.RequireDigit = true;
				option.Password.RequiredLength = 8;
				option.Password.RequireLowercase = true;
				option.Password.RequireUppercase = true;
				option.Password.RequireNonAlphanumeric = true;
				option.User.RequireUniqueEmail = true;
				option.Lockout.AllowedForNewUsers = true;
				option.Lockout.MaxFailedAccessAttempts = 5;
				option.SignIn.RequireConfirmedAccount = true;

			}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
			services.Configure<DataProtectionTokenProviderOptions>(option =>
			{
				option.TokenLifespan = TimeSpan.FromMinutes(10);
				
			});
		}
	}
}

