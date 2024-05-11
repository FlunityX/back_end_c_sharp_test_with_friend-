using Microsoft.AspNetCore.Mvc;
using quan_ly_ban_hang.Entities;

namespace back_end_c_sharp_test_with_friend_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KhuvucController : Controller
    {
        private readonly DbAa8167Nguyenmanh1203Context _context;
        public KhuvucController(DbAa8167Nguyenmanh1203Context ctx)
        {
            _context = ctx;
        }
        [HttpGet]
        [Route("Trả về thông tin tất cả khu vực")]
        public IActionResult GetAll()
        {
            return Ok(_context.TblKhuVucs.ToList());
        }
    }
}
