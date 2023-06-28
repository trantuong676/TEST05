using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEST05.Models;

    public class BAITHI : DbContext
    {
        public BAITHI (DbContextOptions<BAITHI> options)
            : base(options)
        {
        }

        public DbSet<TEST05.Models.KhachHang> KhachHang { get; set; } = default!;

        public DbSet<TEST05.Models.DonHang> DonHang { get; set; } = default!;
    }
