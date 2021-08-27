using Microsoft.EntityFrameworkCore;
using QRCoder;
using SaTeatar.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.WebAPI
{
    public class SetupService
    {
        public void Init(SaTeatarBpContext context)
        {
            context.Database.Migrate(); //pokrece migraciju

            //add new data or update

            if (!context.Uloge.Any(x => x.Naziv == "Administrator"))
            {
                context.Uloge.Add(new Uloge() { Naziv = "Administrator", Opis = "" });
                context.SaveChanges();
                context.Uloge.Add(new Uloge() { Naziv = "Moderator", Opis = "" });
                context.SaveChanges();

            }

            if (!context.Korisnici.Any(x => x.KorisnickoIme == "desktop"))
            {
                context.Korisnici.Add(new Korisnici()
                {
                    Ime = "Desktop",
                    Prezime = "Desktopic",
                    KorisnickoIme = "desktop",
                    Email = "desktop@gmail.com",
                    LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                    Status = true
                });
                context.SaveChanges();

                context.Korisnici.Add(new Korisnici()
                {
                    Ime = "Moderator Prvi",
                    Prezime = "Moderatoric",
                    KorisnickoIme = "moderator prvi",
                    Email = "moderator@gmail.com",
                    LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                    Status = true
                });
                context.SaveChanges();

                context.Korisnici.Add(new Korisnici()
                {
                    Ime = "Moderator Drugi",
                    Prezime = "Moderatoric",
                    KorisnickoIme = "moderator drugi",
                    Email = "moderator@gmail.com",
                    LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                    Status = true
                });
                context.SaveChanges();
            }

            if (!context.Kupci.Any(x => x.KorisnickoIme == "mobile"))
            {
                //#1 mobile
                context.Kupci.Add(new Kupci()
                {
                    Ime = "Mobilni",
                    Prezime = "Mobilovic",
                    KorisnickoIme = "mobile",
                    DatumRegistracije = new DateTime(2021, 5, 2, 8, 0, 0),
                    Email = "mobilni@gmail.com",
                    Status = true,
                    LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                });
                context.SaveChanges();


                //#2 Pero Peric
                context.Kupci.Add(new Kupci()
                {
                    Ime = "Pero",
                    Prezime = "Peric",
                    KorisnickoIme = "pero.peric",
                    DatumRegistracije = new DateTime(2021, 5, 20, 8, 0, 0),
                    Email = "pero@gmail.com",
                    Status = true,
                    LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                });
                context.SaveChanges();


                //#3 Mare Maric
                context.Kupci.Add(new Kupci()
                {
                    Ime = "Mare",
                    Prezime = "Maric",
                    KorisnickoIme = "mare.maric",
                    DatumRegistracije = new DateTime(2021, 5, 20, 9, 0, 0),
                    Email = "mare@gmail.com",
                    Status = true,
                    LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                });
                context.SaveChanges();


                //#4 Niko Nikic
                context.Kupci.Add(new Kupci()
                {
                    Ime = "Niko",
                    Prezime = "Nikic",
                    KorisnickoIme = "niko.nikic",
                    DatumRegistracije = new DateTime(2021, 5, 20, 9, 30, 0),
                    Email = "niko@gmail.com",
                    Status = true,
                    LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                });
                context.SaveChanges();


                //#5 Luka Lukic
                context.Kupci.Add(new Kupci()
                {
                    Ime = "Luka",
                    Prezime = "Lukic",
                    KorisnickoIme = "luka.lukic",
                    DatumRegistracije = new DateTime(2021, 5, 20, 10, 0, 0),
                    Email = "luka@gmail.com",
                    Status = true,
                    LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                });
                context.SaveChanges();


                //#6 Tin Tinovic
                context.Kupci.Add(new Kupci()
                {
                    Ime = "Tin",
                    Prezime = "Tinovic",
                    KorisnickoIme = "tin.tinovic",
                    DatumRegistracije = new DateTime(2021, 5, 20, 11, 0, 0),
                    Email = "tin@gmail.com",
                    Status = true,
                    LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                });
                context.SaveChanges();


                //#7 Boro Boric
                context.Kupci.Add(new Kupci()
                {
                    Ime = "Boro",
                    Prezime = "Boric",
                    KorisnickoIme = "boro.boric",
                    DatumRegistracije = new DateTime(2021, 5, 20, 12, 0, 0),
                    Email = "boro@gmail.com",
                    Status = true,
                    LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                });
                context.SaveChanges();


                //#8 Drago Dragic
                context.Kupci.Add(new Kupci()
                {
                    Ime = "Drago",
                    Prezime = "Dragic",
                    KorisnickoIme = "drago.dragic",
                    DatumRegistracije = new DateTime(2021, 5, 20, 13, 0, 0),
                    Email = "drago@gmail.com",
                    Status = true,
                    LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                });
                context.SaveChanges();


                //#9 Ljubo Ljubic
                context.Kupci.Add(new Kupci()
                {
                    Ime = "Ljubo",
                    Prezime = "Ljubic",
                    KorisnickoIme = "ljubo.ljubic",
                    DatumRegistracije = new DateTime(2021, 5, 20, 14, 0, 0),
                    Email = "ljubo@gmail.com",
                    Status = true,
                    LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                });
                context.SaveChanges();


                //#10 Aleks Aleksic
                context.Kupci.Add(new Kupci()
                {
                    Ime = "Aleks",
                    Prezime = "Aleksic",
                    KorisnickoIme = "aleks.aleksic",
                    DatumRegistracije = new DateTime(2021, 5, 20, 15, 0, 0),
                    Email = "aleks.aleksic@gmail.com",
                    Status = true,
                    LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                });
                context.SaveChanges();

            }

            if (!context.Pozorista.Any(x => x.Naziv == "Kamerni teatar 55"))
            {
                //#1 Kamerni teatar 55
                context.Pozorista.Add(new Pozorista()
                {
                    Naziv = "Kamerni teatar 55",
                    Adresa = "Maršala Tita 56/II",
                    Logo = File.ReadAllBytes("Images/pozoriste.jpg")
                });
                context.SaveChanges();

                //#2 Narodno pozoriste Sarajevo
                context.Pozorista.Add(new Pozorista()
                {
                    Naziv = "Narodno pozoriste Sarajevo",
                    Adresa = "Obala Kulina bana 9",
                    Logo = File.ReadAllBytes("Images/pozoriste.jpg")
                });
                context.SaveChanges();

                //#3 Sartr
                context.Pozorista.Add(new Pozorista()
                {
                    Naziv = "Sartr",
                    Adresa = "Gabelina 16",
                    Logo = File.ReadAllBytes("Images/pozoriste.jpg")
                });
                context.SaveChanges();

                //#4 Pozoriste mladih Sarajevo
                context.Pozorista.Add(new Pozorista()
                {
                    Naziv = "Pozoriste mladih Sarajevo",
                    Adresa = "Kulovica 8",
                    Logo = File.ReadAllBytes("Images/pozoriste.jpg")
                });
                context.SaveChanges();

            }

            if (!context.TipoviPredstava.Any(x => x.Naziv == "Drama"))
            {
                context.TipoviPredstava.Add(new TipoviPredstava() { Naziv = "Drama" });
                context.SaveChanges();
                context.TipoviPredstava.Add(new TipoviPredstava() { Naziv = "Balet" });
                context.SaveChanges();
                context.TipoviPredstava.Add(new TipoviPredstava() { Naziv = "Opera" });
                context.SaveChanges();

            }

            if (!context.VrsteDjelatnika.Any(x => x.Naziv == "Reziser"))
            {
                context.VrsteDjelatnika.Add(new VrsteDjelatnika() { Naziv = "Reziser" });
                context.SaveChanges();
                context.VrsteDjelatnika.Add(new VrsteDjelatnika() { Naziv = "Gumac" });
                context.SaveChanges();
                context.VrsteDjelatnika.Add(new VrsteDjelatnika() { Naziv = "Koreograf" });
                context.SaveChanges();

            }

            if (!context.KorisniciUloge.Any(x => x.KorisnikId == 1))
            {
                context.KorisniciUloge.Add(new KorisniciUloge() { KorisnikId = 1, UlogaId = 1, DatumIzmjene = new DateTime(2021, 5, 1, 8, 0, 0) });
                context.KorisniciUloge.Add(new KorisniciUloge() { KorisnikId = 2, UlogaId = 2, DatumIzmjene = new DateTime(2021, 5, 1, 9, 0, 0) });
                context.KorisniciUloge.Add(new KorisniciUloge() { KorisnikId = 3, UlogaId = 2, DatumIzmjene = new DateTime(2021, 5, 1, 10, 0, 0) });
            }

            if (!context.Zone.Any(x => x.PozoristeId == 1))
            {
                //#1 Kamerni teatar 55
                context.Zone.Add(new Zone() { Naziv = "Zona I", PozoristeId = 1, UkupanBrojSjedista = 15 });
                context.SaveChanges();
                context.Zone.Add(new Zone() { Naziv = "Zona II", PozoristeId = 1, UkupanBrojSjedista = 45 });
                context.SaveChanges();
                context.Zone.Add(new Zone() { Naziv = "Zona III", PozoristeId = 1, UkupanBrojSjedista = 135 });
                context.SaveChanges();

                //#2 Narodno pozoriste Sarajevo
                context.Zone.Add(new Zone() { Naziv = "VIP", PozoristeId = 2, UkupanBrojSjedista = 15 });
                context.SaveChanges();
                context.Zone.Add(new Zone() { Naziv = "Zona A", PozoristeId = 2, UkupanBrojSjedista = 30 });
                context.SaveChanges();
                context.Zone.Add(new Zone() { Naziv = "Zona B", PozoristeId = 2, UkupanBrojSjedista = 90 });
                context.SaveChanges();
                context.Zone.Add(new Zone() { Naziv = "Zona C", PozoristeId = 2, UkupanBrojSjedista = 180 });
                context.SaveChanges();

                //#3 Sartr
                context.SaveChanges();
                context.Zone.Add(new Zone() { Naziv = "Zona 1", PozoristeId = 3, UkupanBrojSjedista = 10 });
                context.SaveChanges();
                context.Zone.Add(new Zone() { Naziv = "Zona 2", PozoristeId = 3, UkupanBrojSjedista = 30 });
                context.SaveChanges();
                context.Zone.Add(new Zone() { Naziv = "Zona 3", PozoristeId = 3, UkupanBrojSjedista = 40 });
                context.SaveChanges();

                //#4 Pozoriste mladih Sarajevo
                context.Zone.Add(new Zone() { Naziv = "Zona Srednja", PozoristeId = 4, UkupanBrojSjedista = 20 });
                context.SaveChanges();
                context.Zone.Add(new Zone() { Naziv = "Zona Desna", PozoristeId = 4, UkupanBrojSjedista = 40 });
                context.SaveChanges();
                context.Zone.Add(new Zone() { Naziv = "Zona Lijeva", PozoristeId = 4, UkupanBrojSjedista = 120 });
                context.SaveChanges();

            }

            if (!context.Predstave.Any(x => x.Naziv == "Helverova noc"))
            {
                //#1 Helverova noc
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Helverova noc",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
                //#2 Mirna Bosna
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Mirna Bosna",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
                //#3 Knjiga mojih zivota
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Knjiga mojih zivota",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
                //#4 Tajna dzema od malina
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Tajna dzema od malina",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
                //#5 Ay Carmela
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Ay, Carmela",
                    Opis = "...",
                    Status = false,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
                //#6 Dogville
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Dogville",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
                //#7 Snijeg
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Snijeg",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
                //#8 Princeza na zrnu graska
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Princeza na zrnu graska",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
                //#9 Zaljubljeni krokodil
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Zaljubljeni krokodil",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
                //#10 Patkica Blatkica
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Patkica Blatkica",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
                //#11 Okovani prometej
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Okovani prometej",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 2,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
                //#12 Palcica
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Palcica",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 2,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
                //#13 Uspavana ljepotica
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Uspavana ljepotica",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 2,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
                //#14 La Traviata
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "La Traviata",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 3,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
                //#15 Don Giovanni
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Don Giovanni",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 3,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
                //#16 Rigoletto
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Rigoletto",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 3,
                    Slika = File.ReadAllBytes("Images/predstava.jpg")
                });
                context.SaveChanges();
            }

            if (!context.Djelatnici.Any(x => x.Ime == "Dino"))
            {
                //#1 Dino Mustafic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Dino",
                    Prezime = "Mustafic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#2 Mirjana Karanovic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Mirjana",
                    Prezime = "Karanovic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#3 Ermin Bravo
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Ermin",
                    Prezime = "Bravo",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#4 Sasa Pesevski
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Sasa",
                    Prezime = "Pesevski",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#5 Fedja Stukan
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Fedja",
                    Prezime = "Stukan",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#6 Gordana Boban
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Gordana",
                    Prezime = "Boban",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#7 Sabrina Begovic Coric
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Sabrina",
                    Prezime = "Begovic Coric",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#8 Boris Ler
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Boris",
                    Prezime = "Ler",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#9 Maja Izetbegovic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Maja",
                    Prezime = "Izetbegovic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#10 Selma Spahic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Selma",
                    Prezime = "Spahic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#11 Snjezana Alic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Snjezana",
                    Prezime = "Alic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#12 Alban Ukaj
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Alban",
                    Prezime = "Ukaj",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#13 Robert Raponja
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Robert",
                    Prezime = "Raponja",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#14 Selma Alispahic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Selma",
                    Prezime = "Alispahic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#15 Dragan Jovicic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Dragan",
                    Prezime = "Jovicic",
                    Biografija = "...",
                    Status = false,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#16 Lajla Kaikcija
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Lajla",
                    Prezime = "Kaikcija",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#17 Amra Kapidzic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Amra",
                    Prezime = "Kapidzic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#18 Ermin Sijamija
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Ermin",
                    Prezime = "Sijamija",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#19 Aleksandar Seksan
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Aleksandar",
                    Prezime = "Seksan",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#20 Daniela Gogic 
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Daniela",
                    Prezime = "Gogic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#21 Mario Drmac
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Mario",
                    Prezime = "Drmac",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#22 Belma Lizde Kurt
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Belma",
                    Prezime = "Lizde Kurt",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#23  Irfan Avdic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Irfan",
                    Prezime = "Avdic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#24 Sanin Milavic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Sanin",
                    Prezime = "Milavic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#25 Semir Krivic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Semir",
                    Prezime = "Krivic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#26  Drago Buka 
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Drago",
                    Prezime = "Buka",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#27 Alma Merunka
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Alma",
                    Prezime = "Merunka",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#28 Ajla Cabrera
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Ajla",
                    Prezime = "Cabrera",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#29 Belma Ceco Bakrac
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Belma",
                    Prezime = "Ceco Bakrac",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 3,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#30 Milan Rus
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Milan",
                    Prezime = "Rus",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#31 Tamara Ljubičić
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Tamara",
                    Prezime = "Ljubicic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#32 Nermina Damian
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Nermina",
                    Prezime = "Damian",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 3,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#33 Natasa Gaponko
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Natasa",
                    Prezime = "Gaponko",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#34 Ekaterina Verescagina
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Ekaterina",
                    Prezime = "Verescagina",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#35 Dinko Bogdanic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Dinko",
                    Prezime = "Bogdanic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 3,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#36 Adnan Djindo
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Adnan",
                    Prezime = "Djindo",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#37 Dajana Zilic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Dajana",
                    Prezime = "Zilic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#38  Ognian Draganoff
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Ognian",
                    Prezime = "Draganoff",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#39 Martina Zadro
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Martina",
                    Prezime = "Zadro",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#40 Amir Saracevic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Amir",
                    Prezime = "Saracevic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#41 Aleksandar Nikolic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Aleksandar",
                    Prezime = "Nikolic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#42 Marko Kalajanovic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Marko",
                    Prezime = "Kalajanovic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#43 Leonardo Saric
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Leonardo",
                    Prezime = "Saric",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();
                //#44 Dragutin Matic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Dragutin",
                    Prezime = "Matic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici.jpg")
                });
                context.SaveChanges();

            }

            if (!context.PredstaveDjelatnici.Any(x => x.DjelatnikId == 1))
            {
                //#1 Helverova noc
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 1, DjelatnikId = 1 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 1, DjelatnikId = 2 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 1, DjelatnikId = 3 });

                //#2 Mirna Bosna
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 2, DjelatnikId = 4 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 2, DjelatnikId = 5 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 2, DjelatnikId = 6 });

                //3 Knjiga mojih zivota
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 3, DjelatnikId = 7 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 3, DjelatnikId = 8 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 3, DjelatnikId = 9 });

                //#4 Tajna dzema od malina
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 4, DjelatnikId = 10 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 4, DjelatnikId = 11 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 4, DjelatnikId = 12 });

                //#5 Ay Carmela
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 5, DjelatnikId = 13 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 5, DjelatnikId = 14 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 5, DjelatnikId = 15 });

                //#6 Dogville
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 6, DjelatnikId = 16 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 6, DjelatnikId = 17 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 6, DjelatnikId = 18 });

                //#7 Snijeg
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 7, DjelatnikId = 1 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 7, DjelatnikId = 17 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 7, DjelatnikId = 19 });

                //#8 Princeza na zrnu graska
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 8, DjelatnikId = 20 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 8, DjelatnikId = 21 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 8, DjelatnikId = 22 });

                //#9 Zaljubljeni krokodil
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 9, DjelatnikId = 26 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 9, DjelatnikId = 27 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 9, DjelatnikId = 28 });

                //#10 Patkica Blatkica
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 10, DjelatnikId = 23 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 10, DjelatnikId = 24 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 10, DjelatnikId = 25 });

                //#11 Okovani prometej
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 11, DjelatnikId = 29 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 11, DjelatnikId = 30 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 11, DjelatnikId = 31 });

                //#12 Palcica
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 12, DjelatnikId = 32 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 12, DjelatnikId = 33 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 12, DjelatnikId = 34 });

                //#13 Uspavana ljepotica
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 13, DjelatnikId = 35 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 13, DjelatnikId = 36 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 13, DjelatnikId = 37 });

                //#14 La Traviata
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 14, DjelatnikId = 38 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 14, DjelatnikId = 39 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 14, DjelatnikId = 40 });

                //#15 Don Giovanni
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 15, DjelatnikId = 41 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 15, DjelatnikId = 42 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 15, DjelatnikId = 43 });

                //#16 Rigoletto
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 16, DjelatnikId = 38 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 16, DjelatnikId = 40 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 16, DjelatnikId = 44 });

            }

            if (!context.Izvodjenja.Any(x => x.PredstavaId == 1))
            {
                //#1 Helverova noc 1/10/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 1,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 10, 1, 20, 0, 0),
                });
                context.SaveChanges();

                //#2 Mirna Bosna 3/10/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 2,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 10, 3, 20, 0, 0),
                });
                context.SaveChanges();

                //#3 Knjiga mojih zivota 5/10/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 3,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 10, 5, 20, 0, 0),
                });
                context.SaveChanges();

                //#4 Tajna dzema od malina 2/10/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 4,
                    PozoristeId = 3,
                    Napomena = "",
                    KorisnikId = 3,
                    DatumVrijeme = new DateTime(2021, 10, 2, 20, 0, 0),
                });
                context.SaveChanges();

                //#5 Dogville 1/10/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 6,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 10, 1, 20, 0, 0),
                });
                context.SaveChanges();

                //#6 Snijeg 2/10/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 7,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 10, 2, 20, 0, 0),
                });
                context.SaveChanges();

                //#7 Princeza na zrnu graska 2/11/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 8,
                    PozoristeId = 4,
                    Napomena = "",
                    KorisnikId = 3,
                    DatumVrijeme = new DateTime(2021, 11, 2, 15, 0, 0),
                });
                context.SaveChanges();

                //#8 Zaljubljeni krokodil 3/11/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 9,
                    PozoristeId = 4,
                    Napomena = "",
                    KorisnikId = 3,
                    DatumVrijeme = new DateTime(2021, 11, 3, 15, 0, 0),
                });
                context.SaveChanges();

                //#9 Patkica Blatkica 4/11/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 10,
                    PozoristeId = 4,
                    Napomena = "",
                    KorisnikId = 3,
                    DatumVrijeme = new DateTime(2021, 11, 4, 14, 0, 0),
                });
                context.SaveChanges();

                //#10 Okovani prometej 5/10/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 11,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 10, 5, 20, 0, 0),
                });
                context.SaveChanges();

                //#11 Uspavana ljepotica 12/11/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 13,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 11, 12, 21, 0, 0),
                });
                context.SaveChanges();

                //#12 La Traviata 6/11/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 14,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 11, 6, 21, 0, 0),
                });
                context.SaveChanges();

            }

            if (!context.IzvodjenjaZone.Any(x => x.IzvodjenjeId == 1))
            {
                //#1 Helverova noc 1/10/21
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 1,
                    ZonaId = 1,
                    Cijena = 20,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 1,
                    ZonaId = 2,
                    Cijena = 10,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 1,
                    ZonaId = 3,
                    Cijena = 5,

                });
                context.SaveChanges();

                //#2 Mirna Bosna 3/10/21
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 2,
                    ZonaId = 1,
                    Cijena = 15,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 2,
                    ZonaId = 2,
                    Cijena = 10,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 2,
                    ZonaId = 3,
                    Cijena = 5,

                });
                context.SaveChanges();

                //#3 Knjiga mojih zivota 5/10/21
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 3,
                    ZonaId = 1,
                    Cijena = 10,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 3,
                    ZonaId = 2,
                    Cijena = 7,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 3,
                    ZonaId = 3,
                    Cijena = 5,

                });
                context.SaveChanges();

                //#4 Tajna dzema od malina 2/10/21
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 4,
                    ZonaId = 8,
                    Cijena = 15,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 4,
                    ZonaId = 9,
                    Cijena = 10,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 4,
                    ZonaId = 10,
                    Cijena = 5,

                });
                context.SaveChanges();

                //#5 Dogville 1/10/21
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 5,
                    ZonaId = 4,
                    Cijena = 20,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 5,
                    ZonaId = 5,
                    Cijena = 15,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 5,
                    ZonaId = 6,
                    Cijena = 10,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 5,
                    ZonaId = 7,
                    Cijena = 5,

                });
                context.SaveChanges();

                //#6 Snijeg 2/10/21
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 6,
                    ZonaId = 4,
                    Cijena = 20,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 6,
                    ZonaId = 5,
                    Cijena = 15,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 6,
                    ZonaId = 6,
                    Cijena = 10,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 6,
                    ZonaId = 7,
                    Cijena = 5,

                });
                context.SaveChanges();


                //#7 Princeza na zrnu graska 2/11/21
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 7,
                    ZonaId = 11,
                    Cijena = 15,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 7,
                    ZonaId = 12,
                    Cijena = 10,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 7,
                    ZonaId = 13,
                    Cijena = 5,

                });
                context.SaveChanges();


                //#8 Zaljubljeni krokodil 3/11/21
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 8,
                    ZonaId = 11,
                    Cijena = 15,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 8,
                    ZonaId = 12,
                    Cijena = 10,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 8,
                    ZonaId = 13,
                    Cijena = 5,

                });
                context.SaveChanges();

                //#9 Patkica Blatkica 4/11/21
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 9,
                    ZonaId = 11,
                    Cijena = 15,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 9,
                    ZonaId = 12,
                    Cijena = 10,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 9,
                    ZonaId = 13,
                    Cijena = 5,

                });
                context.SaveChanges();

                //#10 Okovani prometej 5/10/21
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 10,
                    ZonaId = 4,
                    Cijena = 40,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 10,
                    ZonaId = 5,
                    Cijena = 30,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 10,
                    ZonaId = 6,
                    Cijena = 20,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 10,
                    ZonaId = 7,
                    Cijena = 10,

                });
                context.SaveChanges();


                //#11 Uspavana ljepotica 12/11/21
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 11,
                    ZonaId = 4,
                    Cijena = 40,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 11,
                    ZonaId = 5,
                    Cijena = 30,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 11,
                    ZonaId = 6,
                    Cijena = 20,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 11,
                    ZonaId = 7,
                    Cijena = 10,

                });
                context.SaveChanges();

                //#12 La Traviata 6/11/21
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 12,
                    ZonaId = 4,
                    Cijena = 40,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 12,
                    ZonaId = 5,
                    Cijena = 30,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 12,
                    ZonaId = 6,
                    Cijena = 20,

                });
                context.SaveChanges();

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 12,
                    ZonaId = 7,
                    Cijena = 10,

                });
                context.SaveChanges();

            }

            if (!context.Karte.Any(x => x.KupacId == 1))
            {
                var DatumNarudzbe = new DateTime(2021, 8, 1, 20, 0, 0);
                var paymentId = "xyz";


                /////////

                //k 1,2
                context.Karte.Add(new Karte() { IzvodjenjeId = 1, KupacId = 1, IzvodjenjeZonaId = 1, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 1, KupacId = 1, IzvodjenjeZonaId = 1, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n1
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe, Iznos = 40, PaymentId = paymentId, KupacId = 1 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 1, NarudzbaId = 1 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 2, NarudzbaId = 1 });
                context.SaveChanges();

                //k 3,4
                context.Karte.Add(new Karte() { IzvodjenjeId = 1, KupacId = 2, IzvodjenjeZonaId = 2, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 1, KupacId = 2, IzvodjenjeZonaId = 2, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n2
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(1), Iznos = 20, PaymentId = paymentId, KupacId = 2 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 3, NarudzbaId = 2 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 4, NarudzbaId = 2 });
                context.SaveChanges();

                //k 5,6
                context.Karte.Add(new Karte() { IzvodjenjeId = 1, KupacId = 3, IzvodjenjeZonaId = 3, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 1, KupacId = 3, IzvodjenjeZonaId = 3, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n3
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(2), Iznos = 10, PaymentId = paymentId, KupacId = 3 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 5, NarudzbaId = 3 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 6, NarudzbaId = 3 });
                context.SaveChanges();

                /////////

                //k 7,8
                context.Karte.Add(new Karte() { IzvodjenjeId = 2, KupacId = 8, IzvodjenjeZonaId = 4, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 2, KupacId = 8, IzvodjenjeZonaId = 4, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n4
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(3), Iznos = 30, PaymentId = paymentId, KupacId = 8 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 7, NarudzbaId = 4 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 8, NarudzbaId = 4 });
                context.SaveChanges();

                //k 9,10
                context.Karte.Add(new Karte() { IzvodjenjeId = 2, KupacId = 4, IzvodjenjeZonaId = 6, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 2, KupacId = 4, IzvodjenjeZonaId = 6, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n5
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(4), Iznos = 10, PaymentId = paymentId, KupacId = 4 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 9, NarudzbaId = 5 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 10, NarudzbaId = 5 });
                context.SaveChanges();

                ///// 
                //k 11,12
                context.Karte.Add(new Karte() { IzvodjenjeId = 3, KupacId = 1, IzvodjenjeZonaId = 7, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 3, KupacId = 1, IzvodjenjeZonaId = 7, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n6
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(5), Iznos = 20, PaymentId = paymentId, KupacId = 1 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 11, NarudzbaId = 6 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 12, NarudzbaId = 6 });
                context.SaveChanges();

                //k 13,14
                context.Karte.Add(new Karte() { IzvodjenjeId = 3, KupacId = 3, IzvodjenjeZonaId = 8, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 3, KupacId = 3, IzvodjenjeZonaId = 8, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n7
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(6), Iznos = 14, PaymentId = paymentId, KupacId = 3 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 13, NarudzbaId = 7 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 14, NarudzbaId = 7 });
                context.SaveChanges();

                //////////

                //k 15,16
                context.Karte.Add(new Karte() { IzvodjenjeId = 4, KupacId = 5, IzvodjenjeZonaId = 11, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 4, KupacId = 5, IzvodjenjeZonaId = 11, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n8
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(7), Iznos = 20, PaymentId = paymentId, KupacId = 5 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 15, NarudzbaId = 8 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 16, NarudzbaId = 8 });
                context.SaveChanges();

                //k 17,18
                context.Karte.Add(new Karte() { IzvodjenjeId = 4, KupacId = 9, IzvodjenjeZonaId = 12, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 4, KupacId = 9, IzvodjenjeZonaId = 12, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n9
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(8), Iznos = 10, PaymentId = paymentId, KupacId = 9 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 17, NarudzbaId = 9 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 18, NarudzbaId = 9 });
                context.SaveChanges();

                //////
                //k 19,20
                context.Karte.Add(new Karte() { IzvodjenjeId = 5, KupacId = 2, IzvodjenjeZonaId = 13, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 5, KupacId = 2, IzvodjenjeZonaId = 13, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n10
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(9), Iznos = 40, PaymentId = paymentId, KupacId = 2 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 19, NarudzbaId = 10 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 20, NarudzbaId = 10 });
                context.SaveChanges();

                // k 21,22                                                                                                   
                context.Karte.Add(new Karte() { IzvodjenjeId = 5, KupacId = 6, IzvodjenjeZonaId = 16, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 5, KupacId = 6, IzvodjenjeZonaId = 16, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n11
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(10), Iznos = 10, PaymentId = paymentId, KupacId = 6 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 21, NarudzbaId = 11 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 22, NarudzbaId = 11 });
                context.SaveChanges();

                ////
                //k 23, 24
                context.Karte.Add(new Karte() { IzvodjenjeId = 6, KupacId = 8, IzvodjenjeZonaId = 18, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 6, KupacId = 8, IzvodjenjeZonaId = 18, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n12
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(11), Iznos = 30, PaymentId = paymentId, KupacId = 8 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 23, NarudzbaId = 12 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 24, NarudzbaId = 12 });
                context.SaveChanges();

                //k 25,26
                context.Karte.Add(new Karte() { IzvodjenjeId = 6, KupacId = 10, IzvodjenjeZonaId = 19, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 6, KupacId = 10, IzvodjenjeZonaId = 19, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n13
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(12), Iznos = 20, PaymentId = paymentId, KupacId = 10 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 25, NarudzbaId = 13 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 26, NarudzbaId = 13 });
                context.SaveChanges();


                //k 27,28
                context.Karte.Add(new Karte() { IzvodjenjeId = 7, KupacId = 1, IzvodjenjeZonaId = 22, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 7, KupacId = 1, IzvodjenjeZonaId = 22, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n14
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(13), Iznos = 20, PaymentId = string.Empty, KupacId = 1 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 27, NarudzbaId = 14 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 28, NarudzbaId = 14 });
                context.SaveChanges();

                //k 29, 30
                context.Karte.Add(new Karte() { IzvodjenjeId = 7, KupacId = 5, IzvodjenjeZonaId = 23, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 7, KupacId = 5, IzvodjenjeZonaId = 23, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n15
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(14), Iznos = 10, PaymentId = paymentId, KupacId = 5 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 29, NarudzbaId = 15 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 30, NarudzbaId = 15 });
                context.SaveChanges();

                //k 31,32,33
                context.Karte.Add(new Karte() { IzvodjenjeId = 8, KupacId = 7, IzvodjenjeZonaId = 25, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 8, KupacId = 7, IzvodjenjeZonaId = 25, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 8, KupacId = 7, IzvodjenjeZonaId = 25, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n16
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(15), Iznos = 30, PaymentId = paymentId, KupacId = 7 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 31, NarudzbaId = 16 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 32, NarudzbaId = 16 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 33, NarudzbaId = 16 });
                context.SaveChanges();

                //k 34, 35
                context.Karte.Add(new Karte() { IzvodjenjeId = 9, KupacId = 9, IzvodjenjeZonaId = 27, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 9, KupacId = 9, IzvodjenjeZonaId = 27, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n17
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(16), Iznos = 30, PaymentId = paymentId, KupacId = 9 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 34, NarudzbaId = 17 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 35, NarudzbaId = 17 });
                context.SaveChanges();

                //k 36,37,38,39
                context.Karte.Add(new Karte() { IzvodjenjeId = 10, KupacId = 4, IzvodjenjeZonaId = 30, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 10, KupacId = 4, IzvodjenjeZonaId = 30, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 10, KupacId = 4, IzvodjenjeZonaId = 30, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 10, KupacId = 4, IzvodjenjeZonaId = 30, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n18
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(17), Iznos = 160, PaymentId = paymentId, KupacId = 4 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 36, NarudzbaId = 18 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 37, NarudzbaId = 18 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 38, NarudzbaId = 18 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 39, NarudzbaId = 18 });
                context.SaveChanges();

                //k 40,41,42
                context.Karte.Add(new Karte() { IzvodjenjeId = 11, KupacId = 6, IzvodjenjeZonaId = 35, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 11, KupacId = 6, IzvodjenjeZonaId = 35, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 11, KupacId = 6, IzvodjenjeZonaId = 35, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n19
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(18), Iznos = 90, PaymentId = paymentId, KupacId = 6 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 40, NarudzbaId = 19 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 41, NarudzbaId = 19 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 42, NarudzbaId = 19 });
                context.SaveChanges();

                //k 43,44
                context.Karte.Add(new Karte() { IzvodjenjeId = 12, KupacId = 7, IzvodjenjeZonaId = 38, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 12, KupacId = 7, IzvodjenjeZonaId = 38, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n20
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(19), Iznos = 80, PaymentId = paymentId, KupacId = 7 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 43, NarudzbaId = 20 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 44, NarudzbaId = 20 });
                context.SaveChanges();

                //k 45,46
                context.Karte.Add(new Karte() { IzvodjenjeId = 12, KupacId = 10, IzvodjenjeZonaId = 41, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();
                context.Karte.Add(new Karte() { IzvodjenjeId = 12, KupacId = 10, IzvodjenjeZonaId = 41, Placeno = true, Qrcode = null, BrKarte = Guid.NewGuid() });
                context.SaveChanges();

                //n21
                context.Narudzba.Add(new Narudzba() { BrNarudzbe = Guid.NewGuid(), Datum = DatumNarudzbe.AddDays(20), Iznos = 20, PaymentId = paymentId, KupacId = 10 });
                context.SaveChanges();
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 45, NarudzbaId = 21 });
                context.NarudzbaStavke.Add(new NarudzbaStavke() { KartaId = 46, NarudzbaId = 21 });
                context.SaveChanges();

                var karte = context.Karte.AsQueryable();
                foreach (var item in karte)
                {
                    item.Qrcode = GenerisiQrCode(item.BrKarte.ToString());
                    context.Karte.Update(item);
                }
                context.SaveChanges();


            }

            if (!context.Ocjene.Any(x => x.PredstavaId == 1))
            {
                //#1 Kupac - Predstave 1, 2, 4, 5, 9
                context.Ocjene.Add(new Ocjene() { KupacId = 1, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
                context.Ocjene.Add(new Ocjene() { KupacId = 1, PredstavaId = 2, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
                context.Ocjene.Add(new Ocjene() { KupacId = 1, PredstavaId = 4, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
                context.Ocjene.Add(new Ocjene() { KupacId = 1, PredstavaId = 5, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
                context.Ocjene.Add(new Ocjene() { KupacId = 1, PredstavaId = 9, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });

                //#2 Kupac - Predstave 1, 3, 5, 8, 13
                context.Ocjene.Add(new Ocjene() { KupacId = 2, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
                context.Ocjene.Add(new Ocjene() { KupacId = 2, PredstavaId = 3, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
                context.Ocjene.Add(new Ocjene() { KupacId = 2, PredstavaId = 5, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
                context.Ocjene.Add(new Ocjene() { KupacId = 2, PredstavaId = 8, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
                context.Ocjene.Add(new Ocjene() { KupacId = 2, PredstavaId = 13, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });

                //#3 Kupac - Predstave 2, 6, 7, 8, 10, 13
                context.Ocjene.Add(new Ocjene() { KupacId = 3, PredstavaId = 2, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
                context.Ocjene.Add(new Ocjene() { KupacId = 3, PredstavaId = 6, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
                context.Ocjene.Add(new Ocjene() { KupacId = 3, PredstavaId = 7, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
                context.Ocjene.Add(new Ocjene() { KupacId = 3, PredstavaId = 8, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
                context.Ocjene.Add(new Ocjene() { KupacId = 3, PredstavaId = 10, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
                context.Ocjene.Add(new Ocjene() { KupacId = 3, PredstavaId = 13, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 6) });

                //#4 Kupac - Predstave 1, 7, 11
                context.Ocjene.Add(new Ocjene() { KupacId = 4, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
                context.Ocjene.Add(new Ocjene() { KupacId = 4, PredstavaId = 7, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
                context.Ocjene.Add(new Ocjene() { KupacId = 4, PredstavaId = 11, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 6) });

                //#5 Kupac - Predstave 1, 2, 4, 12, 16
                context.Ocjene.Add(new Ocjene() { KupacId = 5, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
                context.Ocjene.Add(new Ocjene() { KupacId = 5, PredstavaId = 2, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
                context.Ocjene.Add(new Ocjene() { KupacId = 5, PredstavaId = 4, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
                context.Ocjene.Add(new Ocjene() { KupacId = 5, PredstavaId = 12, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
                context.Ocjene.Add(new Ocjene() { KupacId = 5, PredstavaId = 16, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });

                //#6 Kupac - Predstave 3, 8, 10, 15, 16
                context.Ocjene.Add(new Ocjene() { KupacId = 6, PredstavaId = 3, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
                context.Ocjene.Add(new Ocjene() { KupacId = 6, PredstavaId = 8, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
                context.Ocjene.Add(new Ocjene() { KupacId = 6, PredstavaId = 10, Ocjena = 1, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
                context.Ocjene.Add(new Ocjene() { KupacId = 6, PredstavaId = 15, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
                context.Ocjene.Add(new Ocjene() { KupacId = 6, PredstavaId = 16, Ocjena = 1, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });

                //#7 Kupac - Predstave 1, 4, 5, 6, 7, 14
                context.Ocjene.Add(new Ocjene() { KupacId = 7, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
                context.Ocjene.Add(new Ocjene() { KupacId = 7, PredstavaId = 4, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
                context.Ocjene.Add(new Ocjene() { KupacId = 7, PredstavaId = 5, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
                context.Ocjene.Add(new Ocjene() { KupacId = 7, PredstavaId = 6, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
                context.Ocjene.Add(new Ocjene() { KupacId = 7, PredstavaId = 7, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
                context.Ocjene.Add(new Ocjene() { KupacId = 7, PredstavaId = 14, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 6) });

                //#8 Kupac - Predstave 1, 3, 5, 11, 12, 15
                context.Ocjene.Add(new Ocjene() { KupacId = 8, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
                context.Ocjene.Add(new Ocjene() { KupacId = 8, PredstavaId = 3, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
                context.Ocjene.Add(new Ocjene() { KupacId = 8, PredstavaId = 5, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
                context.Ocjene.Add(new Ocjene() { KupacId = 8, PredstavaId = 11, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
                context.Ocjene.Add(new Ocjene() { KupacId = 8, PredstavaId = 12, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
                context.Ocjene.Add(new Ocjene() { KupacId = 8, PredstavaId = 14, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 6) });

                //#9 Kupac - Predstave 1, 2, 4, 5, 9, 11, 12, 13, 14, 15, 16
                context.Ocjene.Add(new Ocjene() { KupacId = 9, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
                context.Ocjene.Add(new Ocjene() { KupacId = 9, PredstavaId = 2, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
                context.Ocjene.Add(new Ocjene() { KupacId = 9, PredstavaId = 4, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
                context.Ocjene.Add(new Ocjene() { KupacId = 9, PredstavaId = 5, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
                context.Ocjene.Add(new Ocjene() { KupacId = 9, PredstavaId = 9, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
                context.Ocjene.Add(new Ocjene() { KupacId = 9, PredstavaId = 11, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 6) });
                context.Ocjene.Add(new Ocjene() { KupacId = 9, PredstavaId = 12, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 7) });
                context.Ocjene.Add(new Ocjene() { KupacId = 9, PredstavaId = 13, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 8) });
                context.Ocjene.Add(new Ocjene() { KupacId = 9, PredstavaId = 14, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 9) });
                context.Ocjene.Add(new Ocjene() { KupacId = 9, PredstavaId = 15, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 10) });
                context.Ocjene.Add(new Ocjene() { KupacId = 9, PredstavaId = 16, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 11) });

                //#10 Kupac - Predstave 1, 3, 6, 9, 10, 11, 12, 13, 14, 16
                context.Ocjene.Add(new Ocjene() { KupacId = 10, PredstavaId = 1, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 1) });
                context.Ocjene.Add(new Ocjene() { KupacId = 10, PredstavaId = 3, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 2) });
                context.Ocjene.Add(new Ocjene() { KupacId = 10, PredstavaId = 6, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 3) });
                context.Ocjene.Add(new Ocjene() { KupacId = 10, PredstavaId = 9, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 4) });
                context.Ocjene.Add(new Ocjene() { KupacId = 10, PredstavaId = 10, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 5) });
                context.Ocjene.Add(new Ocjene() { KupacId = 10, PredstavaId = 11, Ocjena = 2, Opis = "...opis...", Datum = new DateTime(2021, 7, 6) });
                context.Ocjene.Add(new Ocjene() { KupacId = 10, PredstavaId = 12, Ocjena = 3, Opis = "...opis...", Datum = new DateTime(2021, 7, 7) });
                context.Ocjene.Add(new Ocjene() { KupacId = 10, PredstavaId = 13, Ocjena = 5, Opis = "...opis...", Datum = new DateTime(2021, 7, 8) });
                context.Ocjene.Add(new Ocjene() { KupacId = 10, PredstavaId = 14, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 9) });
                context.Ocjene.Add(new Ocjene() { KupacId = 10, PredstavaId = 16, Ocjena = 4, Opis = "...opis...", Datum = new DateTime(2021, 7, 11) });

            }

            context.SaveChanges();

        }

        byte[] GenerisiQrCode(string InputText)
        {
            if (string.IsNullOrEmpty(InputText))
                InputText = "";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(InputText, QRCodeGenerator.ECCLevel.M);
            PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
            return qRCode.GetGraphic(20);
        }
    }
}
