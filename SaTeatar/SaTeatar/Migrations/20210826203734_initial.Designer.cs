// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaTeatar.Database;

namespace SaTeatar.Migrations
{
    [DbContext(typeof(SaTeatarBpContext))]
    [Migration("20210826203734_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Latin1_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SaTeatar.Database.Djelatnici", b =>
                {
                    b.Property<int>("DjelatnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DjelatnikID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biografija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("VrstaDjelatnikaId")
                        .HasColumnType("int")
                        .HasColumnName("VrstaDjelatnikaID");

                    b.HasKey("DjelatnikId");

                    b.HasIndex("VrstaDjelatnikaId");

                    b.ToTable("Djelatnici");
                });

            modelBuilder.Entity("SaTeatar.Database.Izvodjenja", b =>
                {
                    b.Property<int>("IzvodjenjeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IzvodjenjeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumVrijeme")
                        .HasColumnType("datetime");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PozoristeId")
                        .HasColumnType("int")
                        .HasColumnName("PozoristeID");

                    b.Property<int>("PredstavaId")
                        .HasColumnType("int")
                        .HasColumnName("PredstavaID");

                    b.HasKey("IzvodjenjeId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("PozoristeId");

                    b.HasIndex("PredstavaId");

                    b.ToTable("Izvodjenja");
                });

            modelBuilder.Entity("SaTeatar.Database.IzvodjenjaZone", b =>
                {
                    b.Property<int>("IzvodjenjeZonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IzvodjenjeZonaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IzvodjenjeId")
                        .HasColumnType("int")
                        .HasColumnName("IzvodjenjeID");

                    b.Property<int>("ZonaId")
                        .HasColumnType("int")
                        .HasColumnName("ZonaID");

                    b.HasKey("IzvodjenjeZonaId");

                    b.HasIndex("IzvodjenjeId");

                    b.HasIndex("ZonaId");

                    b.ToTable("IzvodjenjaZone");
                });

            modelBuilder.Entity("SaTeatar.Database.Karte", b =>
                {
                    b.Property<int>("KartaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KartaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("BrKarte")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("IzvodjenjeId")
                        .HasColumnType("int")
                        .HasColumnName("IzvodjenjeID");

                    b.Property<int>("IzvodjenjeZonaId")
                        .HasColumnType("int")
                        .HasColumnName("IzvodjenjeZonaID");

                    b.Property<int>("KupacId")
                        .HasColumnType("int")
                        .HasColumnName("KupacID");

                    b.Property<bool>("Placeno")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Qrcode")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("QRCode");

                    b.HasKey("KartaId");

                    b.HasIndex("IzvodjenjeId");

                    b.HasIndex("IzvodjenjeZonaId");

                    b.HasIndex("KupacId");

                    b.ToTable("Karte");
                });

            modelBuilder.Entity("SaTeatar.Database.Korisnici", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LozinkaHash")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LozinkaSalt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("KorisnikId");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("SaTeatar.Database.KorisniciUloge", b =>
                {
                    b.Property<int>("KorisnikUlogaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KorisnikUlogaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumIzmjene")
                        .HasColumnType("datetime");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID");

                    b.Property<int>("UlogaId")
                        .HasColumnType("int")
                        .HasColumnName("UlogaID");

                    b.HasKey("KorisnikUlogaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("UlogaId");

                    b.ToTable("KorisniciUloge");
                });

            modelBuilder.Entity("SaTeatar.Database.Kupci", b =>
                {
                    b.Property<int>("KupacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KupacID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRegistracije")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LozinkaHash")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LozinkaSalt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("KupacId");

                    b.ToTable("Kupci");
                });

            modelBuilder.Entity("SaTeatar.Database.Narudzba", b =>
                {
                    b.Property<int>("NarudzbaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NarudzbaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("BrNarudzbe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Iznos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("KupacId")
                        .HasColumnType("int")
                        .HasColumnName("KupacID");

                    b.Property<string>("PaymentId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PaymentID");

                    b.HasKey("NarudzbaId");

                    b.HasIndex("KupacId");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("SaTeatar.Database.NarudzbaStavke", b =>
                {
                    b.Property<int>("NarudzbaStavkeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NarudzbaStavkeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KartaId")
                        .HasColumnType("int")
                        .HasColumnName("KartaID");

                    b.Property<int>("NarudzbaId")
                        .HasColumnType("int")
                        .HasColumnName("NarudzbaID");

                    b.HasKey("NarudzbaStavkeId");

                    b.HasIndex("KartaId");

                    b.HasIndex("NarudzbaId");

                    b.ToTable("NarudzbaStavke");
                });

            modelBuilder.Entity("SaTeatar.Database.Ocjene", b =>
                {
                    b.Property<int>("OcjenaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OcjenaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime");

                    b.Property<int>("KupacId")
                        .HasColumnType("int")
                        .HasColumnName("KupacID");

                    b.Property<int>("Ocjena")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PredstavaId")
                        .HasColumnType("int")
                        .HasColumnName("PredstavaID");

                    b.HasKey("OcjenaId");

                    b.HasIndex("KupacId");

                    b.HasIndex("PredstavaId");

                    b.ToTable("Ocjene");
                });

            modelBuilder.Entity("SaTeatar.Database.PoslaneObavijesti", b =>
                {
                    b.Property<int>("PoslanaObavijestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PoslanaObavijestID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumVazenja")
                        .HasColumnType("datetime");

                    b.Property<int>("KupacId")
                        .HasColumnType("int")
                        .HasColumnName("KupacID");

                    b.Property<string>("Poruka")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int>("PrestavaId")
                        .HasColumnType("int")
                        .HasColumnName("PrestavaID");

                    b.Property<bool>("Procitano")
                        .HasColumnType("bit");

                    b.Property<DateTime>("VrijemeSlanja")
                        .HasColumnType("datetime");

                    b.HasKey("PoslanaObavijestId");

                    b.HasIndex("KupacId");

                    b.HasIndex("PrestavaId");

                    b.ToTable("PoslaneObavijesti");
                });

            modelBuilder.Entity("SaTeatar.Database.PostavkeObavijesti", b =>
                {
                    b.Property<int>("PostavkaObavijestiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PostavkaObavijestiID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KupacId")
                        .HasColumnType("int")
                        .HasColumnName("KupacID");

                    b.Property<int>("TipPredstaveId")
                        .HasColumnType("int")
                        .HasColumnName("TipPredstaveID");

                    b.HasKey("PostavkaObavijestiId");

                    b.HasIndex("KupacId");

                    b.HasIndex("TipPredstaveId");

                    b.ToTable("PostavkeObavijesti");
                });

            modelBuilder.Entity("SaTeatar.Database.Pozorista", b =>
                {
                    b.Property<int>("PozoristeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PozoristeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<byte[]>("Logo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PozoristeId");

                    b.ToTable("Pozorista");
                });

            modelBuilder.Entity("SaTeatar.Database.Predstave", b =>
                {
                    b.Property<int>("PredstavaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PredstavaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Opis")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TipPredstaveId")
                        .HasColumnType("int")
                        .HasColumnName("TipPredstaveID");

                    b.HasKey("PredstavaId");

                    b.HasIndex("TipPredstaveId");

                    b.ToTable("Predstave");
                });

            modelBuilder.Entity("SaTeatar.Database.PredstaveDjelatnici", b =>
                {
                    b.Property<int>("PredstavaDjelatnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PredstavaDjelatnikID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DjelatnikId")
                        .HasColumnType("int")
                        .HasColumnName("DjelatnikID");

                    b.Property<int>("PredstavaId")
                        .HasColumnType("int")
                        .HasColumnName("PredstavaID");

                    b.HasKey("PredstavaDjelatnikId");

                    b.HasIndex("DjelatnikId");

                    b.HasIndex("PredstavaId");

                    b.ToTable("PredstaveDjelatnici");
                });

            modelBuilder.Entity("SaTeatar.Database.TipoviPredstava", b =>
                {
                    b.Property<int>("TipPredstaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TipPredstaveID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("TipPredstaveId");

                    b.ToTable("TipoviPredstava");
                });

            modelBuilder.Entity("SaTeatar.Database.Uloge", b =>
                {
                    b.Property<int>("UlogaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UlogaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Opis")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("UlogaId");

                    b.ToTable("Uloge");
                });

            modelBuilder.Entity("SaTeatar.Database.VrsteDjelatnika", b =>
                {
                    b.Property<int>("VrstaDjelatnikaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VrstaDjelatnikaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("VrstaDjelatnikaId");

                    b.ToTable("VrsteDjelatnika");
                });

            modelBuilder.Entity("SaTeatar.Database.Zone", b =>
                {
                    b.Property<int>("ZonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ZonaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PozoristeId")
                        .HasColumnType("int")
                        .HasColumnName("PozoristeID");

                    b.Property<int>("UkupanBrojSjedista")
                        .HasColumnType("int");

                    b.HasKey("ZonaId");

                    b.HasIndex("PozoristeId");

                    b.ToTable("Zone");
                });

            modelBuilder.Entity("SaTeatar.Database.Djelatnici", b =>
                {
                    b.HasOne("SaTeatar.Database.VrsteDjelatnika", "VrstaDjelatnika")
                        .WithMany("Djelatnicis")
                        .HasForeignKey("VrstaDjelatnikaId")
                        .HasConstraintName("FK_Djelatnici_VrsteDjelatnika")
                        .IsRequired();

                    b.Navigation("VrstaDjelatnika");
                });

            modelBuilder.Entity("SaTeatar.Database.Izvodjenja", b =>
                {
                    b.HasOne("SaTeatar.Database.Korisnici", "Korisnik")
                        .WithMany("Izvodjenjas")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK_Izvodjenja_Korisnici")
                        .IsRequired();

                    b.HasOne("SaTeatar.Database.Pozorista", "Pozoriste")
                        .WithMany("Izvodjenjas")
                        .HasForeignKey("PozoristeId")
                        .HasConstraintName("FK_Izvodjenja_Pozorista")
                        .IsRequired();

                    b.HasOne("SaTeatar.Database.Predstave", "Predstava")
                        .WithMany("Izvodjenjas")
                        .HasForeignKey("PredstavaId")
                        .HasConstraintName("FK_Izvodjenja_Predstave")
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Pozoriste");

                    b.Navigation("Predstava");
                });

            modelBuilder.Entity("SaTeatar.Database.IzvodjenjaZone", b =>
                {
                    b.HasOne("SaTeatar.Database.Izvodjenja", "Izvodjenje")
                        .WithMany("IzvodjenjaZones")
                        .HasForeignKey("IzvodjenjeId")
                        .HasConstraintName("FK_IzvodjenjaZone_Izvodjenja")
                        .IsRequired();

                    b.HasOne("SaTeatar.Database.Zone", "Zona")
                        .WithMany("IzvodjenjaZones")
                        .HasForeignKey("ZonaId")
                        .HasConstraintName("FK_IzvodjenjaZone_Zone")
                        .IsRequired();

                    b.Navigation("Izvodjenje");

                    b.Navigation("Zona");
                });

            modelBuilder.Entity("SaTeatar.Database.Karte", b =>
                {
                    b.HasOne("SaTeatar.Database.Izvodjenja", "Izvodjenje")
                        .WithMany("Kartes")
                        .HasForeignKey("IzvodjenjeId")
                        .HasConstraintName("FK_Karte_Izvodjenja")
                        .IsRequired();

                    b.HasOne("SaTeatar.Database.IzvodjenjaZone", "IzvodjenjeZona")
                        .WithMany("Kartes")
                        .HasForeignKey("IzvodjenjeZonaId")
                        .HasConstraintName("FK_Karte_IzvodjenjaZone")
                        .IsRequired();

                    b.HasOne("SaTeatar.Database.Kupci", "Kupac")
                        .WithMany("Kartes")
                        .HasForeignKey("KupacId")
                        .HasConstraintName("FK_Karte_Kupci")
                        .IsRequired();

                    b.Navigation("Izvodjenje");

                    b.Navigation("IzvodjenjeZona");

                    b.Navigation("Kupac");
                });

            modelBuilder.Entity("SaTeatar.Database.KorisniciUloge", b =>
                {
                    b.HasOne("SaTeatar.Database.Korisnici", "Korisnik")
                        .WithMany("KorisniciUloges")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK_KorisniciUloge_Korisnici")
                        .IsRequired();

                    b.HasOne("SaTeatar.Database.Uloge", "Uloga")
                        .WithMany("KorisniciUloges")
                        .HasForeignKey("UlogaId")
                        .HasConstraintName("FK_KorisniciUloge_Uloge")
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Uloga");
                });

            modelBuilder.Entity("SaTeatar.Database.Narudzba", b =>
                {
                    b.HasOne("SaTeatar.Database.Kupci", "Kupac")
                        .WithMany("Narudzbas")
                        .HasForeignKey("KupacId")
                        .HasConstraintName("FK_Narudzba_Kupci")
                        .IsRequired();

                    b.Navigation("Kupac");
                });

            modelBuilder.Entity("SaTeatar.Database.NarudzbaStavke", b =>
                {
                    b.HasOne("SaTeatar.Database.Karte", "Karta")
                        .WithMany("NarudzbaStavkes")
                        .HasForeignKey("KartaId")
                        .HasConstraintName("FK_NarudzbaStavke_Karte")
                        .IsRequired();

                    b.HasOne("SaTeatar.Database.Narudzba", "Narudzba")
                        .WithMany("NarudzbaStavkes")
                        .HasForeignKey("NarudzbaId")
                        .HasConstraintName("FK_NarudzbaStavke_Narudzba")
                        .IsRequired();

                    b.Navigation("Karta");

                    b.Navigation("Narudzba");
                });

            modelBuilder.Entity("SaTeatar.Database.Ocjene", b =>
                {
                    b.HasOne("SaTeatar.Database.Kupci", "Kupac")
                        .WithMany("Ocjenes")
                        .HasForeignKey("KupacId")
                        .HasConstraintName("FK_Ocjene_Kupci")
                        .IsRequired();

                    b.HasOne("SaTeatar.Database.Predstave", "Predstava")
                        .WithMany("Ocjenes")
                        .HasForeignKey("PredstavaId")
                        .HasConstraintName("FK_Ocjene_Predstave")
                        .IsRequired();

                    b.Navigation("Kupac");

                    b.Navigation("Predstava");
                });

            modelBuilder.Entity("SaTeatar.Database.PoslaneObavijesti", b =>
                {
                    b.HasOne("SaTeatar.Database.Kupci", "Kupac")
                        .WithMany("PoslaneObavijestis")
                        .HasForeignKey("KupacId")
                        .HasConstraintName("FK_PoslaneObavijesti_Kupci")
                        .IsRequired();

                    b.HasOne("SaTeatar.Database.Predstave", "Prestava")
                        .WithMany("PoslaneObavijestis")
                        .HasForeignKey("PrestavaId")
                        .HasConstraintName("FK_PoslaneObavijesti_Predstave")
                        .IsRequired();

                    b.Navigation("Kupac");

                    b.Navigation("Prestava");
                });

            modelBuilder.Entity("SaTeatar.Database.PostavkeObavijesti", b =>
                {
                    b.HasOne("SaTeatar.Database.Kupci", "Kupac")
                        .WithMany("PostavkeObavijestis")
                        .HasForeignKey("KupacId")
                        .HasConstraintName("FK_PostavkeObavijesti_Kupci")
                        .IsRequired();

                    b.HasOne("SaTeatar.Database.TipoviPredstava", "TipPredstave")
                        .WithMany("PostavkeObavijestis")
                        .HasForeignKey("TipPredstaveId")
                        .HasConstraintName("FK_PostavkeObavijesti_TipoviPredstava")
                        .IsRequired();

                    b.Navigation("Kupac");

                    b.Navigation("TipPredstave");
                });

            modelBuilder.Entity("SaTeatar.Database.Predstave", b =>
                {
                    b.HasOne("SaTeatar.Database.TipoviPredstava", "TipPredstave")
                        .WithMany("Predstaves")
                        .HasForeignKey("TipPredstaveId")
                        .HasConstraintName("FK_Predstave_TipoviPredstava")
                        .IsRequired();

                    b.Navigation("TipPredstave");
                });

            modelBuilder.Entity("SaTeatar.Database.PredstaveDjelatnici", b =>
                {
                    b.HasOne("SaTeatar.Database.Djelatnici", "Djelatnik")
                        .WithMany("PredstaveDjelatnicis")
                        .HasForeignKey("DjelatnikId")
                        .HasConstraintName("FK_PredstaveDjelatnici_Djelatnici")
                        .IsRequired();

                    b.HasOne("SaTeatar.Database.Predstave", "Predstava")
                        .WithMany("PredstaveDjelatnicis")
                        .HasForeignKey("PredstavaId")
                        .HasConstraintName("FK_PredstaveDjelatnici_Predstave")
                        .IsRequired();

                    b.Navigation("Djelatnik");

                    b.Navigation("Predstava");
                });

            modelBuilder.Entity("SaTeatar.Database.Zone", b =>
                {
                    b.HasOne("SaTeatar.Database.Pozorista", "Pozoriste")
                        .WithMany("Zones")
                        .HasForeignKey("PozoristeId")
                        .HasConstraintName("FK_Zone_Pozorista")
                        .IsRequired();

                    b.Navigation("Pozoriste");
                });

            modelBuilder.Entity("SaTeatar.Database.Djelatnici", b =>
                {
                    b.Navigation("PredstaveDjelatnicis");
                });

            modelBuilder.Entity("SaTeatar.Database.Izvodjenja", b =>
                {
                    b.Navigation("IzvodjenjaZones");

                    b.Navigation("Kartes");
                });

            modelBuilder.Entity("SaTeatar.Database.IzvodjenjaZone", b =>
                {
                    b.Navigation("Kartes");
                });

            modelBuilder.Entity("SaTeatar.Database.Karte", b =>
                {
                    b.Navigation("NarudzbaStavkes");
                });

            modelBuilder.Entity("SaTeatar.Database.Korisnici", b =>
                {
                    b.Navigation("Izvodjenjas");

                    b.Navigation("KorisniciUloges");
                });

            modelBuilder.Entity("SaTeatar.Database.Kupci", b =>
                {
                    b.Navigation("Kartes");

                    b.Navigation("Narudzbas");

                    b.Navigation("Ocjenes");

                    b.Navigation("PoslaneObavijestis");

                    b.Navigation("PostavkeObavijestis");
                });

            modelBuilder.Entity("SaTeatar.Database.Narudzba", b =>
                {
                    b.Navigation("NarudzbaStavkes");
                });

            modelBuilder.Entity("SaTeatar.Database.Pozorista", b =>
                {
                    b.Navigation("Izvodjenjas");

                    b.Navigation("Zones");
                });

            modelBuilder.Entity("SaTeatar.Database.Predstave", b =>
                {
                    b.Navigation("Izvodjenjas");

                    b.Navigation("Ocjenes");

                    b.Navigation("PoslaneObavijestis");

                    b.Navigation("PredstaveDjelatnicis");
                });

            modelBuilder.Entity("SaTeatar.Database.TipoviPredstava", b =>
                {
                    b.Navigation("PostavkeObavijestis");

                    b.Navigation("Predstaves");
                });

            modelBuilder.Entity("SaTeatar.Database.Uloge", b =>
                {
                    b.Navigation("KorisniciUloges");
                });

            modelBuilder.Entity("SaTeatar.Database.VrsteDjelatnika", b =>
                {
                    b.Navigation("Djelatnicis");
                });

            modelBuilder.Entity("SaTeatar.Database.Zone", b =>
                {
                    b.Navigation("IzvodjenjaZones");
                });
#pragma warning restore 612, 618
        }
    }
}
