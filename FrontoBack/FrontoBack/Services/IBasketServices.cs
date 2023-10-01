using System;
using FrontoBack.ViewModel;

namespace FrontoBack.Services
{
	public interface IBasketServices
	{
        void Add(int id);
        void Decrease(int id, string data);
        void Increase(int id, string data);
        void Remove(int id, string data);
        List<BasketVM> Show();
    }
}

