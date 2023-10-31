using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository
{
	public class VillaRepository : Repository<Villa>, IVillaRepository
	{
		private readonly VillaContext _context;

		public VillaRepository(VillaContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Villa> UpdateAsync(Villa entity)
		{
			entity.UpdatedDate = DateTime.Now;
			_context.Villas.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

	}
}
