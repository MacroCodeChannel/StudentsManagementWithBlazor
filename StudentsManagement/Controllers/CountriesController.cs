using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.StudentRepository;
using StudentsManagement.Data;
using StudentsManagement.Services;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        public CountriesController(ICountryRepository countryRepository)
        {
            this._countryRepository = countryRepository;
        }

        // GET: api/Countries
        [HttpGet("All-Countries")]
        public async Task<ActionResult<List<Country>>> GetAllCountries()
        {
            var countries = await _countryRepository.GetAllAsync();

            return Ok(countries);
        }

        // GET: api/Countries/5
        [HttpGet("Single-Country/{id}")]
        public async Task<ActionResult<Country>> GetSingleCountry(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        [HttpPost("Add-Country")]
        public async Task<ActionResult<Student>> AddAsync(Country mod)
        {
            var newcountry = await _countryRepository.AddAsync(mod);

            return Ok(newcountry);
        }


        [HttpDelete("DeleteCountry/{id}")]
        public async Task<ActionResult<Country>> DeleteAsync(int id)
        {
            var deletecountry = await _countryRepository.DeleteAsync(id);

            return Ok(deletecountry);
        }


        [HttpPost("Update-Country")]
        public async Task<ActionResult<Country>> UpdateAsync(Country country)
        {
            var updateCountry = await _countryRepository.UpdateAsync(country);

            return Ok(updateCountry);
        }
    }
}
