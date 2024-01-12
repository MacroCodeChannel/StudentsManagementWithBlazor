using StudentsManagement.Client.StudentRepository;
using StudentsManagement.Shared.Models;
using System.Net.Http.Json;

namespace StudentsManagement.Client.Services
{
    public class CountryService : ICountryRepository
    {

        private readonly HttpClient _httpClient;
        public CountryService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<Country> AddAsync(Country mod)
        {
            var data = await _httpClient.PostAsJsonAsync("api/Countries/Add-Country", mod);
            var response = await data.Content.ReadFromJsonAsync<Country>();
            return response;
        }

        public async Task<Country> DeleteAsync(int id)
        {
            var data = await _httpClient.DeleteAsync($"api/Countries/DeleteCountry/{id}");
            var response = await data.Content.ReadFromJsonAsync<Country>();
            return response;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            var data = await _httpClient.GetAsync("api/Countries/All-Countries");
            var response = await data.Content.ReadFromJsonAsync<List<Country>>();
            return response;
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            var data = await _httpClient.GetAsync($"api/Countries/Single-Country/{id}");
            var response = await data.Content.ReadFromJsonAsync<Country>();
            return response;
        }

        public async Task<Country> UpdateAsync(Country mod)
        {
            var data = await _httpClient.PostAsJsonAsync("api/Countries/UpdateCountry", mod);
            var response = await data.Content.ReadFromJsonAsync<Country>();
            return response;
        }
    }
}
