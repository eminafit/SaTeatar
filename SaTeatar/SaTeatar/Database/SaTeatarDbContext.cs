using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SaTeatar.Database
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
        public virtual DbSet<Narudzba> Narudzba { get; set; }
        public virtual DbSet<NarudzbaStavke> NarudzbaStavke { get; set; }
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

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Djelatnici>(entity =>
            {
                entity.HasKey(e => e.DjelatnikId);

                entity.ToTable("Djelatnici");

                entity.HasIndex(e => e.VrstaDjelatnikaId, "IX_Djelatnici_VrstaDjelatnikaID");

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

                entity.HasIndex(e => e.KorisnikId, "IX_Izvodjenja_KorisnikID");

                entity.HasIndex(e => e.PozoristeId, "IX_Izvodjenja_PozoristeID");

                entity.HasIndex(e => e.PredstavaId, "IX_Izvodjenja_PredstavaID");

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

                entity.HasIndex(e => e.IzvodjenjeId, "IX_IzvodjenjaZone_IzvodjenjeID");

                entity.HasIndex(e => e.ZonaId, "IX_IzvodjenjaZone_ZonaID");

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

                entity.HasIndex(e => e.IzvodjenjeId, "IX_Karte_IzvodjenjeID");

                entity.HasIndex(e => e.IzvodjenjeZonaId, "IX_Karte_IzvodjenjeZonaID");

                entity.HasIndex(e => e.KupacId, "IX_Karte_KupacID");

                entity.Property(e => e.KartaId).HasColumnName("KartaID");

                entity.Property(e => e.IzvodjenjeId).HasColumnName("IzvodjenjeID");

                entity.Property(e => e.IzvodjenjeZonaId).HasColumnName("IzvodjenjeZonaID");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.Qrcode).HasColumnName("QRCode");

                entity.Property(e => e.Sifra)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Izvodjenje)
                    .WithMany(p => p.Kartes)
                    .HasForeignKey(d => d.IzvodjenjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Karte_Izvodjenja");

                entity.HasOne(d => d.IzvodjenjeZona)
                    .WithMany(p => p.Kartes)
                    .HasForeignKey(d => d.IzvodjenjeZonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Karte_IzvodjenjaZone");

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

                entity.HasIndex(e => e.KorisnikId, "IX_KorisniciUloge_KorisnikID");

                entity.HasIndex(e => e.UlogaId, "IX_KorisniciUloge_UlogaID");

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

            modelBuilder.Entity<Narudzba>(entity =>
            {
                entity.ToTable("Narudzba");

                entity.Property(e => e.NarudzbaId).HasColumnName("NarudzbaID");

                entity.Property(e => e.BrojNarudzbe)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.Iznos).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.PaymentId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PaymentID");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Narudzbas)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Narudzba_Kupci");
            });

            modelBuilder.Entity<NarudzbaStavke>(entity =>
            {
                entity.ToTable("NarudzbaStavke");

                entity.Property(e => e.NarudzbaStavkeId).HasColumnName("NarudzbaStavkeID");

                entity.Property(e => e.KartaId).HasColumnName("KartaID");

                entity.Property(e => e.NarudzbaId).HasColumnName("NarudzbaID");

                entity.HasOne(d => d.Karta)
                    .WithMany(p => p.NarudzbaStavkes)
                    .HasForeignKey(d => d.KartaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NarudzbaStavke_Karte");

                entity.HasOne(d => d.Narudzba)
                    .WithMany(p => p.NarudzbaStavkes)
                    .HasForeignKey(d => d.NarudzbaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NarudzbaStavke_Narudzba");
            });

            modelBuilder.Entity<Ocjene>(entity =>
            {
                entity.HasKey(e => e.OcjenaId);

                entity.ToTable("Ocjene");

                entity.HasIndex(e => e.KupacId, "IX_Ocjene_KupacID");

                entity.HasIndex(e => e.PredstavaId, "IX_Ocjene_PredstavaID");

                entity.Property(e => e.OcjenaId).HasColumnName("OcjenaID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.PredstavaId).HasColumnName("PredstavaID");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Ocjenes)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ocjene_Kupci");

                entity.HasOne(d => d.Predstava)
                    .WithMany(p => p.Ocjenes)
                    .HasForeignKey(d => d.PredstavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ocjene_Predstave");
            });

            modelBuilder.Entity<PoslaneObavijesti>(entity =>
            {
                entity.HasKey(e => e.PoslanaObavijestId);

                entity.ToTable("PoslaneObavijesti");

                entity.HasIndex(e => e.KupacId, "IX_PoslaneObavijesti_KupacID");

                entity.HasIndex(e => e.PrestavaId, "IX_PoslaneObavijesti_PrestavaID");

                entity.Property(e => e.PoslanaObavijestId).HasColumnName("PoslanaObavijestID");

                entity.Property(e => e.DatumVazenja).HasColumnType("datetime");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.Poruka)
                    .IsRequired()
                    .IsUnicode(false);

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

                entity.HasIndex(e => e.KupacId, "IX_PostavkeObavijesti_KupacID");

                entity.HasIndex(e => e.TipPredstaveId, "IX_PostavkeObavijesti_TipPredstaveID");

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

                entity.HasIndex(e => e.TipPredstaveId, "IX_Predstave_TipPredstaveID");

                entity.Property(e => e.PredstavaId).HasColumnName("PredstavaID");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Opis).IsUnicode(false);

                entity.Property(e => e.TipPredstaveId).HasColumnName("TipPredstaveID");

                entity.HasOne(d => d.TipPredstave)
                    .WithMany(p => p.Predstaves)
                    .HasForeignKey(d => d.TipPredstaveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Predstave_TipoviPredstava");
            });

            modelBuilder.Entity<PredstaveDjelatnici>(entity =>
            {
                entity.HasKey(e => e.PredstavaDjelatnikId);

                entity.ToTable("PredstaveDjelatnici");

                entity.HasIndex(e => e.DjelatnikId, "IX_PredstaveDjelatnici_DjelatnikID");

                entity.HasIndex(e => e.PredstavaId, "IX_PredstaveDjelatnici_PredstavaID");

                entity.Property(e => e.PredstavaDjelatnikId).HasColumnName("PredstavaDjelatnikID");

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

                entity.HasIndex(e => e.PozoristeId, "IX_Zone_PozoristeID");

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
