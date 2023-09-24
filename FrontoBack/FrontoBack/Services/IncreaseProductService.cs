using System;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.Services.Interfaces;
using Newtonsoft.Json;

namespace FrontoBack.Services
{
	public class IncreaseProductService:IIncreaseProductService
	{
		private readonly AppDbContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public IncreaseProductService(AppDbContext context,IHttpContextAccessor httpContextAccessor)
		{
			_context = context;
			_httpContextAccessor = httpContextAccessor;
		}

        public void Increase(int id, string data)
        {
            List<ProductToBasket> productToBaskets = JsonConvert.DeserializeObject<List<ProductToBasket>>(data);
            productToBaskets.Find(p => p.Id == id).ProductCount++;
            _httpContextAccessor.HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(productToBaskets), new CookieOptions { MaxAge = TimeSpan.FromDays(1) });
        }
    }
}

