
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using quan_ly_ban_hang.Entities;
namespace back_end_c_sharp_test_with_friend_.Controllers
{
    
     [ApiController]
     [Route("[controller]")]
    public class hanghoaController : Controller
    {
        private readonly DbAa8167Nguyenmanh1203Context _context;
        public hanghoaController(DbAa8167Nguyenmanh1203Context ctx)
        {
            _context = ctx;
        }
        [HttpGet]
        [Route("Trả về thông tin tất cả Hàng hoá")]
        public IActionResult GetAll()
        {
            return Ok(_context.TblHangs.ToList());
        }
        [HttpGet]
        [Route("Tìm kiếm hàng hoá theo tên chất liệu")]
        public async Task<ActionResult<IEnumerable<TblHang>>> GetHANGHOA(string tenChatLieu)
        {
            var hang = await _context.TblHangs.Where(h => h.TenChatLieu == tenChatLieu).ToListAsync();
            if (hang == null || hang.Count == 0)
            {
                return NotFound();
            }
            return hang;
        }
        [HttpPost]
        [Route("Thêm Hàng hoá")]
        public async Task<ActionResult<TblHang>> PostSanPham(TblHang add)
        {
            _context.TblHangs.Add(add);
            await _context.SaveChangesAsync();
            return Ok(_context.TblHangs.ToList());
        }
        [HttpDelete]
        [Route("Xoá Hàng hoá theo số Lượng")]
        public async Task<IActionResult> DeleteHang(int soLuong)
        {
            var hanghoaList = await _context.TblHangs.Where(hh => hh.SoLuong == soLuong).ToListAsync();

            if (hanghoaList == null || hanghoaList.Count == 0)
            {
                return NotFound();
            }

            _context.TblHangs.RemoveRange(hanghoaList);
            await _context.SaveChangesAsync();

            return Ok();
       
        }

        [HttpPut()]
        [Route("Cập nhật thông tin hàng hoá")]
        public async Task<IActionResult> UpdateKhachhang(string Mahang, TblHang hanghoa)
        {

            if (Mahang != hanghoa.MaHang)
            {
                return BadRequest();
            }

            _context.Entry(hanghoa).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!makhachhangExists(Mahang))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        private bool makhachhangExists(string Mahang)
        {
            return _context.TblKhaches.Any(e => e.MaKhach == Mahang);
        }
    }
}

