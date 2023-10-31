using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly VillaContext _context;
		internal DbSet<T> dbSet;

		public Repository(VillaContext context)
		{
			_context = context;
			dbSet = _context.Set<T>();
		}

		public async Task AddAsync(T entity)
		{
			await dbSet.AddAsync(entity);
			await SaveAsync();
		}

		public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
		{
			IQueryable<T> query = dbSet;
			if (filter != null)
			{
				query = query.Where(filter);
			}
			return await query.ToListAsync();
		}

		public async Task<T> GetOneAsync(Expression<Func<T, bool>> filter = null, bool tracking = true)
		{
			IQueryable<T> query = dbSet;
			if (tracking == false)
			{
				query = query.AsNoTracking();
			}
			if (filter != null)
			{
				query = query.Where(filter);
			}
			return await query.FirstOrDefaultAsync();
		}

		public async Task RemoveAsync(T entity)
		{
			dbSet.Remove(entity);
			await SaveAsync();
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
