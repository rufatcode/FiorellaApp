using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.Core.Models;
using FrontoBack.DAL;
using Microsoft.EntityFrameworkCore;

namespace FrontoBack.Data.Implimentations
{
	public class Repozitory<T>:IRepozitory<T> where T:class,IBaseEntity
	{
        private readonly AppDbContext _context;
        public Repozitory()
        {

        }
		public Repozitory(AppDbContext context)
		{
            _context = context;
		}

        public async Task<bool> Create(T entity)
        {
            
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool>  Delete(int id)
        {
            try
            {
                T entity =await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                _context.Set<T>().Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<T> > GetAll()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Update(int id, T entity)
        {
            try
            {
                T existEntity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                existEntity = entity;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

