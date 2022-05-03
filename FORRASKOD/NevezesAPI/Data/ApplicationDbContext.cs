using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NevezesAPI.Models;

namespace NevezesAPI.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<Felhasznalo>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        /*
         * add-migration init
         * update-database
         * remove-migration
         * remove-migration -force
         */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Auth");
            modelBuilder.Entity<Csapat>(entity =>
            {
                entity.HasKey(e => e.Azon);

                entity.ToTable(name: "Csapat", schema: "Nevezes");

                entity.Property(e => e.Azon).ValueGeneratedNever();
            });

            modelBuilder.Entity<Egyesulet>(entity =>
            {
                entity.HasKey(e => e.Azon);

                entity.ToTable("Egyesulet", schema: "Nevezes");

                entity.Property(e => e.Azon).ValueGeneratedNever();

                entity.Property(e => e.Nev).HasMaxLength(50);

                entity.Property(e => e.Rovidites).HasMaxLength(50);
            });

            modelBuilder.Entity<Felhasznalo>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Felhasznalo", schema: "Auth");
            });

            modelBuilder.Entity<Kategoria>(entity =>
            {
                entity.ToTable(name: "Kategora", schema: "Nevezes");
                entity.HasKey(e => e.Azon);

                entity.Property(e => e.Azon).ValueGeneratedNever();

                entity.Property(e => e.Megnevezes).HasMaxLength(50);
            });

            modelBuilder.Entity<Korcsoport>(entity =>
            {
                entity.HasKey(e => e.Azon);

                entity.ToTable("Korcsoport", schema: "Nevezes");

                entity.Property(e => e.Azon).ValueGeneratedNever();

                entity.Property(e => e.Megnevezes).HasMaxLength(50);
            });

            modelBuilder.Entity<Nevezes>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable(name: "Nevezes", schema: "Nevezes");

                entity.HasKey(e => e.Azon);

                entity.Property(e => e.Azon).ValueGeneratedNever();

                entity.Property(e => e.CsapatAzon).HasColumnName("Csapat_Azon");

                entity.Property(e => e.KategoriaAzon).HasColumnName("Kategoria_Azon");

                entity.Property(e => e.KorcsoportAzon).HasColumnName("Korcsoport_Azon");

                entity.Property(e => e.KoreoCim).HasMaxLength(50);

                entity.Property(e => e.RogzitoAzon).HasColumnName("Rogzito_Azon");

                entity.Property(e => e.VersenySzamAzon).HasColumnName("VersenySzam_Azon");

                entity.Property(e => e.VersenyzoAzon).HasColumnName("Versenyzo_Azon");

                entity.HasOne(d => d.CsapatAzonNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CsapatAzon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nevezes_Csapat");

                entity.HasOne(d => d.KategoriaAzonNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.KategoriaAzon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nevezes_Kategoria");

                entity.HasOne(d => d.KorcsoportAzonNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.KorcsoportAzon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nevezes_Korcsoport");

                entity.HasOne(d => d.RogzitoAzonNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.RogzitoAzon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nevezes_Felhasznalo");

                entity.HasOne(d => d.VersenySzamAzonNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.VersenySzamAzon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nevezes_VersenySzam");

                entity.HasOne(d => d.VersenyzoAzonNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.VersenyzoAzon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nevezes_Versenyzo");
            });

            modelBuilder.Entity<VersenySzam>(entity =>
            {
                entity.HasKey(e => e.Azon);

                entity.ToTable("VersenySzam", schema: "Nevezes");

                entity.Property(e => e.Azon).ValueGeneratedNever();

                entity.Property(e => e.Megnevezes).HasMaxLength(50);
            });

            modelBuilder.Entity<Versenyzo>(entity =>
            {
                entity.HasKey(e => e.SirAzon);

                entity.ToTable("Versenyzo", schema: "Nevezes");

                entity.HasIndex(e => e.SirAzon, "IX_Versenyzo");

                entity.Property(e => e.SirAzon)
                    .ValueGeneratedNever()
                    .HasColumnName("Sir_Azon");

                entity.Property(e => e.EgyesuletAzon).HasColumnName("Egyesulet_Azon");

                entity.Property(e => e.EngedelyErv).HasColumnType("date");

                entity.Property(e => e.Nev).HasMaxLength(100);

                entity.Property(e => e.SzulDatum).HasColumnType("date");

                entity.Property(e => e.SzulHely).HasMaxLength(50);

                entity.HasOne(d => d.EgyesuletAzonNavigation)
                    .WithMany(p => p.Versenyzok)
                    .HasForeignKey(d => d.EgyesuletAzon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Versenyzo_Egyesulet");
            });
        }

        public virtual DbSet<Csapat> Csapats { get; set; } = null!;
        public virtual DbSet<Egyesulet> Egyesulets { get; set; } = null!;
        public virtual DbSet<Felhasznalo> Felhasznalos { get; set; } = null!;
        public virtual DbSet<Kategoria> Kategoria { get; set; } = null!;
        public virtual DbSet<Korcsoport> Korcsoports { get; set; } = null!;
        public virtual DbSet<Nevezes> Nevezes { get; set; } = null!;
        public virtual DbSet<VersenySzam> VersenySzams { get; set; } = null!;
        public virtual DbSet<Versenyzo> Versenyzos { get; set; } = null!;
    }
}