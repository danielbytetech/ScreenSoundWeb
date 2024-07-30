using Microsoft.EntityFrameworkCore;
using ScreenSoundWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenSoundWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Banda> Bandas { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Banda>()
                .HasMany(b => b.Albuns)
                .WithOne(a => a.Banda)
                .HasForeignKey(a => a.BandaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Banda>()
                .HasMany(b => b.Notas)
                .WithOne(n => n.Banda)
                .HasForeignKey(n => n.BandaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

