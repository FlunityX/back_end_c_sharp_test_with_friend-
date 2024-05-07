using System;
using System.Collections.Generic;

namespace back_end_c_sharp_test_with_friend_.Entities;

public partial class Hoadon
{
    public string Mahoadon { get; set; } = null!;

    public string Tenkhachhang { get; set; } = null!;

    public DateTime? Ngaylap { get; set; }

    public decimal? Tongtien { get; set; }

    public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; } = new List<Chitiethoadon>();
}
