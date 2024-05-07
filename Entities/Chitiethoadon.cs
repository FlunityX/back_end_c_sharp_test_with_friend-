using System;
using System.Collections.Generic;

namespace back_end_c_sharp_test_with_friend_.Entities;

public partial class Chitiethoadon
{
    public string Mahoadon { get; set; } = null!;

    public string Masach { get; set; } = null!;

    public int? Soluong { get; set; }

    public int? Giatien { get; set; }

    public int? Thanhtien { get; set; }

    public virtual Hoadon MahoadonNavigation { get; set; } = null!;

    public virtual Sach MasachNavigation { get; set; } = null!;
}
