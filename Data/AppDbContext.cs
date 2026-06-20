using Microsoft.EntityFrameworkCore;
using _222_123_BaiThi.Models;

namespace _222_123_BaiThi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> SinhVien { get; set; }

        public DbSet<PhuongXa> PhuongXa { get; set; }
    }
}