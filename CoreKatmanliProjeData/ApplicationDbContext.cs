using CoreKatmanlıProjeModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreKatmanliProje.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
    }
        public DbSet<Departmanlar> Departmanlars { get; set; }

        public DbSet<Calisanlar> Calisanlars { get; set; }
    }
}