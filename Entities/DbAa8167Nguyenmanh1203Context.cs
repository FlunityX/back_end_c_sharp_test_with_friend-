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

    public virtual DbSet<Cthd> Cthds { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

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
        modelBuilder.Entity<Cthd>(entity =>
        {
            entity.HasKey(e => e.SoHd).HasName("PK__CTHD__BC3CAB5735338A85");

            entity.ToTable("CTHD");

            entity.Property(e => e.SoHd)
                .ValueGeneratedNever()
                .HasColumnName("SoHD");
            entity.Property(e => e.Gia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.MaHd)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaHD");
            entity.Property(e => e.MaSp)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSP");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.Cthds)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CTHD__MaHD__22751F6C");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.Cthds)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CTHD__MaSP__236943A5");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HoaDon__2725A6E056ED7964");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaHD");
            entity.Property(e => e.MaKh)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaKH");
            entity.Property(e => e.NgayHd)
                .HasColumnType("date")
                .HasColumnName("NgayHD");
            entity.Property(e => e.TriGia).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDon__MaKH__1F98B2C1");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1E3C9B1FC9");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaKH");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.HoTen).HasMaxLength(40);
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__SanPham__2725081C0F3E2081");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSP");
            entity.Property(e => e.Gia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TenSp)
                .HasMaxLength(40)
                .HasColumnName("TenSP");
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
