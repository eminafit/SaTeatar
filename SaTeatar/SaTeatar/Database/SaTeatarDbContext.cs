using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SaTeatar.WebAPI.Database
{
    public partial class SaTeatarDbContext : DbContext
    {
        public SaTeatarDbContext()
        {
        }

        public SaTeatarDbContext(DbContextOptions<SaTeatarDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Djelatnici> Djelatnici { get; set; }
        public virtual DbSet<Izvodjenja> Izvodjenja { get; set; }
        public virtual DbSet<IzvodjenjaZone> IzvodjenjaZone { get; set; }
        public virtual DbSet<Karte> Karte { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<KorisniciUloge> KorisniciUloge { get; set; }
        public virtual DbSet<Kupci> Kupci { get; set; }
        public virtual DbSet<Ocjene> Ocjene { get; set; }
        public virtual DbSet<PoslaneObavijesti> PoslaneObavijesti { get; set; }
        public virtual DbSet<PostavkeObavijesti> PostavkeObavijesti { get; set; }
        public virtual DbSet<Pozorista> Pozorista { get; set; }
        public virtual DbSet<Predstave> Predstave { get; set; }
        public virtual DbSet<PredstaveDjelatnici> PredstaveDjelatnici { get; set; }
        public virtual DbSet<TipoviPredstava> TipoviPredstava { get; set; }
        public virtual DbSet<Uloge> Uloge { get; set; }
        public virtual DbSet<VrsteDjelatnika> VrsteDjelatnika { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=SaTeatarDb; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Djelatnici>(entity =>
            {
                entity.HasKey(e => e.DjelatnikId);

                entity.ToTable("Djelatnici");

                entity.Property(e => e.DjelatnikId).HasColumnName("DjelatnikID");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VrstaDjelatnikaId).HasColumnName("VrstaDjelatnikaID");

                entity.HasOne(d => d.VrstaDjelatnika)
                    .WithMany(p => p.Djelatnicis)
                    .HasForeignKey(d => d.VrstaDjelatnikaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Djelatnici_VrsteDjelatnika");
            });

            modelBuilder.Entity<Izvodjenja>(entity =>
            {
                entity.HasKey(e => e.IzvodjenjeId);

                entity.ToTable("Izvodjenja");

                entity.Property(e => e.IzvodjenjeId).HasColumnName("IzvodjenjeID");

                entity.Property(e => e.DatumVrijeme).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.PozoristeId).HasColumnName("PozoristeID");

                entity.Property(e => e.PredstavaId).HasColumnName("PredstavaID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Izvodjenjas)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Izvodjenja_Korisnici");

                entity.HasOne(d => d.Pozoriste)
                    .WithMany(p => p.Izvodjenjas)
                    .HasForeignKey(d => d.PozoristeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Izvodjenja_Pozorista");

                entity.HasOne(d => d.Predstava)
                    .WithMany(p => p.Izvodjenjas)
                    .HasForeignKey(d => d.PredstavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Izvodjenja_Predstave");
            });

            modelBuilder.Entity<IzvodjenjaZone>(entity =>
            {
                entity.HasKey(e => e.IzvodjenjeZonaId);

                entity.ToTable("IzvodjenjaZone");

                entity.Property(e => e.IzvodjenjeZonaId).HasColumnName("IzvodjenjeZonaID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IzvodjenjeId).HasColumnName("IzvodjenjeID");

                entity.Property(e => e.Popust).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ZonaId).HasColumnName("ZonaID");

                entity.HasOne(d => d.Izvodjenje)
                    .WithMany(p => p.IzvodjenjaZones)
                    .HasForeignKey(d => d.IzvodjenjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IzvodjenjaZone_Izvodjenja");

                entity.HasOne(d => d.Zona)
                    .WithMany(p => p.IzvodjenjaZones)
                    .HasForeignKey(d => d.ZonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IzvodjenjaZone_Zone");
            });

            modelBuilder.Entity<Karte>(entity =>
            {
                entity.HasKey(e => e.KartaId);

                entity.ToTable("Karte");

                entity.Property(e => e.KartaId).HasColumnName("KartaID");

                entity.Property(e => e.IzvodjenjeId).HasColumnName("IzvodjenjeID");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.Sifra)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Izvodjenje)
                    .WithMany(p => p.Kartes)
                    .HasForeignKey(d => d.IzvodjenjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Karte_Izvodjenja");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Kartes)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Karte_Kupci");
            });

            modelBuilder.Entity<Korisnici>(entity =>
            {
                entity.HasKey(e => e.KorisnikId);

                entity.ToTable("Korisnici");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaHash)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaSalt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<KorisniciUloge>(entity =>
            {
                entity.HasKey(e => e.KorisnikUlogaId);

                entity.ToTable("KorisniciUloge");

                entity.Property(e => e.KorisnikUlogaId).HasColumnName("KorisnikUlogaID");

                entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.KorisniciUloges)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KorisniciUloge_Korisnici");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.KorisniciUloges)
                    .HasForeignKey(d => d.UlogaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KorisniciUloge_Uloge");
            });

            modelBuilder.Entity<Kupci>(entity =>
            {
                entity.HasKey(e => e.KupacId);

                entity.ToTable("Kupci");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.DatumRegistracije).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaHash)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaSalt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ocjene>(entity =>
            {
                entity.HasKey(e => e.OcjenaId);

                entity.ToTable("Ocjene");

                entity.Property(e => e.OcjenaId).HasColumnName("OcjenaID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.IzvodjenjeId).HasColumnName("IzvodjenjeID");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.HasOne(d => d.Izvodjenje)
                    .WithMany(p => p.Ocjenes)
                    .HasForeignKey(d => d.IzvodjenjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ocjene_Izvodjenja");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Ocjenes)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ocjene_Kupci");
            });

            modelBuilder.Entity<PoslaneObavijesti>(entity =>
            {
                entity.HasKey(e => e.PoslanaObavijestId);

                entity.ToTable("PoslaneObavijesti");

                entity.Property(e => e.PoslanaObavijestId).HasColumnName("PoslanaObavijestID");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.PrestavaId).HasColumnName("PrestavaID");

                entity.Property(e => e.VrijemeSlanja).HasColumnType("datetime");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.PoslaneObavijestis)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoslaneObavijesti_Kupci");

                entity.HasOne(d => d.Prestava)
                    .WithMany(p => p.PoslaneObavijestis)
                    .HasForeignKey(d => d.PrestavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoslaneObavijesti_Predstave");
            });

            modelBuilder.Entity<PostavkeObavijesti>(entity =>
            {
                entity.HasKey(e => e.PostavkaObavijestiId);

                entity.ToTable("PostavkeObavijesti");

                entity.Property(e => e.PostavkaObavijestiId).HasColumnName("PostavkaObavijestiID");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.TipPredstaveId).HasColumnName("TipPredstaveID");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.PostavkeObavijestis)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostavkeObavijesti_Kupci");

                entity.HasOne(d => d.TipPredstave)
                    .WithMany(p => p.PostavkeObavijestis)
                    .HasForeignKey(d => d.TipPredstaveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostavkeObavijesti_TipoviPredstava");
            });

            modelBuilder.Entity<Pozorista>(entity =>
            {
                entity.HasKey(e => e.PozoristeId);

                entity.Property(e => e.PozoristeId).HasColumnName("PozoristeID");

                entity.Property(e => e.Adresa)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Predstave>(entity =>
            {
                entity.HasKey(e => e.PredstavaId);

                entity.ToTable("Predstave");

                entity.Property(e => e.PredstavaId).HasColumnName("PredstavaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Opis)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.TipPredstaveId).HasColumnName("TipPredstaveID");

                entity.HasOne(d => d.TipPredstave)
                    .WithMany(p => p.Predstaves)
                    .HasForeignKey(d => d.TipPredstaveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Predstave_TipoviPredstava");
            });

            modelBuilder.Entity<PredstaveDjelatnici>(entity =>
            {
                entity.HasKey(e => e.PredstavaDjelatnik);

                entity.ToTable("PredstaveDjelatnici");

                entity.Property(e => e.DjelatnikId).HasColumnName("DjelatnikID");

                entity.Property(e => e.PredstavaId).HasColumnName("PredstavaID");

                entity.HasOne(d => d.Djelatnik)
                    .WithMany(p => p.PredstaveDjelatnicis)
                    .HasForeignKey(d => d.DjelatnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PredstaveDjelatnici_Djelatnici");

                entity.HasOne(d => d.Predstava)
                    .WithMany(p => p.PredstaveDjelatnicis)
                    .HasForeignKey(d => d.PredstavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PredstaveDjelatnici_Predstave");
            });

            modelBuilder.Entity<TipoviPredstava>(entity =>
            {
                entity.HasKey(e => e.TipPredstaveId);

                entity.ToTable("TipoviPredstava");

                entity.Property(e => e.TipPredstaveId).HasColumnName("TipPredstaveID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Uloge>(entity =>
            {
                entity.HasKey(e => e.UlogaId);

                entity.ToTable("Uloge");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opis).HasMaxLength(150);
            });

            modelBuilder.Entity<VrsteDjelatnika>(entity =>
            {
                entity.HasKey(e => e.VrstaDjelatnikaId);

                entity.ToTable("VrsteDjelatnika");

                entity.Property(e => e.VrstaDjelatnikaId).HasColumnName("VrstaDjelatnikaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.HasKey(e => e.ZonaId);

                entity.ToTable("Zone");

                entity.Property(e => e.ZonaId).HasColumnName("ZonaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PozoristeId).HasColumnName("PozoristeID");

                entity.HasOne(d => d.Pozoriste)
                    .WithMany(p => p.Zones)
                    .HasForeignKey(d => d.PozoristeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Zone_Pozorista");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
