using System;
using System.Collections.Generic;

namespace back_end_c_sharp_test_with_friend_.Entities;

public partial class Sach
{
    public string Masach { get; set; } = null!;

    public string Tensach { get; set; } = null!;

    public string Matg { get; set; } = null!;

    public string Tenlinhvuc { get; set; } = null!;

    public string Tenloaisach { get; set; } = null!;

    public int? Giamua { get; set; }

    public int? Giabia { get; set; }

    public int? Lantaiban { get; set; }

    public string Tennhaxuatban { get; set; } = null!;

    public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; } = new List<Chitiethoadon>();

    public virtual Tacgium MatgNavigation { get; set; } = null!;

    public virtual Linhvuc TenlinhvucNavigation { get; set; } = null!;

    public virtual Loaisach TenloaisachNavigation { get; set; } = null!;

    public virtual Nhaxuatban TennhaxuatbanNavigation { get; set; } = null!;
}
