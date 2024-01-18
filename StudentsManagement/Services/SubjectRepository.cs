using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Services
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Subject> AddAsync(Subject mod)
        {
            mod.CreatedById = "Macro Code";
            mod.CreatedOn = DateTime.Now;
            if (mod == null) return null;

            var data = _context.Subjects.Add(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<Subject> DeleteAsync(int id)
        {
            var data = await _context.Subjects.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            _context.Subjects.Remove(data);
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<List<Subject>> GetAllAsync()
        {
            var data = await _context.Subjects
                .ToListAsync();

            return data;
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            var data = await _context.Subjects.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            return data;
        }

        public async Task<Subject> UpdateAsync(Subject mod)
        {
            if (mod == null) return null;

            var data = _context.Subjects.Update(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }
    }
}
