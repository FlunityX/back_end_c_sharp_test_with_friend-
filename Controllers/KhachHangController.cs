
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using quan_ly_ban_hang.Entities;

namespace quan_ly_ban_hang.Controllers;
[ApiController]
[Route("[controller]")]
public class KhachHangController : ControllerBase
{
    private readonly DbAa8167Nguyenmanh1203Context _context;
    public KhachHangController(DbAa8167Nguyenmanh1203Context ctx)
    {
        _context = ctx;
    }

    [HttpGet]
    [Route("Trả về thông tin tất cả khách hàng")]
    public IActionResult GetAll()
    {
        return Ok(_context.TblKhaches.ToList());
    }

    [HttpGet]
    [Route("Tìm kiếm khách hàng theo mã khách hàng")]
    public async Task<ActionResult<TblKhach>> Getkhachhangbyid(string MaKH)
    {
        var sp = await _context.TblKhaches.FindAsync(MaKH);
        if (sp == null)
        {
            return NotFound();
        }
        return sp;
    }

    [HttpPost]
    [Route("Thêm khách hàng")]
    public async Task<ActionResult<TblKhach>> addkhachhang(TblKhach add)
        {
            _context.TblKhaches.Add(add);
            await _context.SaveChangesAsync();
            return Ok(_context.TblKhaches.ToList());
        }

    [HttpDelete]
    [Route("Xoá khách hàng theo id")]
    public async Task<IActionResult> DeleteKhachHang(string MaKhach)
    {
        var khachHang = await _context.TblKhaches.SingleOrDefaultAsync(kh => kh.MaKhach == MaKhach);

        if (khachHang == null)
        {
            return NotFound();
        }

        _context.TblKhaches.Remove(khachHang);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPut()]
    [Route("Cập nhật thông tin khách hàng")]
        public async Task<IActionResult> UpdateSKhachhang(string MaKhachhang,TblKhach khach)
        {
            
            if (MaKhachhang!= khach.MaKhach)
            {
                return BadRequest();
            }
        
        _context.Entry(khach).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!makhachhangExists(MaKhachhang))
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

    private bool makhachhangExists(string Makhach)
    {
        return _context.TblKhaches.Any(e => e.MaKhach == Makhach);
    }
    [HttpPatch]
    [Route("Cập nhật thông tin khách hàng")]
    public async Task<IActionResult> UpdateKhachhang(string MaKhachhang, [FromBody] JsonPatchDocument<TblKhach> khachPatchDocument)
    {
        var khachHang = await _context.TblKhaches.FirstOrDefaultAsync(kh => kh.MaKhach == MaKhachhang);

        if (khachHang == null)
        {
            return NotFound();
        }

        khachPatchDocument.ApplyTo(khachHang, ModelState);

        if (!TryValidateModel(khachHang))
        {
            return BadRequest(ModelState);
        }

        await _context.SaveChangesAsync();

        // Trả về mã trạng thái HTTP phù hợp và thông báo tương ứng
        if (khachPatchDocument.Operations.Any(op => op.OperationType == OperationType.Replace))
        {
            return Ok("Đã sửa 1 trường thông tin khách hàng");
        }
        else if (khachPatchDocument.Operations.Any(op => op.OperationType == OperationType.Add))
        {
            return Ok("Đã thêm 1 trường thông tin khách hàng");
        }
        else if (khachPatchDocument.Operations.Any(op => op.OperationType == OperationType.Remove))
        {
            return Ok("Đã xoá 1 trường thông tin khách hàng");
        }
        else
        {
            return Ok("Đã cập nhật thông tin khách hàng");
        }
    }
}

