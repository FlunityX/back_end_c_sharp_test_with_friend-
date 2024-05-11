using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace quan_ly_ban_hang.Entities;

public partial class DbAa8167Nguyenmanh1203Context : DbContext
{
    public DbAa8167Nguyenmanh1203Context()
    {
    }

    public DbAa8167Nguyenmanh1203Context(DbContextOptions<DbAa8167Nguyenmanh1203Context> options)
        : base(options)
    {
    }

   

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
