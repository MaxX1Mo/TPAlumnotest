using Microsoft.EntityFrameworkCore;
using TPAlumnotest.Models;
namespace TPAlumnotest.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) :base(options) {

        }
        public DbSet<Usuario> Usuarios{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>(tb =>
            {
                tb.HasKey(col => col.IDUsuario);
                tb.Property(col => col.IDUsuario)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Username).HasMaxLength(100);
                tb.Property(col => col.Clave).HasMaxLength(500);
            });

            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }
    }
}
