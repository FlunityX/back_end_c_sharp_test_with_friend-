
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using quan_ly_ban_hang.Entities;
namespace quan_ly_ban_hang.Controllers
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
                return NotFound("ko tồn tại tên chất liệu có trong csdl");
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
            var soluonglist = await _context.TblHangs.Where(hh => hh.SoLuong == soLuong).ToListAsync();

            if (soluonglist == null || soluonglist.Count == 0)
            {
                return NotFound("Xoá thất bại có thể do ko tồn tại hàng nào có số lượng như vậy vui lòng nhập lại");
            }

            _context.TblHangs.RemoveRange(soluonglist);
            await _context.SaveChangesAsync();

            return Ok("Xoá hàng Hoá thành công");
       
        }

        [HttpPut()]
        [Route("Cập nhật thông tin hàng hoá")]
        public async Task<IActionResult> UpdateKhachhang(string Mahang, TblHang hanghoa)
        {

            if (Mahang != hanghoa.MaHang)
            {
                return BadRequest("vui lòng nhập lại 2 trường Mahang phải giống nhau ");
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
                    return NotFound("mã mặt hàng ko tồn tại");
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

