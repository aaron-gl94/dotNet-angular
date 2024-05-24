using Microsoft.EntityFrameworkCore;
using AaronGLAPI.Models;

namespace AaronGLAPI.Data
{
    public class BitacoraStoreContext : DbContext
    {
        public BitacoraStoreContext(DbContextOptions<BitacoraStoreContext> options) : base(options) { }

        public DbSet<Bitacora> Bitacoras { get; set; }
        public DbSet<SalesData> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bitacora>()
                .HasKey(b => b.IdLog); // Definir IdLog como clave primaria

            modelBuilder.Entity<Bitacora>()
                .OwnsOne(b => b.SaleLog); // Definir la relación como propiedad propietaria
        }
    }
}