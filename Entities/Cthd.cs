using System;
using System.Collections.Generic;


namespace back_end_c_sharp_test_with_friend_.Entities;

public partial class Cthd
{
    public int SoHd { get; set; }

    public string MaHd { get; set; } = null!;

    public string MaSp { get; set; } = null!;

    public int SoLuong { get; set; }

    public decimal Gia { get; set; }

    public virtual HoaDon MaHdNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
