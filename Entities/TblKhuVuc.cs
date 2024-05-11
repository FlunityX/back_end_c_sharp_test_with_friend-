using System;
using System.Collections.Generic;

namespace quan_ly_ban_hang.Entities;

public partial class TblKhuVuc
{
    public int MaKv { get; set; }

    public string? TenKv { get; set; }

    public int? MaNvql { get; set; }

    public virtual ICollection<TblNhanVien> TblNhanViens { get; set; } = new List<TblNhanVien>();
}
