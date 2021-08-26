using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaTeatar.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LozinkaHash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.KorisnikID);
                });

            migrationBuilder.CreateTable(
                name: "Kupci",
                columns: table => new
                {
                    KupacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LozinkaHash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatumRegistracije = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupci", x => x.KupacID);
                });

            migrationBuilder.CreateTable(
                name: "Pozorista",
                columns: table => new
                {
                    PozoristeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozorista", x => x.PozoristeID);
                });

            migrationBuilder.CreateTable(
                name: "TipoviPredstava",
                columns: table => new
                {
                    TipPredstaveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoviPredstava", x => x.TipPredstaveID);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    UlogaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.UlogaID);
                });

            migrationBuilder.CreateTable(
                name: "VrsteDjelatnika",
                columns: table => new
                {
                    VrstaDjelatnikaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrsteDjelatnika", x => x.VrstaDjelatnikaID);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    NarudzbaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: false),
                    Iznos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BrNarudzbe = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.NarudzbaID);
                    table.ForeignKey(
                        name: "FK_Narudzba_Kupci",
                        column: x => x.KupacID,
                        principalTable: "Kupci",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    ZonaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PozoristeID = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UkupanBrojSjedista = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.ZonaID);
                    table.ForeignKey(
                        name: "FK_Zone_Pozorista",
                        column: x => x.PozoristeID,
                        principalTable: "Pozorista",
                        principalColumn: "PozoristeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostavkeObavijesti",
                columns: table => new
                {
                    PostavkaObavijestiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    TipPredstaveID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostavkeObavijesti", x => x.PostavkaObavijestiID);
                    table.ForeignKey(
                        name: "FK_PostavkeObavijesti_Kupci",
                        column: x => x.KupacID,
                        principalTable: "Kupci",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostavkeObavijesti_TipoviPredstava",
                        column: x => x.TipPredstaveID,
                        principalTable: "TipoviPredstava",
                        principalColumn: "TipPredstaveID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Predstave",
                columns: table => new
                {
                    PredstavaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Opis = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TipPredstaveID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predstave", x => x.PredstavaID);
                    table.ForeignKey(
                        name: "FK_Predstave_TipoviPredstava",
                        column: x => x.TipPredstaveID,
                        principalTable: "TipoviPredstava",
                        principalColumn: "TipPredstaveID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorisniciUloge",
                columns: table => new
                {
                    KorisnikUlogaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    UlogaID = table.Column<int>(type: "int", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciUloge", x => x.KorisnikUlogaID);
                    table.ForeignKey(
                        name: "FK_KorisniciUloge_Korisnici",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KorisniciUloge_Uloge",
                        column: x => x.UlogaID,
                        principalTable: "Uloge",
                        principalColumn: "UlogaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Djelatnici",
                columns: table => new
                {
                    DjelatnikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Biografija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    VrstaDjelatnikaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Djelatnici", x => x.DjelatnikID);
                    table.ForeignKey(
                        name: "FK_Djelatnici_VrsteDjelatnika",
                        column: x => x.VrstaDjelatnikaID,
                        principalTable: "VrsteDjelatnika",
                        principalColumn: "VrstaDjelatnikaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Izvodjenja",
                columns: table => new
                {
                    IzvodjenjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PredstavaID = table.Column<int>(type: "int", nullable: false),
                    PozoristeID = table.Column<int>(type: "int", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    DatumVrijeme = table.Column<DateTime>(type: "datetime", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvodjenja", x => x.IzvodjenjeID);
                    table.ForeignKey(
                        name: "FK_Izvodjenja_Korisnici",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Izvodjenja_Pozorista",
                        column: x => x.PozoristeID,
                        principalTable: "Pozorista",
                        principalColumn: "PozoristeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Izvodjenja_Predstave",
                        column: x => x.PredstavaID,
                        principalTable: "Predstave",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ocjene",
                columns: table => new
                {
                    OcjenaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    PredstavaID = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ocjena = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjene", x => x.OcjenaID);
                    table.ForeignKey(
                        name: "FK_Ocjene_Kupci",
                        column: x => x.KupacID,
                        principalTable: "Kupci",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ocjene_Predstave",
                        column: x => x.PredstavaID,
                        principalTable: "Predstave",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PoslaneObavijesti",
                columns: table => new
                {
                    PoslanaObavijestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    PrestavaID = table.Column<int>(type: "int", nullable: false),
                    VrijemeSlanja = table.Column<DateTime>(type: "datetime", nullable: false),
                    Poruka = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Procitano = table.Column<bool>(type: "bit", nullable: false),
                    DatumVazenja = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoslaneObavijesti", x => x.PoslanaObavijestID);
                    table.ForeignKey(
                        name: "FK_PoslaneObavijesti_Kupci",
                        column: x => x.KupacID,
                        principalTable: "Kupci",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoslaneObavijesti_Predstave",
                        column: x => x.PrestavaID,
                        principalTable: "Predstave",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PredstaveDjelatnici",
                columns: table => new
                {
                    PredstavaDjelatnikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PredstavaID = table.Column<int>(type: "int", nullable: false),
                    DjelatnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredstaveDjelatnici", x => x.PredstavaDjelatnikID);
                    table.ForeignKey(
                        name: "FK_PredstaveDjelatnici_Djelatnici",
                        column: x => x.DjelatnikID,
                        principalTable: "Djelatnici",
                        principalColumn: "DjelatnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PredstaveDjelatnici_Predstave",
                        column: x => x.PredstavaID,
                        principalTable: "Predstave",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IzvodjenjaZone",
                columns: table => new
                {
                    IzvodjenjeZonaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IzvodjenjeID = table.Column<int>(type: "int", nullable: false),
                    ZonaID = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzvodjenjaZone", x => x.IzvodjenjeZonaID);
                    table.ForeignKey(
                        name: "FK_IzvodjenjaZone_Izvodjenja",
                        column: x => x.IzvodjenjeID,
                        principalTable: "Izvodjenja",
                        principalColumn: "IzvodjenjeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IzvodjenjaZone_Zone",
                        column: x => x.ZonaID,
                        principalTable: "Zone",
                        principalColumn: "ZonaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Karte",
                columns: table => new
                {
                    KartaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    IzvodjenjeID = table.Column<int>(type: "int", nullable: false),
                    Placeno = table.Column<bool>(type: "bit", nullable: false),
                    IzvodjenjeZonaID = table.Column<int>(type: "int", nullable: false),
                    QRCode = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    BrKarte = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karte", x => x.KartaID);
                    table.ForeignKey(
                        name: "FK_Karte_Izvodjenja",
                        column: x => x.IzvodjenjeID,
                        principalTable: "Izvodjenja",
                        principalColumn: "IzvodjenjeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Karte_IzvodjenjaZone",
                        column: x => x.IzvodjenjeZonaID,
                        principalTable: "IzvodjenjaZone",
                        principalColumn: "IzvodjenjeZonaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Karte_Kupci",
                        column: x => x.KupacID,
                        principalTable: "Kupci",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaStavke",
                columns: table => new
                {
                    NarudzbaStavkeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarudzbaID = table.Column<int>(type: "int", nullable: false),
                    KartaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaStavke", x => x.NarudzbaStavkeID);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavke_Karte",
                        column: x => x.KartaID,
                        principalTable: "Karte",
                        principalColumn: "KartaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavke_Narudzba",
                        column: x => x.NarudzbaID,
                        principalTable: "Narudzba",
                        principalColumn: "NarudzbaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Djelatnici_VrstaDjelatnikaID",
                table: "Djelatnici",
                column: "VrstaDjelatnikaID");

            migrationBuilder.CreateIndex(
                name: "IX_Izvodjenja_KorisnikID",
                table: "Izvodjenja",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Izvodjenja_PozoristeID",
                table: "Izvodjenja",
                column: "PozoristeID");

            migrationBuilder.CreateIndex(
                name: "IX_Izvodjenja_PredstavaID",
                table: "Izvodjenja",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_IzvodjenjaZone_IzvodjenjeID",
                table: "IzvodjenjaZone",
                column: "IzvodjenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_IzvodjenjaZone_ZonaID",
                table: "IzvodjenjaZone",
                column: "ZonaID");

            migrationBuilder.CreateIndex(
                name: "IX_Karte_IzvodjenjeID",
                table: "Karte",
                column: "IzvodjenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Karte_IzvodjenjeZonaID",
                table: "Karte",
                column: "IzvodjenjeZonaID");

            migrationBuilder.CreateIndex(
                name: "IX_Karte_KupacID",
                table: "Karte",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_KorisnikID",
                table: "KorisniciUloge",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_UlogaID",
                table: "KorisniciUloge",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_KupacID",
                table: "Narudzba",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavke_KartaID",
                table: "NarudzbaStavke",
                column: "KartaID");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavke_NarudzbaID",
                table: "NarudzbaStavke",
                column: "NarudzbaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_KupacID",
                table: "Ocjene",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_PredstavaID",
                table: "Ocjene",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_PoslaneObavijesti_KupacID",
                table: "PoslaneObavijesti",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_PoslaneObavijesti_PrestavaID",
                table: "PoslaneObavijesti",
                column: "PrestavaID");

            migrationBuilder.CreateIndex(
                name: "IX_PostavkeObavijesti_KupacID",
                table: "PostavkeObavijesti",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_PostavkeObavijesti_TipPredstaveID",
                table: "PostavkeObavijesti",
                column: "TipPredstaveID");

            migrationBuilder.CreateIndex(
                name: "IX_Predstave_TipPredstaveID",
                table: "Predstave",
                column: "TipPredstaveID");

            migrationBuilder.CreateIndex(
                name: "IX_PredstaveDjelatnici_DjelatnikID",
                table: "PredstaveDjelatnici",
                column: "DjelatnikID");

            migrationBuilder.CreateIndex(
                name: "IX_PredstaveDjelatnici_PredstavaID",
                table: "PredstaveDjelatnici",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Zone_PozoristeID",
                table: "Zone",
                column: "PozoristeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisniciUloge");

            migrationBuilder.DropTable(
                name: "NarudzbaStavke");

            migrationBuilder.DropTable(
                name: "Ocjene");

            migrationBuilder.DropTable(
                name: "PoslaneObavijesti");

            migrationBuilder.DropTable(
                name: "PostavkeObavijesti");

            migrationBuilder.DropTable(
                name: "PredstaveDjelatnici");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "Karte");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Djelatnici");

            migrationBuilder.DropTable(
                name: "IzvodjenjaZone");

            migrationBuilder.DropTable(
                name: "Kupci");

            migrationBuilder.DropTable(
                name: "VrsteDjelatnika");

            migrationBuilder.DropTable(
                name: "Izvodjenja");

            migrationBuilder.DropTable(
                name: "Zone");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Predstave");

            migrationBuilder.DropTable(
                name: "Pozorista");

            migrationBuilder.DropTable(
                name: "TipoviPredstava");
        }
    }
}
