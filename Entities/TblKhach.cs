using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace quan_ly_ban_hang.Entities;

public partial class TblKhach
{
    
    public string MaKhach { get; set; } = null!;

    public string? TenKhach { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }
}
