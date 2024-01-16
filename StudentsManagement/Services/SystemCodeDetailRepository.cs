using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Services
{
    public class SystemCodeDetailRepository : ISystemCodeDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public SystemCodeDetailRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<SystemCodeDetail> AddAsync(SystemCodeDetail mod)
        {
            if (mod == null) return null;

            var data = _context.SystemCodeDetails.Add(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }


        public async Task<SystemCodeDetail> DeleteAsync(int id)
        {
            var data = await _context.SystemCodeDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            _context.SystemCodeDetails.Remove(data);
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<List<SystemCodeDetail>> GetAllAsync()
        {
            var data = await _context.SystemCodeDetails
                .Include(x=>x.SystemCode)
                .ToListAsync();

            return data;
        }

        public async Task<SystemCodeDetail> GetByIdAsync(int id)
        {
            var data = await _context.SystemCodeDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            return data;
        }

        public async Task<List<SystemCodeDetail>> GetByCodeAsync(string code)
        {
            var data = await _context.SystemCodeDetails.Include(x=>x.SystemCode).Where(x => x.SystemCode.Code == code).ToListAsync();
            if (data == null) return null;

            return data;
        }

        public async Task<SystemCodeDetail> UpdateAsync(SystemCodeDetail mod)
        {
            if (mod == null) return null;

            var data = _context.SystemCodeDetails.Update(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }


    }
}
