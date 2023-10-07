using System;
namespace FrontoBack.Core.Interfaces
{
	public interface IRepozitory<T>
	{
		public Task<bool> Create(T entity);
		public bool Delete(int id);
		public Task<bool> Update(int id,T entity);
		public Task<T> GetById(int id);
		public Task<List<T>> GetAll();
	}
}

