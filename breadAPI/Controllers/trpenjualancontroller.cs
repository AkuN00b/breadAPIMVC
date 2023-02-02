using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using breadAPI.Data;
using breadAPI.Models;

namespace breadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class trpenjualancontroller : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public trpenjualancontroller(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<trpenjualan>>> GetTransaksi()
        {
            IEnumerable<trpenjualan> trpenjualans = await _db.trpenjualan.ToListAsync();
            return Ok(trpenjualans);
        }


        //[HttpPost("Create/")]
        //public async Task<ActionResult<trpenjualan>> CreateTransaksi(trpenjualan trpenjualans)
        //{
        //    _db.trpenjualan.Add(trpenjualans);
        //    await _db.SaveChangesAsync();
              
        //    for (int i = 0; i < trpenjualans.msobats.Count; i++)
        //    {
        //        var obat = _db.msobat.Find(trpenjualans.msobats[i].oba_id);
        //        if (obat.oba_quantity >= trpenjualans.msobats[i].oba_quantity)
        //        {
        //            obat.oba_quantity = obat.oba_quantity - trpenjualans.msobats[i].oba_quantity;
        //            _db.Entry(obat).State = EntityState.Modified;
        //            _db.SaveChanges();
        //        }
        //    }
            
        //    return Ok(trpenjualans);
        //}
    }
}
