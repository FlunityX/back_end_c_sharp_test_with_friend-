using System;
using System.Collections.Generic;

namespace back_end_c_sharp_test_with_friend_.Entities;

public partial class HoaDon
{
    public string MaHd { get; set; } = null!;

    public string MaKh { get; set; } = null!;

    public DateTime NgayHd { get; set; }

    public decimal TriGia { get; set; }

    public virtual ICollection<Cthd> Cthds { get; set; } = new List<Cthd>();

    public virtual KhachHang MaKhNavigation { get; set; } = null!;
}
