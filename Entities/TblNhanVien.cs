using System;
using System.Collections.Generic;

namespace back_end_c_sharp_test_with_friend_.Entities;

public partial class TblNhanVien
{
    public string MaNhanVien { get; set; } = null!;

    public string? TenNhanVien { get; set; }

    public string? GioiTinh { get; set; }

    public string? Diachi { get; set; }

    public string? DienThoai { get; set; }

    public DateTime? NgaySinh { get; set; }

    public int? MaKv { get; set; }

    public virtual TblKhuVuc? MaKvNavigation { get; set; }
}
