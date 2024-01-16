using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Services
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Teacher> AddAsync(Teacher mod)
        {
            if (mod == null) return null;

            var data = _context.Teachers.Add(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<Teacher> DeleteAsync(int id)
        {
            var data = await _context.Teachers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            _context.Teachers.Remove(data);
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            var data = await _context.Teachers
                .Include(x => x.Designation)
                .Include(x => x.Gender)
                .ToListAsync();

            return data;
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            var data = await _context.Teachers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            return data;
        }

        public async Task<Teacher> UpdateAsync(Teacher mod)
        {
            if (mod == null) return null;

            var data = _context.Teachers.Update(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }
    }
}
