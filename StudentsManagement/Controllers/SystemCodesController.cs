using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemCodesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SystemCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SystemCodes
        [HttpGet("All-SystemCodes")]
        public async Task<ActionResult<IEnumerable<SystemCode>>> GetAllSystemCodes()
        {
            return await _context.SystemCodes.ToListAsync();
        }

        // GET: api/SystemCodes/5
        [HttpGet("Single-SystemCode/{id}")]
        public async Task<ActionResult<SystemCode>> GetSingleSystemCode(int id)
        {
            var systemCode = await _context.SystemCodes.FindAsync(id);

            if (systemCode == null)
            {
                return NotFound();
            }

            return systemCode;
        }

        // PUT: api/SystemCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update-SystemCode/{id}")]
        public async Task<IActionResult> UpdateSingleSystemCode(int id, SystemCode systemCode)
        {
            if (id != systemCode.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemCodeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SystemCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add-SystemCode")]
        public async Task<ActionResult<SystemCode>> AddNewSystemCode(SystemCode systemCode)
        {
            _context.SystemCodes.Add(systemCode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemCode", new { id = systemCode.Id }, systemCode);
        }

        // DELETE: api/SystemCodes/5
        [HttpDelete("Delete-SystemCode/{id}")]
        public async Task<IActionResult> DeleteSystemCode(int id)
        {
            var systemCode = await _context.SystemCodes.FindAsync(id);
            if (systemCode == null)
            {
                return NotFound();
            }

            _context.SystemCodes.Remove(systemCode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemCodeExists(int id)
        {
            return _context.SystemCodes.Any(e => e.Id == id);
        }
    }
}
