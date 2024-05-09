using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using back_end_c_sharp_test_with_friend_.Entities;

namespace back_end_c_sharp_test_with_friend_.Controllers;
[ApiController]
[Route("[controller]")]
public class CthdsController: ControllerBase
{
    private readonly DbAa8167Nguyenmanh1203Context _context;
        public CthdsController(DbAa8167Nguyenmanh1203Context ctx)
        {
            _context = ctx;
        }
        [HttpGet]   
        public IActionResult GetAll()
        {
            return Ok(_context.Cthds.ToList());
            //var nhacungcaps = _context.SanPhams.ToList();
            //return Ok(nhacungcaps);
        }
        [HttpPost] 
        public async Task<ActionResult<Cthd>> ThemMaHD(Cthd MaHD)
        {
            _context.Cthds.Add(MaHD);
            await _context.SaveChangesAsync();
            return Ok(_context.Cthds.ToList());
        }
}