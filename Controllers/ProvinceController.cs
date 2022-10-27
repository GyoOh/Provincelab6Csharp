using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using provinceCity.Data;
using provinceCity.Models;

namespace provinceCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("provinceCity")]
    public class ProvinceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProvinceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Province
        [HttpGet("GetProvinces")]
        public async Task<ActionResult<IEnumerable<Province>>> GetProvinces()
        {
            //.Include(a => a.ProvinceCod)
            return await _context.Provinces.ToListAsync();
        }

        // GET: api/Province/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Province>> GetProvince(string id)
        {

            var province = await _context.Provinces.FindAsync(id);



            return province;
        }

        // PUT: api/Province/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvince(string id, Province province)
        {
            if (id != province.ProvinceCode)
            {
                return BadRequest();
            }

            _context.Entry(province).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinceExists(id))
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

        // POST: api/Province
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Province>> PostProvince(Province province)
        {
            if (_context.Provinces == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Provinces'  is null.");
            }
            _context.Provinces.Add(province);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProvinceExists(province.ProvinceCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProvince", new { id = province.ProvinceCode }, province);
        }

        // DELETE: api/Province/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvince(string id)
        {
            if (_context.Provinces == null)
            {
                return NotFound();
            }
            var province = await _context.Provinces.FindAsync(id);
            if (province == null)
            {
                return NotFound();
            }

            _context.Provinces.Remove(province);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProvinceExists(string id)
        {
            return (_context.Provinces?.Any(e => e.ProvinceCode == id)).GetValueOrDefault();
        }
    }
}
