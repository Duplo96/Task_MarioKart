using Microsoft.EntityFrameworkCore;
using Task_MarioKart.Models;

namespace ASP_lez03_EF_Manuale_Ferramenta.Models
{
    public class MarioKartContext : DbContext
    {
        public MarioKartContext(DbContextOptions<MarioKartContext> options) : base(options)
        {

        }

        public DbSet<Personaggi> Personaggi { get; set; }
        public DbSet<Squadra> Squadra { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Squadra>().HasKey(s => new { s.SquadraId });
            modelBuilder.Entity<Personaggi>().HasKey(p => new { p.PersonaggioId });
            modelBuilder.Entity<Squadra>().HasMany(sq => sq.Personaggis).WithOne(sq => sq.SquadraRifNavigation).HasForeignKey(sq => sq.SquadraRif);


            modelBuilder.Entity<Personaggi>().HasOne(per => per.SquadraRifNavigation).WithMany(per => per.Personaggis).HasForeignKey(per => per.SquadraRif);

        }

    }
}