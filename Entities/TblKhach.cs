using System;
using System.Collections.Generic;

namespace back_end_c_sharp_test_with_friend_.Entities;

public partial class TblKhach
{
    public string MaKhach { get; set; } = null!;

    public string? TenKhach { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }
}
