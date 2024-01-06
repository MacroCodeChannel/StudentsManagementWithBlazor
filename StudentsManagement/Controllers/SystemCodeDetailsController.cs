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
    public class SystemCodeDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SystemCodeDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SystemCodeDetails
        [HttpGet("All-SystemCodeDetails")]
        public async Task<ActionResult<IEnumerable<SystemCodeDetail>>> GetAllSystemCodeDetails()
        {
            return await _context.SystemCodeDetails.ToListAsync();
        }

        // GET: api/SystemCodeDetails/5
        [HttpGet("Single-SystemCodeDetail/{id}")]
        public async Task<ActionResult<SystemCodeDetail>> GetSingleSystemCodeDetail(int id)
        {
            var systemCodeDetail = await _context.SystemCodeDetails.FindAsync(id);

            if (systemCodeDetail == null)
            {
                return NotFound();
            }

            return systemCodeDetail;
        }

        // PUT: api/SystemCodeDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update-SystemCodeDetail/{id}")]
        public async Task<IActionResult> UpdateSystemCodeDetail(int id, SystemCodeDetail systemCodeDetail)
        {
            if (id != systemCodeDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemCodeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemCodeDetailExists(id))
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

        // POST: api/SystemCodeDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add-SystemCodeDetail")]
        public async Task<ActionResult<SystemCodeDetail>> AddNewSystemCodeDetail(SystemCodeDetail systemCodeDetail)
        {
            _context.SystemCodeDetails.Add(systemCodeDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemCodeDetail", new { id = systemCodeDetail.Id }, systemCodeDetail);
        }

        // DELETE: api/SystemCodeDetails/5
        [HttpDelete("Delete-SystemCodedetail/{id}")]
        public async Task<IActionResult> DeleteSystemCodeDetail(int id)
        {
            var systemCodeDetail = await _context.SystemCodeDetails.FindAsync(id);
            if (systemCodeDetail == null)
            {
                return NotFound();
            }

            _context.SystemCodeDetails.Remove(systemCodeDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemCodeDetailExists(int id)
        {
            return _context.SystemCodeDetails.Any(e => e.Id == id);
        }
    }
}
