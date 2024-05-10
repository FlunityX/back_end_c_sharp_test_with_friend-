using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using back_end_c_sharp_test_with_friend_.Entities;

namespace back_end_c_sharp_test_with_friend_.Controllers;
[ApiController]
[Route("[Controller]")]
public class SanPhamController: ControllerBase
{
    private readonly DbAa8167Nguyenmanh1203Context _context;
        public SanPhamController(DbAa8167Nguyenmanh1203Context ctx)
        {
            _context = ctx;
        }
        
        [HttpGet]   
        public IActionResult GetAll()
        {
            return Ok(_context.SanPhams.ToList());
        }

        [HttpGet]
        [Route("SearchSanPham")]
        public async Task<ActionResult<SanPham>> GetSPbyMaSP(string MaSP)
        {
             var sp = await _context.SanPhams.FindAsync(MaSP);
            if (sp== null)
            {
                return NotFound();
            }
            return sp;
        }

        [HttpPost]
        public async Task<ActionResult<SanPham>> PostSanPham(SanPham sp)
        {
            _context.SanPhams.Add(sp);
            await _context.SaveChangesAsync();
            return Ok(_context.SanPhams.ToList());
        }

        [HttpDelete]
        [Route("DeleteSanPham")]
        public async Task<IActionResult> DeleteSanPham(string MaSP)
        {
            var sp = await _context.SanPhams.FindAsync(MaSP);

            if (sp == null)
            {
                return NotFound();
            }
            _context.SanPhams.Remove(sp);
            await _context.SaveChangesAsync();
            return NoContent(); 
        }

        [HttpPut]
        [Route("UpdateSanPham")]
        public async Task<IActionResult> UpdateSanPham(string MaSP, SanPham sp)
        {
            if (MaSP!= sp.MaSp)
            {
                return BadRequest();
            }
            _context.Entry(sp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamExists(MaSP))
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

    private bool SanPhamExists(string MaSP)
    {
        return _context.SanPhams.Any(e => e.MaSp == MaSP);
    }
    
}

