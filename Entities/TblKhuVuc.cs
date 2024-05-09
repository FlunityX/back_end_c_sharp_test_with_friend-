using System;
using System.Collections.Generic;

namespace back_end_c_sharp_test_with_friend_.Entities;

public partial class TblKhuVuc
{
    public int MaKv { get; set; }

    public string? TenKv { get; set; }

    public int? MaNvql { get; set; }

    public virtual ICollection<TblNhanVien> TblNhanViens { get; set; } = new List<TblNhanVien>();
}
