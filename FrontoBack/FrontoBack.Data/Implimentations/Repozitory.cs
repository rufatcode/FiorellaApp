using System;
using System.Linq;
using System.Linq.Expressions;
using FrontoBack.Core.Interfaces;
using FrontoBack.Core.Models;
using FrontoBack.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FrontoBack.Data.Implimentations
{
	public class Repozitory<T>:IRepozitory<T> where T:class,IBaseEntity
	{
        private readonly AppDbContext _context;
        private readonly DbSet<T> Table;

        public Repozitory(AppDbContext context)
		{
            _context = context;
            Table = _context.Set<T>();

        }

        public async Task Create(T entity)
        {
            //_context.Set<T>().Add(entity);
            var resoult = _context.Entry(entity);
            resoult.State = EntityState.Added;
            
        }

        public async Task Delete(T entity)
        {
            var resoult = _context.Entry(entity);
            resoult.State = EntityState.Deleted;
            
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> ?predicate=null, params string[] includes)
        {
            IQueryable<T> query = GetAllInclude(includes);
            return predicate != null ? await query.Where(predicate).ToListAsync() :await query.ToListAsync();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> ?predicate=null, params string[] includes)
        {
            IQueryable<T> query = GetAllInclude(includes);
            return predicate != null ?await query.FirstOrDefaultAsync(predicate) :await query.FirstOrDefaultAsync();
        }

        public async Task Update(T entity)
        {
            var resoult = _context.Entry(entity);
            resoult.State = EntityState.Modified;
        }
        public async Task<bool> EntityIsExist(Expression<Func<T, bool>> ?predicate)
        {
            return predicate!=null? await Table.AnyAsync(predicate):false;
        }
        public async Task Commit()
        {
           await  _context.SaveChangesAsync();
        }
        public IQueryable<T> GetAllInclude(params string[] includes)
        {
            IQueryable<T> query = Table;
            foreach (var include in includes)
            {
               query= query.Include(include);
            }
            return query;
         }
    }
}

