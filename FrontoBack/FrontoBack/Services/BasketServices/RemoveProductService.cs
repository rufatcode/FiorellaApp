using System;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.Services.Interfaces;
using Newtonsoft.Json;

namespace FrontoBack.Services
{
	public class RemoveProductService:IRemoveProductService
	{
		private readonly IHttpContextAccessor _httpContext;
		private readonly AppDbContext _context;
		public RemoveProductService(IHttpContextAccessor httpContextAccessor,AppDbContext context)
		{
			_httpContext = httpContextAccessor;
			_context = context;
		}

        public void Remove(int id, string data)
        {
            List<ProductToBasket> products = JsonConvert.DeserializeObject<List<ProductToBasket>>(data);
            products.Remove(products.Find(p => p.Id == id));
            _httpContext.HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(1) });
        }
    }
}

