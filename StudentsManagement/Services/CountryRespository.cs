using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Services
{
    public class CountryRespository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRespository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Country> AddAsync(Country mod)
        {
            if (mod == null) return null;

            var newcountry = _context.Countries.Add(mod).Entity;
            await _context.SaveChangesAsync();

            return newcountry;
        }

        public async Task<Country> DeleteAsync(int id)
        {
            var country = await _context.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (country == null) return null;

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return country;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            var countries = await _context.Countries.ToListAsync();

            return countries;
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            var singlecountry = await _context.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (singlecountry == null) return null;

            return singlecountry;
        }

        public async Task<Country> UpdateAsync(Country mod)
        {
            if (mod == null) return null;

            var updatedcountry = _context.Countries.Update(mod).Entity;
            await _context.SaveChangesAsync();

            return updatedcountry;
        }
    }
}
