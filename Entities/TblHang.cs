using System;
using System.Collections.Generic;

namespace quan_ly_ban_hang.Entities;

public partial class TblHang
{
    public string MaHang { get; set; } = null!;

    public string TenHang { get; set; } = null!;

    public string TenChatLieu { get; set; } = null!;

    public double? SoLuong { get; set; }

    public double? DonGiaNhap { get; set; }

    public double? DonGiaBan { get; set; }

    public string? GhiChu { get; set; }
}
