using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace back_end_c_sharp_test_with_friend_.Entities;
public partial class SanPham
{
    public string MaSp { get; set; } = null!;

    public string TenSp { get; set; } = null!;

    public int SoLuong { get; set; }

    public decimal Gia { get; set; }

   [JsonIgnore]
    public virtual ICollection<Cthd> Cthds { get; set; } = new List<Cthd>();
}


