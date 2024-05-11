using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace quan_ly_ban_hang.Entities;

public partial class TblNhanVien
{
    public string MaNhanVien { get; set; } = null!;

    public string? TenNhanVien { get; set; }

    public string? GioiTinh { get; set; }

    public string? Diachi { get; set; }

    public string? DienThoai { get; set; }

    public DateTime? NgaySinh { get; set; }

    public int? MaKv { get; set; }
    [JsonIgnore]
    public virtual TblKhuVuc? MaKvNavigation { get; set; }
}
