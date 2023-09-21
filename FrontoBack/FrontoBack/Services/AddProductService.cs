using System;
using FrontoBack.Models;
using FrontoBack.Services.Interfaces;
using Newtonsoft.Json;

namespace FrontoBack.Services
{
	public class AddProductService:IAddProductService
	{
        private readonly IHttpContextAccessor _httpContextAccessor;
		public AddProductService(IHttpContextAccessor httpContextAccessor)
		{
            _httpContextAccessor = httpContextAccessor;
		}

        public void Add(int id)
        {
            List<ProductToBasket> products = new();
            string data = _httpContextAccessor.HttpContext.Request.Cookies["Basket"];
            if (data == null)
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(1) });
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<ProductToBasket>>(data);
            }
            if (products.Find(p => p.Id == id) != null)
            {
                products.Find(p => p.Id == id).ProductCount++;
            }
            else
            {
                products.Add(new() { Id = id, ProductCount = 1 });
            }

            _httpContextAccessor.HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(products));
        }
    }
}

