using System;
using System.Linq.Expressions;

namespace FrontoBack.Core.Interfaces
{
	public interface IRepozitory<T>
	{
		public Task Create(T entity);
		public Task Delete(T entity);
		public Task Update(T entity);
		public Task<T> GetById(Expression<Func<T, bool>> ?predicate=null, params string[] includes);
		public Task<List<T>> GetAll(Expression<Func<T,bool>>? predicate=null,params string[] includes);
		public Task Commit();
		public Task<bool> EntityIsExist(Expression<Func<T, bool>> predicate);

    }
}

