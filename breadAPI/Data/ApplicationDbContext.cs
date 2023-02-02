using breadAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace breadAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<msobat> msobat { get; set; }
        public DbSet<trpenjualan> trpenjualan { get; set; }
        public DbSet<trpenjualandetail> trpenjualandetail { get; set; }
    }
}
