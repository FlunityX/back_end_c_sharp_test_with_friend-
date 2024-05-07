using System;
using System.Collections.Generic;

namespace back_end_c_sharp_test_with_friend_.Entities;

public partial class Tacgium
{
    public string Matg { get; set; } = null!;

    public string Tentg { get; set; } = null!;

    public DateTime? Namsinh { get; set; }

    public DateTime? Nammat { get; set; }

    public string? Quequan { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
