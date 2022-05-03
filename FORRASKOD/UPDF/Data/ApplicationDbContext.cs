using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UPDF.Models;

namespace UPDF.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }/*

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
                entity.HasKey(e => new { e.Azon });

                entity.ToTable(name: "Csapat", schema: "Nevezes");

                entity.Property(e => e.Azon).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Egyesulet>(entity =>
            {
                entity.HasKey(e => new { e.Azon });

                entity.ToTable("Egyesulet", schema: "Nevezes");

                entity.Property(e => e.Azon).ValueGeneratedOnAdd();

                entity.Property(e => e.Nev).HasMaxLength(50);

                entity.Property(e => e.Rovidites).HasMaxLength(50);
            });

            modelBuilder.Entity<Kategoria>(entity =>
            {
                entity.HasKey(e => new { e.Azon });

                entity.ToTable(name: "Kategora", schema: "Nevezes");

                entity.Property(e => e.Azon).ValueGeneratedOnAdd();

                entity.Property(e => e.Megnevezes).HasMaxLength(50);
            });

            modelBuilder.Entity<Korcsoport>(entity =>
            {
                entity.HasKey(e => new { e.Azon });

                entity.ToTable("Korcsoport", schema: "Nevezes");

                entity.Property(e => e.Azon).ValueGeneratedOnAdd();

                entity.Property(e => e.Megnevezes).HasMaxLength(50);
            });

            modelBuilder.Entity<Nevezes>(entity =>
            {
                entity.HasKey(e => new { e.Azon });

                entity.ToTable(name: "Nevezes", schema: "Nevezes");

                entity.Property(e => e.Azon).ValueGeneratedOnAdd();

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

                entity.Property(e => e.Azon).ValueGeneratedOnAdd();

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

        public virtual DbSet<Csapat> Csapatok { get; set; } = null!;
        public virtual DbSet<Egyesulet> Egyesuletek { get; set; } = null!;
        public virtual DbSet<Kategoria> Kategoriak { get; set; } = null!;
        public virtual DbSet<Korcsoport> Korcsoportok { get; set; } = null!;
        public virtual DbSet<Nevezes> Nevezesek { get; set; } = null!;
        public virtual DbSet<VersenySzam> VersenySzamok { get; set; } = null!;
        public virtual DbSet<Versenyzo> Versenyzok { get; set; } = null!;
    }
}