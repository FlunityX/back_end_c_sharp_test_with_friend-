using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quan_ly_ban_hang.Entities;

namespace back_end_c_sharp_test_with_friend_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class nhanvienController : Controller
    {
        private readonly DbAa8167Nguyenmanh1203Context _context;
        public nhanvienController(DbAa8167Nguyenmanh1203Context ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        [Route("Trả về thông tin tất cả nhân viên Theo khu vực")]
        public async Task<IActionResult> GetNhanvien(int MaKhuVuc)
        {
            var nhanvienList = await _context.TblNhanViens
                .Where(nv => nv.MaKvNavigation.MaKv == MaKhuVuc)
                .ToListAsync();
            
            return Ok(nhanvienList);
        }
        [HttpHead]
        public IActionResult GetAllHead()
        {
            // Trả về một phản hồi chứa nội dung tùy chỉnh
            return Ok();
        }
    }
}
