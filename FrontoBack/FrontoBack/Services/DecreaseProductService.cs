using System;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.Services.Interfaces;
using Newtonsoft.Json;

namespace FrontoBack.Services
{
	public class DecreaseProductService:IDecreaseProductService
	{
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _context;
        private readonly IRemoveProductService _removeProductService;
		public DecreaseProductService(IHttpContextAccessor httpContextAccessor,AppDbContext context,IRemoveProductService removeProductService)
		{
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _removeProductService = removeProductService;
		}

        public void Decrease(int id, string data)
        {
            List<ProductToBasket> productToBaskets = JsonConvert.DeserializeObject<List<ProductToBasket>>(data);
            if (productToBaskets.Find(p => p.Id == id).ProductCount == 1)
            {
                _removeProductService.Remove(id, data);

            }
            else
            {
                productToBaskets.Find(p => p.Id == id).ProductCount--;
                _httpContextAccessor.HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(productToBaskets), new CookieOptions { MaxAge = TimeSpan.FromDays(1) });

            }
        }
    }
}

