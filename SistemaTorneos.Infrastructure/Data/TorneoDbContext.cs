using Microsoft.EntityFrameworkCore;
using SistemaTorneos.Core.Entities;

namespace SistemaTorneos.Infrastructure.Data
{
    public class TorneoDbContext : DbContext
    {
        public TorneoDbContext(DbContextOptions<TorneoDbContext> options) : base(options) { }

        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Torneo> Torneos { get; set; }
        public DbSet<Partida> Partidas { get; set; }

        public DbSet<Encuentro> Encuentros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Partida>()
                .HasOne(p => p.Jugador1)
                .WithMany()
                .HasForeignKey(p => p.Jugador1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Partida>()
                .HasOne(p => p.Jugador2)
                .WithMany()
                .HasForeignKey(p => p.Jugador2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Partida>()
                .HasOne(p => p.Ganador)
                .WithMany()
                .HasForeignKey(p => p.GanadorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}