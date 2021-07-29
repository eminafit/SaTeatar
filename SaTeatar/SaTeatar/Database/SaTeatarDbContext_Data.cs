using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.Database
{
    public partial class SaTeatarDbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uloge>().HasData(new Uloge() { UlogaId = 1, Naziv = "Administrator", Opis = "" });
            modelBuilder.Entity<Uloge>().HasData(new Uloge() { UlogaId = 2, Naziv = "Moderator", Opis = "" });

            modelBuilder.Entity<Korisnici>().HasData(new Korisnici()
            {
                KorisnikId=1,
                Ime = "Desktop",
                Prezime = "Desktopic",
                KorisnickoIme = "desktop",
                Email = "desktop@gmail.com",
                LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                Status = true
            });

            modelBuilder.Entity<Korisnici>().HasData(new Korisnici()
            {
                KorisnikId=2,
                Ime = "Moderator Prvi",
                Prezime = "Moderatoric",
                KorisnickoIme = "moderator",
                Email = "moderator@gmail.com",
                LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                Status = true
            });

            modelBuilder.Entity<Korisnici>().HasData(new Korisnici()
            {
                KorisnikId=3,
                Ime = "Moderator Drugi",
                Prezime = "Moderatoric",
                KorisnickoIme = "moderator",
                Email = "moderator@gmail.com",
                LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                Status = true
            });

            //#1 mobile
            modelBuilder.Entity<Kupci>().HasData(new Kupci()
            {
                KupacId=1,
                Ime = "Mobilni",
                Prezime = "Mobilovic",
                KorisnickoIme = "mobile",
                DatumRegistracije = new DateTime(2021, 5, 2, 8, 0, 0),
                Email = "mobilni@gmail.com",
                Status = true,
                LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
            });

            //#2 Pero Peric
            modelBuilder.Entity<Kupci>().HasData(new Kupci()
            {
                KupacId=2,
                Ime = "Pero",
                Prezime = "Peric",
                KorisnickoIme = "pero.peric",
                DatumRegistracije = new DateTime(2021, 5, 20, 8, 0, 0),
                Email = "pero@gmail.com",
                Status = true,
                LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
            });

            //#3 Mare Maric
            modelBuilder.Entity<Kupci>().HasData(new Kupci()
            {
                KupacId=3,
                Ime = "Mare",
                Prezime = "Maric",
                KorisnickoIme = "mare.maric",
                DatumRegistracije = new DateTime(2021, 5, 20, 9, 0, 0),
                Email = "mare@gmail.com",
                Status = true,
                LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
            });

            //#4 Niko Nikic
            modelBuilder.Entity<Kupci>().HasData(new Kupci()
            {
                KupacId=4,
                Ime = "Niko",
                Prezime = "Nikic",
                KorisnickoIme = "niko.nikic",
                DatumRegistracije = new DateTime(2021, 5, 20, 9, 30, 0),
                Email = "niko@gmail.com",
                Status = true,
                LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
            });

            //#5 Luka Lukic
            modelBuilder.Entity<Kupci>().HasData(new Kupci()
            {
                KupacId=5,
                Ime = "Luka",
                Prezime = "Lukic",
                KorisnickoIme = "luka.lukic",
                DatumRegistracije = new DateTime(2021, 5, 20, 10, 0, 0),
                Email = "luka@gmail.com",
                Status = true,
                LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
            });

            //#6 Tin Tinovic
            modelBuilder.Entity<Kupci>().HasData(new Kupci()
            {
                KupacId=6,
                Ime = "Tin",
                Prezime = "Tinovic",
                KorisnickoIme = "tin.tinovic",
                DatumRegistracije = new DateTime(2021, 5, 20, 11, 0, 0),
                Email = "tin@gmail.com",
                Status = true,
                LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
            });

            //#7 Boro Boric
            modelBuilder.Entity<Kupci>().HasData(new Kupci()
            {
                KupacId=7,
                Ime = "Boro",
                Prezime = "Boric",
                KorisnickoIme = "boro.boric",
                DatumRegistracije = new DateTime(2021, 5, 20, 12, 0, 0),
                Email = "boro@gmail.com",
                Status = true,
                LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
            });

            //#8 Drago Dragic
            modelBuilder.Entity<Kupci>().HasData(new Kupci()
            {
                KupacId=8,
                Ime = "Drago",
                Prezime = "Dragic",
                KorisnickoIme = "drago.dragic",
                DatumRegistracije = new DateTime(2021, 5, 20, 13, 0, 0),
                Email = "drago@gmail.com",
                Status = true,
                LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
            });

            //#9 Ljubo Ljubic
            modelBuilder.Entity<Kupci>().HasData(new Kupci()
            {
                KupacId=9,
                Ime = "Ljubo",
                Prezime = "Ljubic",
                KorisnickoIme = "ljubo.ljubic",
                DatumRegistracije = new DateTime(2021, 5, 20, 14, 0, 0),
                Email = "ljubo@gmail.com",
                Status = true,
                LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
            });

            //#10 Aleks Aleksic
            modelBuilder.Entity<Kupci>().HasData(new Kupci()
            {
                KupacId=10,
                Ime = "Aleks",
                Prezime = "Aleksic",
                KorisnickoIme = "aleks.aleksic",
                DatumRegistracije = new DateTime(2021, 5, 20, 15, 0, 0),
                Email = "aleks.aleksic@gmail.com",
                Status = true,
                LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
            });

            //#1 Kamerni teatar 55
            modelBuilder.Entity<Pozorista>().HasData(new Pozorista()
            {
                PozoristeId=1,
                Naziv = "Kamerni teatar 55",
                Adresa = "Maršala Tita 56/II",
                Logo = File.ReadAllBytes("Images/pozorista/kt55logo.jpg")
            });

            //#2 Narodno pozoriste Sarajevo
            modelBuilder.Entity<Pozorista>().HasData(new Pozorista()
            {
                PozoristeId=2,
                Naziv = "Narodno pozoriste Sarajevo",
                Adresa = "Obala Kulina bana 9",
                Logo = File.ReadAllBytes("Images/pozorista/nps.jpg")
            });

            //#3 Sartr
            modelBuilder.Entity<Pozorista>().HasData(new Pozorista()
            {
                PozoristeId=3,
                Naziv = "Sartr",
                Adresa = "Gabelina 16",
                Logo = File.ReadAllBytes("Images/pozorista/sartr.jpg")
            });

            //#4 Pozoriste mladih Sarajevo
            modelBuilder.Entity<Pozorista>().HasData(new Pozorista()
            {
                PozoristeId=4,
                Naziv = "Pozoriste mladih Sarajevo",
                Adresa = "Kulovica 8",
                Logo = File.ReadAllBytes("Images/pozorista/pms.jpg")
            });

            modelBuilder.Entity<TipoviPredstava>().HasData(new TipoviPredstava() { TipPredstaveId=1, Naziv = "Drama" });
            modelBuilder.Entity<TipoviPredstava>().HasData(new TipoviPredstava() { TipPredstaveId=2, Naziv = "Balet" });
            modelBuilder.Entity<TipoviPredstava>().HasData(new TipoviPredstava() { TipPredstaveId=3, Naziv = "Opera" });

            modelBuilder.Entity<VrsteDjelatnika>().HasData(new VrsteDjelatnika() { VrstaDjelatnikaId=1, Naziv = "Reziser" });
            modelBuilder.Entity<VrsteDjelatnika>().HasData(new VrsteDjelatnika() { VrstaDjelatnikaId=2, Naziv = "Gumac" });
            modelBuilder.Entity<VrsteDjelatnika>().HasData(new VrsteDjelatnika() { VrstaDjelatnikaId=3, Naziv = "Koreograf" });

            modelBuilder.Entity<KorisniciUloge>().HasData(new KorisniciUloge() {KorisnikUlogaId=1, KorisnikId = 1, UlogaId = 1, DatumIzmjene = new DateTime(2021, 5, 1, 8, 0, 0) });
            modelBuilder.Entity<KorisniciUloge>().HasData(new KorisniciUloge() {KorisnikUlogaId=2, KorisnikId = 2, UlogaId = 2, DatumIzmjene = new DateTime(2021, 5, 1, 9, 0, 0) });
            modelBuilder.Entity<KorisniciUloge>().HasData(new KorisniciUloge() {KorisnikUlogaId =3, KorisnikId = 3, UlogaId = 2, DatumIzmjene = new DateTime(2021, 5, 1, 10, 0, 0) });

            //#1 Kamerni teatar 55
            modelBuilder.Entity<Zone>().HasData(new Zone() { ZonaId=1, Naziv = "Zona A", PozoristeId = 1, UkupanBrojSjedista = 15 });
            modelBuilder.Entity<Zone>().HasData(new Zone() { ZonaId=2, Naziv = "Zona B", PozoristeId = 1, UkupanBrojSjedista = 45 });
            modelBuilder.Entity<Zone>().HasData(new Zone() { ZonaId=3, Naziv = "Zona C", PozoristeId = 1, UkupanBrojSjedista = 135 });

            //#2 Narodno pozoriste Sarajevo
            modelBuilder.Entity<Zone>().HasData(new Zone() { ZonaId=4, Naziv = "VIP", PozoristeId = 2, UkupanBrojSjedista = 15 });
            modelBuilder.Entity<Zone>().HasData(new Zone() { ZonaId=5, Naziv = "Zona A", PozoristeId = 2, UkupanBrojSjedista = 30 });
            modelBuilder.Entity<Zone>().HasData(new Zone() { ZonaId=6, Naziv = "Zona B", PozoristeId = 2, UkupanBrojSjedista = 90 });
            modelBuilder.Entity<Zone>().HasData(new Zone() { ZonaId=7, Naziv = "Zona C", PozoristeId = 2, UkupanBrojSjedista = 180 });

            //#3 Sartr
            modelBuilder.Entity<Zone>().HasData(new Zone() { ZonaId=8, Naziv = "Zona A", PozoristeId = 3, UkupanBrojSjedista = 10 });
            modelBuilder.Entity<Zone>().HasData(new Zone() { ZonaId=9, Naziv = "Zona B", PozoristeId = 3, UkupanBrojSjedista = 30 });
            modelBuilder.Entity<Zone>().HasData(new Zone() { ZonaId=10, Naziv = "Zona C", PozoristeId = 3, UkupanBrojSjedista = 40 });

            //#4 Pozoriste mladih Sarajevo
            modelBuilder.Entity<Zone>().HasData(new Zone() { ZonaId=11, Naziv = "Zona A", PozoristeId = 4, UkupanBrojSjedista = 20 });
            modelBuilder.Entity<Zone>().HasData(new Zone() { ZonaId=12, Naziv = "Zona A", PozoristeId = 4, UkupanBrojSjedista = 40 });
            modelBuilder.Entity<Zone>().HasData(new Zone() { ZonaId=13, Naziv = "Zona A", PozoristeId = 4, UkupanBrojSjedista = 120 });

            //#1 Helverova noc
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=1,
                Naziv = "Helverova noc",
                Opis = "...",
                Status = true,
                TipPredstaveId = 1,
                Slika = File.ReadAllBytes("Images/predstave/helverova_noc.jpg")
            });
            //#2 Mirna Bosna
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=2,
                Naziv = "Mirna Bosna",
                Opis = "...",
                Status = true,
                TipPredstaveId = 1,
                Slika = File.ReadAllBytes("Images/predstave/mirna_bosna.jpg")
            });
            //#3 Knjiga mojih zivota
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=3,
                Naziv = "Knjiga mojih zivota",
                Opis = "...",
                Status = true,
                TipPredstaveId = 1,
                Slika = File.ReadAllBytes("Images/predstave/knjiga_mojih_zivota.jpg")
            });
            //#4 Tajna dzema od malina
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=4,
                Naziv = "Tajna dzema od malina",
                Opis = "...",
                Status = true,
                TipPredstaveId = 1,
                Slika = File.ReadAllBytes("Images/predstave/Tajna_dzema_od_malina.jpg")
            });
            //#5 Ay Carmela
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=5,
                Naziv = "Ay, Carmela",
                Opis = "...",
                Status = false,
                TipPredstaveId = 1,
                Slika = File.ReadAllBytes("Images/predstave/ay_carmela.jpg")
            });
            //#6 Dogville
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=6,
                Naziv = "Dogville",
                Opis = "...",
                Status = true,
                TipPredstaveId = 1,
                Slika = File.ReadAllBytes("Images/predstave/Dogville.jpg")
            });
            //#7 Snijeg
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=7,
                Naziv = "Snijeg",
                Opis = "...",
                Status = true,
                TipPredstaveId = 1,
                Slika = File.ReadAllBytes("Images/predstave/Snijeg.jpg")
            });
            //#8 Princeza na zrnu graska
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=8,
                Naziv = "Princeza na zrnu graska",
                Opis = "...",
                Status = true,
                TipPredstaveId = 1,
                Slika = File.ReadAllBytes("Images/predstave/Princeza_na_zrnu_graska.jpg")
            });
            //#9 Zaljubljeni krokodil
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=9,
                Naziv = "Zaljubljeni krokodil",
                Opis = "...",
                Status = true,
                TipPredstaveId = 1,
                Slika = File.ReadAllBytes("Images/predstave/Zaljubljeni_krokodil.jpg")
            });
            //#10 Patkica Blatkica
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=10,
                Naziv = "Patkica Blatkica",
                Opis = "...",
                Status = true,
                TipPredstaveId = 1,
                Slika = File.ReadAllBytes("Images/predstave/Patkica_Blatkica.jpg")
            });
            //#11 Okovani prometej
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=11,
                Naziv = "Okovani prometej",
                Opis = "...",
                Status = true,
                TipPredstaveId = 2,
                Slika = File.ReadAllBytes("Images/predstave/Okovani_prometej.jpg")
            });
            //#12 Palcica
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=12,
                Naziv = "Palcica",
                Opis = "...",
                Status = true,
                TipPredstaveId = 2,
                Slika = File.ReadAllBytes("Images/predstave/Palcica.jpg")
            });
            //#13 Uspavana ljepotica
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=13,
                Naziv = "Uspavana ljepotica",
                Opis = "...",
                Status = true,
                TipPredstaveId = 2,
                Slika = File.ReadAllBytes("Images/predstave/Uspavana_ljepotica.jpg")
            });
            //#14 La Traviata
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=14,
                Naziv = "La Traviata",
                Opis = "...",
                Status = true,
                TipPredstaveId = 3,
                Slika = File.ReadAllBytes("Images/predstave/La_Traviata.jpg")
            });
            //#15 Don Giovanni
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=15,
                Naziv = "Don Giovanni",
                Opis = "...",
                Status = true,
                TipPredstaveId = 3,
                Slika = File.ReadAllBytes("Images/predstave/Don_Giovanni.jpg")
            });
            //#16 Rigoletto
            modelBuilder.Entity<Predstave>().HasData(new Predstave()
            {
                PredstavaId=16,
                Naziv = "Rigoletto",
                Opis = "...",
                Status = true,
                TipPredstaveId = 3,
                Slika = File.ReadAllBytes("Images/predstave/Rigoletto.jpg")
            });

            //#1 Dino Mustafic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=1,
                Ime = "Dino",
                Prezime = "Mustafic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 1,
                Slika = File.ReadAllBytes("Images/djelatnici/dino_mustafic.jpg")
            });
            //#2 Mirjana Karanovic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=2,
                Ime = "Mirjana",
                Prezime = "Karanovic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/Mirjana_Karanovic.jpg")
            });
            //#3 Ermin Bravo
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=3,
                Ime = "Ermin",
                Prezime = "Bravo",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/ermin_bravo.jpg")
            });
            //#4 Sasa Pesevski
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=4,
                Ime = "Sasa",
                Prezime = "Pesevski",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 1,
                Slika = File.ReadAllBytes("Images/djelatnici/sasa_pesevski.jpg")
            });
            //#5 Fedja Stukan
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=5,
                Ime = "Fedja",
                Prezime = "Stukan",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#6 Gordana Boban
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=6,
                Ime = "Gordana",
                Prezime = "Boban",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#7 Sabrina Begovic Coric
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=7,
                Ime = "Sabrina",
                Prezime = "Begovic Coric",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 1,
                Slika = File.ReadAllBytes("Images/djelatnici/sabrina_begovic_coric.jpg")
            });
            //#8 Boris Ler
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=8,
                Ime = "Boris",
                Prezime = "Ler",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#9 Maja Izetbegovic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=9,
                Ime = "Maja",
                Prezime = "Izetbegovic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#10 Selma Spahic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=10,
                Ime = "Selma",
                Prezime = "Spahic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 1,
                Slika = File.ReadAllBytes("Images/djelatnici/selma_spahic.jpg")
            });
            //#11 Snjezana Alic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=11,
                Ime = "Snjezana",
                Prezime = "Alic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#12 Alban Ukaj
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=12,
                Ime = "Alban",
                Prezime = "Ukaj",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#13 Robert Raponja
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=13,
                Ime = "Robert",
                Prezime = "Raponja",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 1,
                Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
            });
            //#14 Selma Alispahic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=14,
                Ime = "Selma",
                Prezime = "Alispahic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#15 Dragan Jovicic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=15,
                Ime = "Dragan",
                Prezime = "Jovicic",
                Biografija = "...",
                Status = false,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#16 Lajla Kaikcija
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=16,
                Ime = "Lajla",
                Prezime = "Kaikcija",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 1,
                Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
            });
            //#17 Amra Kapidzic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=17,
                Ime = "Amra",
                Prezime = "Kapidzic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#18 Ermin Sijamija
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=18,
                Ime = "Ermin",
                Prezime = "Sijamija",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#19 Aleksandar Seksan
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=19,
                Ime = "Aleksandar",
                Prezime = "Seksan",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#20 Daniela Gogic 
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=20,
                Ime = "Daniela",
                Prezime = "Gogic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 1,
                Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
            });
            //#21 Mario Drmac
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=21,
                Ime = "Mario",
                Prezime = "Drmac",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#22 Belma Lizde Kurt
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=22,
                Ime = "Belma",
                Prezime = "Lizde Kurt",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#23  Irfan Avdic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=23,
                Ime = "Irfan",
                Prezime = "Avdic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 1,
                Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
            });
            //#24 Sanin Milavic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=24,
                Ime = "Sanin",
                Prezime = "Milavic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#25 Semir Krivic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=25,
                Ime = "Semir",
                Prezime = "Krivic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#26  Drago Buka 
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=26,
                Ime = "Drago",
                Prezime = "Buka",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 1,
                Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
            });
            //#27 Alma Merunka
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=27,
                Ime = "Alma",
                Prezime = "Merunka",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#28 Ajla Cabrera
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=28,
                Ime = "Ajla",
                Prezime = "Cabrera",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#29 Belma Ceco Bakrac
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=29,
                Ime = "Belma",
                Prezime = "Ceco Bakrac",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 3,
                Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
            });
            //#30 Milan Rus
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=30,
                Ime = "Milan",
                Prezime = "Rus",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#31 Tamara Ljubičić
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=31,
                Ime = "Tamara",
                Prezime = "Ljubicic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#32 Nermina Damian
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=32,
                Ime = "Nermina",
                Prezime = "Damian",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 3,
                Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
            });
            //#33 Natasa Gaponko
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=33,
                Ime = "Natasa",
                Prezime = "Gaponko",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#34 Ekaterina Verescagina
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=34,
                Ime = "Ekaterina",
                Prezime = "Verescagina",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#35 Dinko Bogdanic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=35,
                Ime = "Dinko",
                Prezime = "Bogdanic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 3,
                Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
            });
            //#36 Adnan Djindo
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=36,
                Ime = "Adnan",
                Prezime = "Djindo",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#37 Dajana Zilic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=37,
                Ime = "Dajana",
                Prezime = "Zilic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#38  Ognian Draganoff
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=38,
                Ime = "Ognian",
                Prezime = "Draganoff",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 1,
                Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
            });
            //#39 Martina Zadro
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=39,
                Ime = "Martina",
                Prezime = "Zadro",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#40 Amir Saracevic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=40,
                Ime = "Amir",
                Prezime = "Saracevic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#41 Aleksandar Nikolic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=41,
                Ime = "Aleksandar",
                Prezime = "Nikolic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 1,
                Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
            });
            //#42 Marko Kalajanovic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=42,
                Ime = "Marko",
                Prezime = "Kalajanovic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#43 Leonardo Saric
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=43,
                Ime = "Leonardo",
                Prezime = "Saric",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });
            //#44 Dragutin Matic
            modelBuilder.Entity<Djelatnici>().HasData(new Djelatnici()
            {
                DjelatnikId=44,
                Ime = "Dragutin",
                Prezime = "Matic",
                Biografija = "...",
                Status = true,
                VrstaDjelatnikaId = 2,
                Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
            });

            //#1 Helverova noc
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() { PredstavaDjelatnikId=1, PredstavaId = 1, DjelatnikId = 1 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=2, PredstavaId = 1, DjelatnikId = 2 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=3, PredstavaId = 1, DjelatnikId = 3 });
                                                                                          
            //#2 Mirna Bosna                                                              
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=4, PredstavaId = 2, DjelatnikId = 4 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=5, PredstavaId = 2, DjelatnikId = 5 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=6, PredstavaId = 2, DjelatnikId = 6 });
                                                                                          
            //#3 Knjiga mojih zivota                                                      
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=7, PredstavaId = 3, DjelatnikId = 7 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=8, PredstavaId = 3, DjelatnikId = 8 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=9, PredstavaId = 3, DjelatnikId = 9 });
                                                                                          
            //#4 Tajna dzema od malina                                                    
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=10, PredstavaId = 4, DjelatnikId = 10 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=11, PredstavaId = 4, DjelatnikId = 11 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=12, PredstavaId = 4, DjelatnikId = 12 });
                                                                                          
            //#5 Ay Carmela                                                               
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=13, PredstavaId = 5, DjelatnikId = 13 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=14, PredstavaId = 5, DjelatnikId = 14 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=15, PredstavaId = 5, DjelatnikId = 15 });
                                                                                          
            //#6 Dogville                                                                 
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=16, PredstavaId = 6, DjelatnikId = 16 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=17, PredstavaId = 6, DjelatnikId = 17 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=18, PredstavaId = 6, DjelatnikId = 18 });
                                                                                          
            //#7 Snijeg                                                                   
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=19, PredstavaId = 7, DjelatnikId = 1 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=20, PredstavaId = 7, DjelatnikId = 17 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=21, PredstavaId = 7, DjelatnikId = 19 });
                                                                                          
            //#8 Princeza na zrnu graska                                                  
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=22, PredstavaId = 8, DjelatnikId = 20 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=23, PredstavaId = 8, DjelatnikId = 21 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=24, PredstavaId = 8, DjelatnikId = 22 });
                                                                                          
            //#9 Zaljubljeni krokodil                                                     
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=25, PredstavaId = 9, DjelatnikId = 26 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=26, PredstavaId = 9, DjelatnikId = 27 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=27, PredstavaId = 9, DjelatnikId = 28 });
                                                                                          
            //#10 Patkica Blatkica                                                        
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=28, PredstavaId = 10, DjelatnikId = 23 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=29, PredstavaId = 10, DjelatnikId = 24 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=30, PredstavaId = 10, DjelatnikId = 25 });
                                                                                          
            //#11 Okovani prometej                                                        
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=31, PredstavaId = 11, DjelatnikId = 29 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=32, PredstavaId = 11, DjelatnikId = 30 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=33, PredstavaId = 11, DjelatnikId = 31 });
                                                                                          
            //#12 Palcica                                                                 
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=34, PredstavaId = 12, DjelatnikId = 32 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=35, PredstavaId = 12, DjelatnikId = 33 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=36, PredstavaId = 12, DjelatnikId = 34 });
                                                                                          
            //#13 Uspavana ljepotica                                                      
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=37, PredstavaId = 13, DjelatnikId = 35 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=38, PredstavaId = 13, DjelatnikId = 36 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=39, PredstavaId = 13, DjelatnikId = 37 });
                                                                                          
            //#14 La Traviata                                                             
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=40, PredstavaId = 14, DjelatnikId = 38 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=41, PredstavaId = 14, DjelatnikId = 39 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=42, PredstavaId = 14, DjelatnikId = 40 });
                                                                                          
            //#15 Don Giovanni                                                            
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=43, PredstavaId = 15, DjelatnikId = 41 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=44, PredstavaId = 15, DjelatnikId = 42 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=45, PredstavaId = 15, DjelatnikId = 43 });
                                                                                          
            //#16 Rigoletto                                                               
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=46, PredstavaId = 16, DjelatnikId = 38 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() {PredstavaDjelatnikId=47, PredstavaId = 16, DjelatnikId = 40 });
            modelBuilder.Entity<PredstaveDjelatnici>().HasData(new PredstaveDjelatnici() { PredstavaDjelatnikId = 48, PredstavaId = 16, DjelatnikId = 44 });

            //#1 Helverova noc 1/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=1,
                PredstavaId = 1,
                PozoristeId = 1,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 1, 20, 0, 0),
            });
            //#2 Helverova noc 8/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=2,
                PredstavaId = 1,
                PozoristeId = 1,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 8, 20, 0, 0),
            });
            //#3 Helverova noc 15/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=3,
                PredstavaId = 1,
                PozoristeId = 1,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 15, 20, 0, 0),
            });
            //#4 Helverova noc 22/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=4,
                PredstavaId = 1,
                PozoristeId = 1,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 22, 20, 0, 0),
            });
            //#5 Helverova noc 29/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=5,
                PredstavaId = 1,
                PozoristeId = 1,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 29, 20, 0, 0),
            });

            //#6 Mirna Bosna 3/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=6,
                PredstavaId = 2,
                PozoristeId = 1,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 3, 20, 0, 0),
            });
            //#7 Mirna Bosna 10/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=7,
                PredstavaId = 2,
                PozoristeId = 1,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 10, 20, 0, 0),
            });
            //#8 Mirna Bosna 17/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=8,
                PredstavaId = 2,
                PozoristeId = 1,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 17, 20, 0, 0),
            });
            //#9 Mirna Bosna 24/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=9,
                PredstavaId = 2,
                PozoristeId = 1,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 24, 20, 0, 0),
            });

            //#10 Knjiga mojih zivota 5/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=10,
                PredstavaId = 3,
                PozoristeId = 1,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 5, 20, 0, 0),
            });
            //#11 Knjiga mojih zivota 12/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=11,
                PredstavaId = 3,
                PozoristeId = 1,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 12, 20, 0, 0),
            });
            //#12 Knjiga mojih zivota 19/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=12,
                PredstavaId = 3,
                PozoristeId = 1,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 19, 20, 0, 0),
            });
            //#13 Knjiga mojih zivota 26/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=13,
                PredstavaId = 3,
                PozoristeId = 1,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 26, 20, 0, 0),
            });

            //#14 Tajna dzema od malina 2/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=14,
                PredstavaId = 4,
                PozoristeId = 3,
                Napomena = "",
                KorisnikId = 3,
                DatumVrijeme = new DateTime(2021, 6, 2, 20, 0, 0),
            });
            //#15 Tajna dzema od malina 9/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=15,
                PredstavaId = 4,
                PozoristeId = 3,
                Napomena = "",
                KorisnikId = 3,
                DatumVrijeme = new DateTime(2021, 6, 9, 20, 0, 0),
            });
            //#16 Tajna dzema od malina 16/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=16,
                PredstavaId = 4,
                PozoristeId = 3,
                Napomena = "",
                KorisnikId = 3,
                DatumVrijeme = new DateTime(2021, 6, 16, 20, 0, 0),
            });
            //#17 Tajna dzema od malina 23/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=17,
                PredstavaId = 4,
                PozoristeId = 3,
                Napomena = "",
                KorisnikId = 3,
                DatumVrijeme = new DateTime(2021, 6, 23, 20, 0, 0),
            });

            //#18 Ay Carmela 4/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=18,
                PredstavaId = 5,
                PozoristeId = 3,
                Napomena = "",
                KorisnikId = 3,
                DatumVrijeme = new DateTime(2021, 6, 4, 20, 0, 0),
            });

            //#19 Dogville 1/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=19,
                PredstavaId = 6,
                PozoristeId = 2,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 1, 20, 0, 0),
            });
            //#20 Dogville 15/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=20,
                PredstavaId = 6,
                PozoristeId = 2,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 15, 20, 0, 0),
            });
            //#21 Dogville 29/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=21,
                PredstavaId = 6,
                PozoristeId = 2,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 29, 20, 0, 0),
            });

            //#22 Snijeg 2/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=22,
                PredstavaId = 7,
                PozoristeId = 2,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 2, 20, 0, 0),
            });
            //#23 Snijeg 16/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=23,
                PredstavaId = 7,
                PozoristeId = 2,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 16, 20, 0, 0),
            });
            //#24 Snijeg 30/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=24,
                PredstavaId = 7,
                PozoristeId = 2,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 30, 20, 0, 0),
            });

            //#25 Princeza na zrnu graska 2/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=25,
                PredstavaId = 8,
                PozoristeId = 4,
                Napomena = "",
                KorisnikId = 3,
                DatumVrijeme = new DateTime(2021, 6, 2, 15, 0, 0),
            });
            //#26 Princeza na zrnu graska 16/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=26,
                PredstavaId = 8,
                PozoristeId = 4,
                Napomena = "",
                KorisnikId = 3,
                DatumVrijeme = new DateTime(2021, 6, 16, 15, 0, 0),
            });

            //#27 Zaljubljeni krokodil 3/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=27,
                PredstavaId = 9,
                PozoristeId = 4,
                Napomena = "",
                KorisnikId = 3,
                DatumVrijeme = new DateTime(2021, 6, 3, 15, 0, 0),
            });
            //#28 Zaljubljeni krokodil 17/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=28,
                PredstavaId = 9,
                PozoristeId = 4,
                Napomena = "",
                KorisnikId = 3,
                DatumVrijeme = new DateTime(2021, 6, 17, 15, 0, 0),
            });

            //#29 Patkica Blatkica 4/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=29,
                PredstavaId = 10,
                PozoristeId = 4,
                Napomena = "",
                KorisnikId = 3,
                DatumVrijeme = new DateTime(2021, 6, 4, 14, 0, 0),
            });
            //#30 Patkica Blatkica 18/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=30,
                PredstavaId = 10,
                PozoristeId = 4,
                Napomena = "",
                KorisnikId = 3,
                DatumVrijeme = new DateTime(2021, 6, 18, 14, 0, 0),
            });

            //#31 Okovani prometej 5/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=31,
                PredstavaId = 11,
                PozoristeId = 2,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 5, 20, 0, 0),
            });
            //#32 Okovani prometej 19/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=32,
                PredstavaId = 11,
                PozoristeId = 2,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 19, 20, 0, 0),
            });

            //#33 Palcica 12/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=33,
                PredstavaId = 12,
                PozoristeId = 2,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 12, 18, 0, 0),
            });
            //#34 Palcica 26/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=34,
                PredstavaId = 12,
                PozoristeId = 2,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 26, 18, 0, 0),
            });

            //#35 Uspavana ljepotica 12/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=35,
                PredstavaId = 13,
                PozoristeId = 2,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 12, 21, 0, 0),
            });
            //#36 Uspavana ljepotica 26/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=36,
                PredstavaId = 13,
                PozoristeId = 2,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 26, 21, 0, 0),
            });

            //#37 La Traviata 6/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=37,
                PredstavaId = 14,
                PozoristeId = 2,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 6, 21, 0, 0),
            });

            //#38 Don Giovanni 13/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=38,
                PredstavaId = 15,
                PozoristeId = 2,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 13, 21, 0, 0),
            });

            //#39 Rigoletto 20/6/21
            modelBuilder.Entity<Izvodjenja>().HasData(new Izvodjenja()
            {
                IzvodjenjeId=39,
                PredstavaId = 16,
                PozoristeId = 2,
                Napomena = "",
                KorisnikId = 2,
                DatumVrijeme = new DateTime(2021, 6, 20, 21, 0, 0),
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId=1,
                IzvodjenjeId = 1,
                ZonaId = 1,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId=2,
                IzvodjenjeId = 1,
                ZonaId = 2,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId=3,
                IzvodjenjeId = 1,
                ZonaId = 3,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 4,
                IzvodjenjeId = 2,
                ZonaId = 1,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 5,
                IzvodjenjeId = 2,
                ZonaId = 2,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId=6,
                IzvodjenjeId = 2,
                ZonaId = 3,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 7,
                IzvodjenjeId = 3,
                ZonaId = 1,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 8,
                IzvodjenjeId = 3,
                ZonaId = 2,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 9,
                IzvodjenjeId = 3,
                ZonaId = 3,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 10,
                IzvodjenjeId = 4,
                ZonaId = 1,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 11,
                IzvodjenjeId = 4,
                ZonaId = 2,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 12,
                IzvodjenjeId = 4,
                ZonaId = 3,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 13,
                IzvodjenjeId = 5,
                ZonaId = 1,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 14,
                IzvodjenjeId = 5,
                ZonaId = 2,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 15,
                IzvodjenjeId = 5,
                ZonaId = 3,
                Cijena = 5,
                Popust = null,
            });

            //# Mirna Bosna
            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 16,
                IzvodjenjeId = 6,
                ZonaId = 1,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 17,
                IzvodjenjeId = 6,
                ZonaId = 2,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 18,
                IzvodjenjeId = 6,
                ZonaId = 3,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 19,
                IzvodjenjeId = 7,
                ZonaId = 1,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 20,
                IzvodjenjeId = 7,
                ZonaId = 2,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 21,
                IzvodjenjeId = 7,
                ZonaId = 3,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 22,
                IzvodjenjeId = 8,
                ZonaId = 1,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 23,
                IzvodjenjeId = 8,
                ZonaId = 2,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 24,
                IzvodjenjeId = 8,
                ZonaId = 3,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 25,
                IzvodjenjeId = 9,
                ZonaId = 1,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 26,
                IzvodjenjeId = 9,
                ZonaId = 2,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 27,
                IzvodjenjeId = 9,
                ZonaId = 3,
                Cijena = 5,
                Popust = null,
            });

            //# Knjiga mojih zivota
            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 28,
                IzvodjenjeId = 10,
                ZonaId = 1,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 29,
                IzvodjenjeId = 10,
                ZonaId = 2,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 30,
                IzvodjenjeId = 10,
                ZonaId = 3,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 31,
                IzvodjenjeId = 11,
                ZonaId = 1,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 32,
                IzvodjenjeId = 11,
                ZonaId = 2,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 33,
                IzvodjenjeId = 11,
                ZonaId = 3,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 34,
                IzvodjenjeId = 12,
                ZonaId = 1,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 35,
                IzvodjenjeId = 12,
                ZonaId = 2,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 36,
                IzvodjenjeId = 12,
                ZonaId = 3,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 37,
                IzvodjenjeId = 13,
                ZonaId = 1,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 38,
                IzvodjenjeId = 13,
                ZonaId = 2,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 39,
                IzvodjenjeId = 13,
                ZonaId = 3,
                Cijena = 5,
                Popust = null,
            });

            //Tajna dzema od malina
            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 40,
                IzvodjenjeId = 14,
                ZonaId = 8,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 41,
                IzvodjenjeId = 14,
                ZonaId = 9,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 42,
                IzvodjenjeId = 14,
                ZonaId = 10,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 43,
                IzvodjenjeId = 15,
                ZonaId = 8,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 44,
                IzvodjenjeId = 15,
                ZonaId = 9,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 45,
                IzvodjenjeId = 15,
                ZonaId = 10,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 46,
                IzvodjenjeId = 16,
                ZonaId = 8,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 47,
                IzvodjenjeId = 16,
                ZonaId = 9,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 48,
                IzvodjenjeId = 16,
                ZonaId = 10,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 49,
                IzvodjenjeId = 17,
                ZonaId = 8,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 50,
                IzvodjenjeId = 17,
                ZonaId = 9,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 51,
                IzvodjenjeId = 17,
                ZonaId = 10,
                Cijena = 5,
                Popust = null,
            });

            //Ay Carmela
            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 52,
                IzvodjenjeId = 18,
                ZonaId = 8,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 53,
                IzvodjenjeId = 18,
                ZonaId = 9,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 54,
                IzvodjenjeId = 18,
                ZonaId = 10,
                Cijena = 5,
                Popust = null,
            });

            //Dogville
            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 55,
                IzvodjenjeId = 19,
                ZonaId = 4,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 56,
                IzvodjenjeId = 19,
                ZonaId = 5,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 57,
                IzvodjenjeId = 19,
                ZonaId = 6,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 58,
                IzvodjenjeId = 19,
                ZonaId = 7,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 59,
                IzvodjenjeId = 20,
                ZonaId = 4,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 60,
                IzvodjenjeId = 20,
                ZonaId = 5,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 61,
                IzvodjenjeId = 20,
                ZonaId = 6,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 62,
                IzvodjenjeId = 20,
                ZonaId = 7,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 63,
                IzvodjenjeId = 21,
                ZonaId = 4,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 64,
                IzvodjenjeId = 21,
                ZonaId = 5,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 65,
                IzvodjenjeId = 21,
                ZonaId = 6,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 66,
                IzvodjenjeId = 21,
                ZonaId = 7,
                Cijena = 5,
                Popust = null,
            });

            //Snijeg 
            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 67,
                IzvodjenjeId = 22,
                ZonaId = 4,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 68,
                IzvodjenjeId = 22,
                ZonaId = 5,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 69,
                IzvodjenjeId = 22,
                ZonaId = 6,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 70,
                IzvodjenjeId = 22,
                ZonaId = 7,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 71,
                IzvodjenjeId = 23,
                ZonaId = 4,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 72,
                IzvodjenjeId = 23,
                ZonaId = 5,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 73,
                IzvodjenjeId = 23,
                ZonaId = 6,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 74,
                IzvodjenjeId = 23,
                ZonaId = 7,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 75,
                IzvodjenjeId = 24,
                ZonaId = 4,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 76,
                IzvodjenjeId = 24,
                ZonaId = 5,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 77,
                IzvodjenjeId = 24,
                ZonaId = 6,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 78,
                IzvodjenjeId = 24,
                ZonaId = 7,
                Cijena = 5,
                Popust = null,
            });

            //Princeza na zrnu graska 
            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 79,
                IzvodjenjeId = 25,
                ZonaId = 11,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 80,
                IzvodjenjeId = 25,
                ZonaId = 12,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 81,
                IzvodjenjeId = 25,
                ZonaId = 13,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 82,
                IzvodjenjeId = 26,
                ZonaId = 11,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 83,
                IzvodjenjeId = 26,
                ZonaId = 12,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 84,
                IzvodjenjeId = 26,
                ZonaId = 13,
                Cijena = 5,
                Popust = null,
            });

            //Zaljubljeni krokodil
            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 85,
                IzvodjenjeId = 27,
                ZonaId = 11,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 86,
                IzvodjenjeId = 27,
                ZonaId = 12,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 87,
                IzvodjenjeId = 27,
                ZonaId = 13,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 88,
                IzvodjenjeId = 28,
                ZonaId = 11,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 89,
                IzvodjenjeId = 28,
                ZonaId = 12,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 90,
                IzvodjenjeId = 28,
                ZonaId = 13,
                Cijena = 5,
                Popust = null,
            });

            //Patkica Blatkica
            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 91,
                IzvodjenjeId = 29,
                ZonaId = 11,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 92,
                IzvodjenjeId = 29,
                ZonaId = 12,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 93,
                IzvodjenjeId = 29,
                ZonaId = 13,
                Cijena = 5,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 94,
                IzvodjenjeId = 30,
                ZonaId = 11,
                Cijena = 15,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 95,
                IzvodjenjeId = 30,
                ZonaId = 12,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 96,
                IzvodjenjeId = 30,
                ZonaId = 13,
                Cijena = 5,
                Popust = null,
            });

            //Okovani prometej
            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 97,
                IzvodjenjeId = 31,
                ZonaId = 4,
                Cijena = 40,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 98,
                IzvodjenjeId = 31,
                ZonaId = 5,
                Cijena = 30,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 99,
                IzvodjenjeId = 31,
                ZonaId = 6,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 100,
                IzvodjenjeId = 32,
                ZonaId = 7,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 101,
                IzvodjenjeId = 31,
                ZonaId = 4,
                Cijena = 40,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 102,
                IzvodjenjeId = 32,
                ZonaId = 5,
                Cijena = 30,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 103,
                IzvodjenjeId = 32,
                ZonaId = 6,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 104,
                IzvodjenjeId = 32,
                ZonaId = 7,
                Cijena = 10,
                Popust = null,
            });

            //Palcica
            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 105,
                IzvodjenjeId = 33,
                ZonaId = 4,
                Cijena = 40,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 106,
                IzvodjenjeId = 33,
                ZonaId = 5,
                Cijena = 30,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 107,
                IzvodjenjeId = 33,
                ZonaId = 6,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 108,
                IzvodjenjeId = 33,
                ZonaId = 7,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 109,
                IzvodjenjeId = 34,
                ZonaId = 4,
                Cijena = 40,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 110,
                IzvodjenjeId = 34,
                ZonaId = 5,
                Cijena = 30,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 111,
                IzvodjenjeId = 34,
                ZonaId = 6,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 112,
                IzvodjenjeId = 34,
                ZonaId = 7,
                Cijena = 10,
                Popust = null,
            });

            //Uspavana ljepotica
            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 113,
                IzvodjenjeId = 35,
                ZonaId = 4,
                Cijena = 40,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 114,
                IzvodjenjeId = 35,
                ZonaId = 5,
                Cijena = 30,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 115,
                IzvodjenjeId = 35,
                ZonaId = 6,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 116,
                IzvodjenjeId = 35,
                ZonaId = 7,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 117,
                IzvodjenjeId = 36,
                ZonaId = 4,
                Cijena = 40,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 118,
                IzvodjenjeId = 36,
                ZonaId = 5,
                Cijena = 30,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 119,
                IzvodjenjeId = 36,
                ZonaId = 6,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 120,
                IzvodjenjeId = 36,
                ZonaId = 7,
                Cijena = 10,
                Popust = null,
            });

            //La Traviata
            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 121,
                IzvodjenjeId = 37,
                ZonaId = 4,
                Cijena = 40,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 122,
                IzvodjenjeId = 37,
                ZonaId = 5,
                Cijena = 30,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 123,
                IzvodjenjeId = 37,
                ZonaId = 6,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 124,
                IzvodjenjeId = 37,
                ZonaId = 7,
                Cijena = 10,
                Popust = null,
            });

            //Don Giovanni
            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 125,
                IzvodjenjeId = 38,
                ZonaId = 4,
                Cijena = 40,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 126,
                IzvodjenjeId = 38,
                ZonaId = 5,
                Cijena = 30,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 127,
                IzvodjenjeId = 38,
                ZonaId = 6,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 128,
                IzvodjenjeId = 38,
                ZonaId = 7,
                Cijena = 10,
                Popust = null,
            });

            //Rigoletto
            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 129,
                IzvodjenjeId = 39,
                ZonaId = 4,
                Cijena = 40,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 130,
                IzvodjenjeId = 39,
                ZonaId = 5,
                Cijena = 30,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 131,
                IzvodjenjeId = 39,
                ZonaId = 6,
                Cijena = 20,
                Popust = null,
            });

            modelBuilder.Entity<IzvodjenjaZone>().HasData(new IzvodjenjaZone()
            {
                IzvodjenjeZonaId = 132,
                IzvodjenjeId = 39,
                ZonaId = 7,
                Cijena = 10,
                Popust = null,
            });

            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=1, IzvodjenjeId = 1, KupacId = 1, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0001" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=2, IzvodjenjeId = 1, KupacId = 1, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0002" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=3, IzvodjenjeId = 1, KupacId = 2, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0003" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=4, IzvodjenjeId = 1, KupacId = 2, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0004" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=5, IzvodjenjeId = 1, KupacId = 2, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0005" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=6, IzvodjenjeId = 2, KupacId = 4, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0006" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=7, IzvodjenjeId = 2, KupacId = 4, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0007" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=8, IzvodjenjeId = 2, KupacId = 5, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0008" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=9, IzvodjenjeId = 2, KupacId = 7, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0009" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=10, IzvodjenjeId = 3, KupacId = 8, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0010" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=11, IzvodjenjeId = 3, KupacId = 8, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0011" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=12, IzvodjenjeId = 3, KupacId = 8, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0012" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=13, IzvodjenjeId = 3, KupacId = 8, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0013" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=14, IzvodjenjeId = 4, KupacId = 9, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0014" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=15, IzvodjenjeId = 4, KupacId = 9, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0015" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=16, IzvodjenjeId = 5, KupacId = 10, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0016" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=17, IzvodjenjeId = 5, KupacId = 10, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0017" });
                                                               
            // Mirna Bosna, Izvodjenja 6-9 - Kupci 1, 3, 5, 9,  
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=18, IzvodjenjeId = 6, KupacId = 1, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0018" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=19, IzvodjenjeId = 6, KupacId = 1, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0019" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=20, IzvodjenjeId = 7, KupacId = 3, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0020" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=21, IzvodjenjeId = 7, KupacId = 3, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0021" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=22, IzvodjenjeId = 8, KupacId = 5, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0022" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=23, IzvodjenjeId = 8, KupacId = 5, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0023" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=24, IzvodjenjeId = 9, KupacId = 9, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0024" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=25, IzvodjenjeId = 9, KupacId = 9, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0025" });
                                                               
            //Knjiga mojih zivota, Izvodjenja 10 - 13 - Kupci  2, 6, 8, 10
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=26, IzvodjenjeId = 10, KupacId = 2, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0026" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=27, IzvodjenjeId = 10, KupacId = 2, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0027" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=28, IzvodjenjeId = 11, KupacId = 6, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0028" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=29, IzvodjenjeId = 11, KupacId = 6, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0029" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=30, IzvodjenjeId = 12, KupacId = 8, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0030" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=31, IzvodjenjeId = 12, KupacId = 8, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0031" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=32, IzvodjenjeId = 12, KupacId = 8, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0032" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=33, IzvodjenjeId = 13, KupacId = 10, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0033" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=34, IzvodjenjeId = 13, KupacId = 10, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0034" });
                                                               
            //Tajna dzema od malina, Izvodjenja 14 - 17 - Kupci 1, 5, 7, 9
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=35, IzvodjenjeId = 14, KupacId = 1, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0035" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=36, IzvodjenjeId = 14, KupacId = 1, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0036" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=37, IzvodjenjeId = 15, KupacId = 5, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0037" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=38, IzvodjenjeId = 15, KupacId = 5, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0038" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=39, IzvodjenjeId = 16, KupacId = 7, IzvodjenjeZonaId = 9, Placeno = false, Sifra = "k0039" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=40, IzvodjenjeId = 16, KupacId = 7, IzvodjenjeZonaId = 9, Placeno = false, Sifra = "k0040" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=41, IzvodjenjeId = 17, KupacId = 9, IzvodjenjeZonaId = 10, Placeno = false, Sifra = "k0041" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=42, IzvodjenjeId = 17, KupacId = 9, IzvodjenjeZonaId = 10, Placeno = false, Sifra = "k0042" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=43, IzvodjenjeId = 17, KupacId = 9, IzvodjenjeZonaId = 10, Placeno = false, Sifra = "k0043" });
                                                               
            //Ay Carmela, Izvodjenje 18 - Kupci 1,2,7,8,9      
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=44, IzvodjenjeId = 18, KupacId = 1, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0044" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=45, IzvodjenjeId = 18, KupacId = 2, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0045" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=46, IzvodjenjeId = 18, KupacId = 7, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0046" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=47, IzvodjenjeId = 18, KupacId = 8, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0047" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=48, IzvodjenjeId = 18, KupacId = 9, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0048" });
                                                               
            // Dogville, Izvodjenja 19-21 - Kupci 3, 7, 5, 10  
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=49, IzvodjenjeId = 19, KupacId = 3, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0049" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=50, IzvodjenjeId = 19, KupacId = 3, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0050" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=51, IzvodjenjeId = 19, KupacId = 7, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0051" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=52, IzvodjenjeId = 19, KupacId = 7, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0052" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=53, IzvodjenjeId = 20, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0053" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=54, IzvodjenjeId = 20, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0054" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=55, IzvodjenjeId = 20, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0055" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=56, IzvodjenjeId = 21, KupacId = 5, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0056" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=57, IzvodjenjeId = 21, KupacId = 5, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0057" });
                                                               
                                                               
            // Snijeg, Izvodjenja 22-24 - Kupci 3,4,7          
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=58, IzvodjenjeId = 22, KupacId = 3, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0058" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=59, IzvodjenjeId = 22, KupacId = 3, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0059" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=60, IzvodjenjeId = 22, KupacId = 3, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0060" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=61, IzvodjenjeId = 23, KupacId = 4, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0061" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=62, IzvodjenjeId = 23, KupacId = 4, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0062" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=63, IzvodjenjeId = 24, KupacId = 7, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0063" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=64, IzvodjenjeId = 24, KupacId = 7, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0064" });
                                                               
            //Princeza na zrnu graska, Izvodjenja 25, 26 - Kupci 2,3,6
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=65, IzvodjenjeId = 25, KupacId = 2, IzvodjenjeZonaId = 11, Placeno = false, Sifra = "k0065" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=66, IzvodjenjeId = 25, KupacId = 2, IzvodjenjeZonaId = 11, Placeno = false, Sifra = "k0066" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=67, IzvodjenjeId = 25, KupacId = 3, IzvodjenjeZonaId = 12, Placeno = false, Sifra = "k0067" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=68, IzvodjenjeId = 25, KupacId = 3, IzvodjenjeZonaId = 12, Placeno = false, Sifra = "k0068" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=69, IzvodjenjeId = 26, KupacId = 6, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0069" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=70, IzvodjenjeId = 26, KupacId = 6, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0070" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=71, IzvodjenjeId = 26, KupacId = 6, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0071" });
                                                               
            // Zaljubljeni krokodil, Izvodjenja 27,28 - Kupci  1,9,10
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=72, IzvodjenjeId = 27, KupacId = 1, IzvodjenjeZonaId = 11, Placeno = false, Sifra = "k0072" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=73, IzvodjenjeId = 27, KupacId = 1, IzvodjenjeZonaId = 11, Placeno = false, Sifra = "k0073" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=74, IzvodjenjeId = 27, KupacId = 9, IzvodjenjeZonaId = 12, Placeno = false, Sifra = "k0074" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=75, IzvodjenjeId = 27, KupacId = 9, IzvodjenjeZonaId = 12, Placeno = false, Sifra = "k0075" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=76, IzvodjenjeId = 28, KupacId = 10, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0076" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=77, IzvodjenjeId = 28, KupacId = 10, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0077" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=78, IzvodjenjeId = 28, KupacId = 10, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0078" });
                                                               
            // Patkica Blatkica, Izvodjenja 29,30 - Kupci 3,6, 10
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=79, IzvodjenjeId = 29, KupacId = 3, IzvodjenjeZonaId = 11, Placeno = false, Sifra = "k0079" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=80, IzvodjenjeId = 29, KupacId = 3, IzvodjenjeZonaId = 11, Placeno = false, Sifra = "k0080" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=81, IzvodjenjeId = 29, KupacId = 6, IzvodjenjeZonaId = 12, Placeno = false, Sifra = "k0081" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=82, IzvodjenjeId = 29, KupacId = 6, IzvodjenjeZonaId = 12, Placeno = false, Sifra = "k0082" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=83, IzvodjenjeId = 30, KupacId = 10, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0083" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=84, IzvodjenjeId = 30, KupacId = 10, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0084" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=85, IzvodjenjeId = 30, KupacId = 10, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0085" });
                                                               
            // Okovani prometej, Izvodjenja 31,32 - Kupci - 4, 8,9,10
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=86, IzvodjenjeId = 31, KupacId = 4, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0086" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=87, IzvodjenjeId = 31, KupacId = 4, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0087" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=88, IzvodjenjeId = 31, KupacId = 8, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0088" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=89, IzvodjenjeId = 31, KupacId = 8, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0089" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=90, IzvodjenjeId = 32, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0090" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=91, IzvodjenjeId = 32, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0091" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=92, IzvodjenjeId = 32, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0092" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=93, IzvodjenjeId = 32, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0093" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=94, IzvodjenjeId = 32, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0094" });
                                                               
                                                               
            // Palcica, Izvodjenja 33,34 - Kupci 5,8,9,10      
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=95, IzvodjenjeId = 33, KupacId = 5, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0095" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=96, IzvodjenjeId = 33, KupacId = 5, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0096" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=97, IzvodjenjeId = 33, KupacId = 8, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0097" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=98, IzvodjenjeId = 33, KupacId = 8, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0098" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=99, IzvodjenjeId = 34, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0099" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=100, IzvodjenjeId = 34, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0100" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=101, IzvodjenjeId = 34, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0101" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=102, IzvodjenjeId = 34, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0102" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=103, IzvodjenjeId = 34, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0103" });
                                                               
            // Uspavana ljepotica, Izvodjenja 35, 36 - Kupci - 2,3,9,10
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=104, IzvodjenjeId = 35, KupacId = 2, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0104" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=105, IzvodjenjeId = 35, KupacId = 2, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0105" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=106, IzvodjenjeId = 35, KupacId = 3, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0106" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=107, IzvodjenjeId = 35, KupacId = 3, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0107" });
                                                               
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=108, IzvodjenjeId = 36, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0108" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=109, IzvodjenjeId = 36, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0109" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=110, IzvodjenjeId = 36, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0110" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=111, IzvodjenjeId = 36, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0111" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=112, IzvodjenjeId = 36, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0112" });
                                                               
            // La Traviata, Izvodjenje 37 - Kupci 7,9,10       
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=113, IzvodjenjeId = 37, KupacId = 7, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0113" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=114, IzvodjenjeId = 37, KupacId = 7, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0114" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=115, IzvodjenjeId = 37, KupacId = 7, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0115" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=116, IzvodjenjeId = 37, KupacId = 7, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0116" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=117, IzvodjenjeId = 37, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0117" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=118, IzvodjenjeId = 37, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0118" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=119, IzvodjenjeId = 37, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0119" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=120, IzvodjenjeId = 37, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0120" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=121, IzvodjenjeId = 37, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0121" });
                                                               
            // Don Giovanni, Izvodjenje 38 - Kupci 6,9,8       
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=122, IzvodjenjeId = 38, KupacId = 7, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0122" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=123, IzvodjenjeId = 38, KupacId = 7, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0123" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=124, IzvodjenjeId = 38, KupacId = 7, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0124" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=125, IzvodjenjeId = 38, KupacId = 7, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0125" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=126, IzvodjenjeId = 38, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0126" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=127, IzvodjenjeId = 38, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0127" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=128, IzvodjenjeId = 38, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0128" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=129, IzvodjenjeId = 38, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0129" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=130, IzvodjenjeId = 38, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0130" });
                                                               
            // Rigoletto, Izvodjenje 39 - Kupci 5,6,9,10       
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=131, IzvodjenjeId = 39, KupacId = 5, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0131" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=132, IzvodjenjeId = 39, KupacId = 5, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0132" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=133, IzvodjenjeId = 39, KupacId = 6, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0133" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=134, IzvodjenjeId = 39, KupacId = 6, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0134" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=135, IzvodjenjeId = 39, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0135" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=136, IzvodjenjeId = 39, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0136" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=137, IzvodjenjeId = 39, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0137" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=138, IzvodjenjeId = 39, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0138" });
            modelBuilder.Entity<Karte>().HasData(new Karte() { KartaId=139, IzvodjenjeId = 39, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0139" });

            //#1 Kupac - Predstave 1, 2, 4, 5, 9
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=1, KupacId = 1, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=2, KupacId = 1, PredstavaId = 2, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=3, KupacId = 1, PredstavaId = 4, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=4, KupacId = 1, PredstavaId = 5, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=5, KupacId = 1, PredstavaId = 9, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
                                                                 
            //#2 Kupac - Predstave 1, 3, 5, 8, 13                
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=6, KupacId = 2, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=7, KupacId = 2, PredstavaId = 3, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=8, KupacId = 2, PredstavaId = 5, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=9, KupacId = 2, PredstavaId = 8, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=10, KupacId = 2, PredstavaId = 13, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
                                                                 
            //#3 Kupac - Predstave 2, 6, 7, 8, 10, 13            
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=11, KupacId = 3, PredstavaId = 2, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=12, KupacId = 3, PredstavaId = 6, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=13, KupacId = 3, PredstavaId = 7, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=14, KupacId = 3, PredstavaId = 8, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=15, KupacId = 3, PredstavaId = 10, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=16, KupacId = 3, PredstavaId = 13, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 6) });
                                                                 
            //#4 Kupac - Predstave 1, 7, 11                      
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=17, KupacId = 4, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=18, KupacId = 4, PredstavaId = 7, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=19, KupacId = 4, PredstavaId = 11, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 6) });
                                                                 
            //#5 Kupac - Predstave 1, 2, 4, 12, 16               
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=20, KupacId = 5, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=21, KupacId = 5, PredstavaId = 2, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=22, KupacId = 5, PredstavaId = 4, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=23, KupacId = 5, PredstavaId = 12, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=24, KupacId = 5, PredstavaId = 16, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
                                                                 
            //#6 Kupac - Predstave 3, 8, 10, 15, 16              
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=25, KupacId = 6, PredstavaId = 3, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=26, KupacId = 6, PredstavaId = 8, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=27, KupacId = 6, PredstavaId = 10, Ocjena = 1, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=28, KupacId = 6, PredstavaId = 15, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=29, KupacId = 6, PredstavaId = 16, Ocjena = 1, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
                                                                 
            //#7 Kupac - Predstave 1, 4, 5, 6, 7, 14             
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=30, KupacId = 7, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=31, KupacId = 7, PredstavaId = 4, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=32, KupacId = 7, PredstavaId = 5, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=33, KupacId = 7, PredstavaId = 6, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=34, KupacId = 7, PredstavaId = 7, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=35, KupacId = 7, PredstavaId = 14, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 6) });
                                                                 
            //#8 Kupac - Predstave 1, 3, 5, 11, 12, 15           
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=36, KupacId = 8, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=37, KupacId = 8, PredstavaId = 3, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=38, KupacId = 8, PredstavaId = 5, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=39, KupacId = 8, PredstavaId = 11, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=40, KupacId = 8, PredstavaId = 12, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=41, KupacId = 8, PredstavaId = 14, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 6) });
                                                                 
            //#9 Kupac - Predstave 1, 2, 4, 5, 9, 11, 12, 13, 14, 15, 16
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=42, KupacId = 9, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=43, KupacId = 9, PredstavaId = 2, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=44, KupacId = 9, PredstavaId = 4, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=45, KupacId = 9, PredstavaId = 5, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=46, KupacId = 9, PredstavaId = 9, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=47, KupacId = 9, PredstavaId = 11, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 6) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=48, KupacId = 9, PredstavaId = 12, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 7) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=49, KupacId = 9, PredstavaId = 13, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 8) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=50, KupacId = 9, PredstavaId = 14, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 9) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=51, KupacId = 9, PredstavaId = 15, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 10) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=52, KupacId = 9, PredstavaId = 16, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 11) });
                                                                 
            //#10 Kupac - Predstave 1, 3, 6, 9, 10, 11, 12, 13, ,14, 16
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=53, KupacId = 10, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=54, KupacId = 10, PredstavaId = 3, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=55, KupacId = 10, PredstavaId = 6, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=56, KupacId = 10, PredstavaId = 9, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=57, KupacId = 10, PredstavaId = 10, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=58, KupacId = 10, PredstavaId = 11, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 6) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=59, KupacId = 10, PredstavaId = 12, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 7) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=60, KupacId = 10, PredstavaId = 13, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 8) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=61, KupacId = 10, PredstavaId = 14, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 9) });
            modelBuilder.Entity<Ocjene>().HasData(new Ocjene() { OcjenaId=62, KupacId = 10, PredstavaId = 16, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 11) });

        }
    }
}
