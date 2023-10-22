using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BTLN3.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BTLN3.Models.ChucVu> ChucVu { get; set; } = default!;

        public DbSet<BTLN3.Models.GoiTap> GoiTap { get; set; } = default!;

        public DbSet<BTLN3.Models.HoiVien> HoiVien { get; set; } = default!;

        public DbSet<BTLN3.Models.NhanVien> NhanVien { get; set; } = default!;

        public DbSet<BTLN3.Models.ThanhToan> ThanhToan { get; set; } = default!;

        public DbSet<BTLN3.Models.ThietBi> ThietBi { get; set; } = default!;

        public DbSet<BTLN3.Models.TinhTrang> TinhTrang { get; set; } = default!;
    }
