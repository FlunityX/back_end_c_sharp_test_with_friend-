using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using back_end_c_sharp_test_with_friend_.Entities;

namespace back_end_c_sharp_test_with_friend_.Controllers;
[ApiController]
[Route("[controller]")]
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
            //var nhacungcaps = _context.SanPhams.ToList();
            //return Ok(nhacungcaps);
        }
        [HttpGet("{MaSP}")]
        public async Task<ActionResult<SanPham>> GetSPbyMaSP(string MaSP)
        {
             var sp = await _context.SanPhams.FindAsync(MaSP);
            if (sp== null)
            {
                return NotFound();
            }
            return sp;
        }
        

        
}