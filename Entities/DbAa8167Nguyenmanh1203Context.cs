using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace back_end_c_sharp_test_with_friend_.Entities;

public partial class DbAa8167Nguyenmanh1203Context : DbContext
{
    public DbAa8167Nguyenmanh1203Context()
    {
    }

    public DbAa8167Nguyenmanh1203Context(DbContextOptions<DbAa8167Nguyenmanh1203Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; }

    public virtual DbSet<Hoadon> Hoadons { get; set; }

    public virtual DbSet<Linhvuc> Linhvucs { get; set; }

    public virtual DbSet<Loaisach> Loaisaches { get; set; }

    public virtual DbSet<Nhaxuatban> Nhaxuatbans { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<Tacgium> Tacgia { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<TblChatLieu> TblChatLieus { get; set; }

    public virtual DbSet<TblHang> TblHangs { get; set; }

    public virtual DbSet<TblKhach> TblKhaches { get; set; }

    public virtual DbSet<TblKhuVuc> TblKhuVucs { get; set; }

    public virtual DbSet<TblNhanVien> TblNhanViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SQL5113.site4now.net,1433;Initial Catalog=db_aa8167_nguyenmanh1203;User Id=db_aa8167_nguyenmanh1203_admin;Password=phucdeptrai123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chitiethoadon>(entity =>
        {
            entity.HasKey(e => new { e.Mahoadon, e.Masach }).HasName("PK__CHITIETH__7765D51193F23F74");

            entity.ToTable("CHITIETHOADON");

            entity.Property(e => e.Mahoadon)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAHOADON");
            entity.Property(e => e.Masach)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MASACH");
            entity.Property(e => e.Giatien).HasColumnName("GIATIEN");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Thanhtien).HasColumnName("THANHTIEN");

            entity.HasOne(d => d.MahoadonNavigation).WithMany(p => p.Chitiethoadons)
                .HasForeignKey(d => d.Mahoadon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETHO__MAHOA__151B244E");

            entity.HasOne(d => d.MasachNavigation).WithMany(p => p.Chitiethoadons)
                .HasForeignKey(d => d.Masach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETHO__MASAC__160F4887");
        });

        modelBuilder.Entity<Hoadon>(entity =>
        {
            entity.HasKey(e => e.Mahoadon).HasName("PK__HOADON__A4999DF5D4A801A3");

            entity.ToTable("HOADON");

            entity.Property(e => e.Mahoadon)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAHOADON");
            entity.Property(e => e.Ngaylap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("NGAYLAP");
            entity.Property(e => e.Tenkhachhang)
                .HasMaxLength(50)
                .HasColumnName("TENKHACHHANG");
            entity.Property(e => e.Tongtien)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TONGTIEN");
        });

        modelBuilder.Entity<Linhvuc>(entity =>
        {
            entity.HasKey(e => e.Tenlinhvuc).HasName("PK__LINHVUC__A928AA11ADB419CD");

            entity.ToTable("LINHVUC");

            entity.Property(e => e.Tenlinhvuc)
                .HasMaxLength(30)
                .HasColumnName("TENLINHVUC");
        });

        modelBuilder.Entity<Loaisach>(entity =>
        {
            entity.HasKey(e => e.Tenloaisach).HasName("PK__LOAISACH__C5E50BE5787F655A");

            entity.ToTable("LOAISACH");

            entity.Property(e => e.Tenloaisach)
                .HasMaxLength(30)
                .HasColumnName("TENLOAISACH");
        });

        modelBuilder.Entity<Nhaxuatban>(entity =>
        {
            entity.HasKey(e => e.Tennhaxuatban).HasName("PK__NHAXUATB__FD6BF960F0998BA1");

            entity.ToTable("NHAXUATBAN");

            entity.Property(e => e.Tennhaxuatban)
                .HasMaxLength(50)
                .HasColumnName("TENNHAXUATBAN");
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.Masach).HasName("PK__SACH__3FC48E4CEA5C184F");

            entity.ToTable("SACH");

            entity.Property(e => e.Masach)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MASACH");
            entity.Property(e => e.Giabia).HasColumnName("GIABIA");
            entity.Property(e => e.Giamua).HasColumnName("GIAMUA");
            entity.Property(e => e.Lantaiban).HasColumnName("LANTAIBAN");
            entity.Property(e => e.Matg)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MATG");
            entity.Property(e => e.Tenlinhvuc)
                .HasMaxLength(30)
                .HasColumnName("TENLINHVUC");
            entity.Property(e => e.Tenloaisach)
                .HasMaxLength(30)
                .HasColumnName("TENLOAISACH");
            entity.Property(e => e.Tennhaxuatban)
                .HasMaxLength(50)
                .HasColumnName("TENNHAXUATBAN");
            entity.Property(e => e.Tensach)
                .HasMaxLength(100)
                .HasColumnName("TENSACH");

            entity.HasOne(d => d.MatgNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.Matg)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SACH__MATG__08B54D69");

            entity.HasOne(d => d.TenlinhvucNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.Tenlinhvuc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SACH__TENLINHVUC__09A971A2");

            entity.HasOne(d => d.TenloaisachNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.Tenloaisach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SACH__TENLOAISAC__0A9D95DB");

            entity.HasOne(d => d.TennhaxuatbanNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.Tennhaxuatban)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SACH__TENNHAXUAT__0B91BA14");
        });

        modelBuilder.Entity<Tacgium>(entity =>
        {
            entity.HasKey(e => e.Matg).HasName("PK__TACGIA__6023721A78DF06A6");

            entity.ToTable("TACGIA");

            entity.Property(e => e.Matg)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MATG");
            entity.Property(e => e.Nammat)
                .HasColumnType("date")
                .HasColumnName("NAMMAT");
            entity.Property(e => e.Namsinh)
                .HasColumnType("date")
                .HasColumnName("NAMSINH");
            entity.Property(e => e.Quequan)
                .HasMaxLength(20)
                .HasColumnName("QUEQUAN");
            entity.Property(e => e.Tentg)
                .HasMaxLength(40)
                .HasColumnName("TENTG");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__TAIKHOAN__B15BE12FA6A9F127");

            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("USERNAME");
            entity.Property(e => e.PassWord)
                .HasMaxLength(100)
                .HasColumnName("PASS_WORD");
        });

        modelBuilder.Entity<TblChatLieu>(entity =>
        {
            entity.HasKey(e => e.MaChatLieu);

            entity.ToTable("tblChatLieu");

            entity.Property(e => e.MaChatLieu).HasMaxLength(50);
            entity.Property(e => e.TenChatLieu).HasMaxLength(50);
        });

        modelBuilder.Entity<TblHang>(entity =>
        {
            entity.HasKey(e => e.MaHang).HasName("PK__Hang__19C0DB1D686C2886");

            entity.ToTable("tblHang");

            entity.Property(e => e.MaHang).HasMaxLength(50);
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.TenChatLieu).HasMaxLength(50);
            entity.Property(e => e.TenHang).HasMaxLength(50);
        });

        modelBuilder.Entity<TblKhach>(entity =>
        {
            entity.HasKey(e => e.MaKhach).HasName("PK__tblKhach__D0CB8DDD3A15453D");

            entity.ToTable("tblKhach");

            entity.Property(e => e.MaKhach).HasMaxLength(10);
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai).HasMaxLength(50);
            entity.Property(e => e.TenKhach).HasMaxLength(50);
        });

        modelBuilder.Entity<TblKhuVuc>(entity =>
        {
            entity.HasKey(e => e.MaKv);

            entity.ToTable("tblKhuVuc");

            entity.Property(e => e.MaKv)
                .ValueGeneratedNever()
                .HasColumnName("MaKV");
            entity.Property(e => e.MaNvql).HasColumnName("MaNVQL");
            entity.Property(e => e.TenKv)
                .HasMaxLength(250)
                .HasColumnName("TenKV");
        });

        modelBuilder.Entity<TblNhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__tblNhanV__77B2CA4746868A85");

            entity.ToTable("tblNhanVien");

            entity.Property(e => e.MaNhanVien).HasMaxLength(50);
            entity.Property(e => e.Diachi).HasMaxLength(200);
            entity.Property(e => e.DienThoai).HasMaxLength(20);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.MaKv).HasColumnName("MaKV");
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.TenNhanVien).HasMaxLength(50);

            entity.HasOne(d => d.MaKvNavigation).WithMany(p => p.TblNhanViens)
                .HasForeignKey(d => d.MaKv)
                .HasConstraintName("FK_tblNhanVien_tblKhuVuc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
