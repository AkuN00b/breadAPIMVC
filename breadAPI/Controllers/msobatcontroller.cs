using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using breadAPI.Data;
using breadAPI.Models;

namespace breadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class msobatcontroller : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public msobatcontroller(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<msobat>>> GetObat()
        {
            IEnumerable<msobat> msobats = await _db.msobat.ToListAsync();
            return Ok(msobats);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<msobat>> CreateObat(msobat msobats)
        {
            _db.msobat.Add(msobats);
            await _db.SaveChangesAsync();
            return Ok(msobats);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateObat(int id, msobat msobats)
        {
            if (id != msobats.oba_id)
            {
                return BadRequest();
            }

            _db.Entry(msobats).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObatExists(id))
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

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<msobat>> DeleteObat(int id)
        {
            var msobats = await _db.msobat.FindAsync(id);
            if (msobats == null)
            {
                return NotFound();
            }

            _db.msobat.Remove(msobats);
            await _db.SaveChangesAsync();

            return msobats;
        }

        private bool ObatExists(int id)
        {
            return _db.msobat.Any(e => e.oba_id == id);
        }
    }
}
