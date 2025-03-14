using Microsoft.EntityFrameworkCore;
using AgendaUsuarios.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaUsuarios.DAL.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //config tabla Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(true);
                entity.Property(e => e.Telefono)
                .HasMaxLength(10);
    
        });

            base.OnModelCreating(modelBuilder);
        }
    }
}
