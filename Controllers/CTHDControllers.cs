using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using back_end_c_sharp_test_with_friend_.Entities;

namespace back_end_c_sharp_test_with_friend_.Controllers;
[ApiController]
[Route("[Controller]")]
public class CTHDController : ControllerBase
{   
    private readonly DbAa8167Nguyenmanh1203Context _context;

    public CTHDController(DbAa8167Nguyenmanh1203Context context)
    {
        _context = context;
    }
    [HttpGet]
        public IActionResult GetCTHDs()
        {
            var cthds = _context.Cthds.ToList();
            return Ok(cthds);
        }
    [HttpGet("{SoHD}")]
    public async Task<ActionResult<Cthd>> GetCTHD(int SoHD)
    {
        var cthd = await _context.Cthds.FindAsync(SoHD);

        if (cthd == null)
        {
            return NotFound();
        }

        return cthd;
    }

} 