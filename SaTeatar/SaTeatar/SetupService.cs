using Microsoft.EntityFrameworkCore;
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
        public void Init(SaTeatarDbContext context)
        {
            context.Database.Migrate(); //pokrece migraciju

            //add new data or update

            if (!context.Uloge.Any(x => x.Naziv == "Administrator"))
            {
                context.Uloge.Add(new Uloge() { Naziv = "Administrator", Opis = "" });
                context.Uloge.Add(new Uloge() { Naziv = "Moderator", Opis = "" });
            }

            if (!context.Korisnici.Any(x => x.KorisnickoIme == "desktop"))
            {
                context.Korisnici.Add(new Korisnici() { 
                    Ime="Desktop", 
                    Prezime="Desktopic", 
                    KorisnickoIme="desktop", 
                    Email="desktop@gmail.com", 
                    LozinkaHash= "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=", 
                    LozinkaSalt= "zDeZ2nOy4yQ2a4/lJR6rJA==", 
                    Status=true });

                context.Korisnici.Add(new Korisnici()
                {
                    Ime = "Moderator Prvi",
                    Prezime = "Moderatoric",
                    KorisnickoIme = "moderator",
                    Email = "moderator@gmail.com",
                    LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                    Status = true
                });

                context.Korisnici.Add(new Korisnici()
                {
                    Ime = "Moderator Drugi",
                    Prezime = "Moderatoric",
                    KorisnickoIme = "moderator",
                    Email = "moderator@gmail.com",
                    LozinkaHash = "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt = "zDeZ2nOy4yQ2a4/lJR6rJA==",
                    Status = true
                });
            }

            if (!context.Kupci.Any(x=>x.KorisnickoIme=="mobile"))
            {
                //#1 mobile
                context.Kupci.Add(new Kupci()
                {
                    Ime = "Mobilni",
                    Prezime = "Mobilovic",
                    KorisnickoIme = "mobile",
                    DatumRegistracije = new DateTime(2021, 5, 2, 8, 0, 0),
                    Email= "mobilni@gmail.com",
                    Status=true,
                    LozinkaHash= "UNUL/8RuC8Yzyk/Jphk+Z8evbnQ=",
                    LozinkaSalt= "zDeZ2nOy4yQ2a4/lJR6rJA==",
                });
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
            }

            if (!context.Pozorista.Any(x => x.Naziv == "Kamerni teatar 55"))
            {
                //#1 Kamerni teatar 55
                context.Pozorista.Add(new Pozorista()
                {
                    Naziv = "Kamerni teatar 55",
                    Adresa = "Maršala Tita 56/II",
                    Logo = File.ReadAllBytes("Images/pozorista/kt55logo.jpg")
                });
                //#2 Narodno pozoriste Sarajevo
                context.Pozorista.Add(new Pozorista()
                {
                    Naziv = "Narodno pozoriste Sarajevo",
                    Adresa = "Obala Kulina bana 9",
                    Logo = File.ReadAllBytes("Images/pozorista/nps.jpg")
                });
                //#3 Sartr
                context.Pozorista.Add(new Pozorista()
                {
                    Naziv = "Sartr",
                    Adresa = "Gabelina 16",
                    Logo = File.ReadAllBytes("Images/pozorista/sartr.jpg")
                });
                //#4 Pozoriste mladih Sarajevo
                context.Pozorista.Add(new Pozorista()
                {
                    Naziv = "Pozoriste mladih Sarajevo",
                    Adresa = "Kulovica 8",
                    Logo = File.ReadAllBytes("Images/pozorista/pms.jpg")
                });
            }

            if (!context.TipoviPredstava.Any(x => x.Naziv == "Drama"))
            {
                context.TipoviPredstava.Add(new TipoviPredstava() { Naziv = "Drama" });
                context.TipoviPredstava.Add(new TipoviPredstava() { Naziv = "Balet" });
                context.TipoviPredstava.Add(new TipoviPredstava() { Naziv = "Opera" });
            }

            if (!context.VrsteDjelatnika.Any(x=>x.Naziv=="Reziser"))
            {
                context.VrsteDjelatnika.Add(new VrsteDjelatnika() { Naziv = "Reziser" });
                context.VrsteDjelatnika.Add(new VrsteDjelatnika() { Naziv = "Gumac" });
                context.VrsteDjelatnika.Add(new VrsteDjelatnika() { Naziv = "Koreograf" });
                
            }

            context.SaveChanges(); //trebaju idevi za ostale tabele

            if (!context.KorisniciUloge.Any(x=>x.KorisnikId==1))
            {
                context.KorisniciUloge.Add(new KorisniciUloge() { KorisnikId = 1, UlogaId = 1, DatumIzmjene = new DateTime(2021, 5, 1, 8,0,0) });
                context.KorisniciUloge.Add(new KorisniciUloge() { KorisnikId = 2, UlogaId = 2, DatumIzmjene = new DateTime(2021, 5, 1, 9, 0, 0) });
                context.KorisniciUloge.Add(new KorisniciUloge() { KorisnikId = 3, UlogaId = 2, DatumIzmjene = new DateTime(2021, 5, 1, 10, 0, 0) });
            }

            if (!context.Zone.Any(x=>x.PozoristeId==1))
            {
                //#1 Kamerni teatar 55
                context.Zone.Add(new Zone() { Naziv = "Zona A", PozoristeId = 1, UkupanBrojSjedista = 15 });
                context.Zone.Add(new Zone() { Naziv = "Zona B", PozoristeId = 1, UkupanBrojSjedista = 45 });
                context.Zone.Add(new Zone() { Naziv = "Zona C", PozoristeId = 1, UkupanBrojSjedista = 135 });

                //#2 Narodno pozoriste Sarajevo
                context.Zone.Add(new Zone() { Naziv = "VIP", PozoristeId = 2, UkupanBrojSjedista = 15 });
                context.Zone.Add(new Zone() { Naziv = "Zona A", PozoristeId = 2, UkupanBrojSjedista = 30 });
                context.Zone.Add(new Zone() { Naziv = "Zona B", PozoristeId = 2, UkupanBrojSjedista = 90 });
                context.Zone.Add(new Zone() { Naziv = "Zona C", PozoristeId = 2, UkupanBrojSjedista = 180 });

                //#3 Sartr
                context.Zone.Add(new Zone() { Naziv = "Zona A", PozoristeId = 3, UkupanBrojSjedista = 10 });
                context.Zone.Add(new Zone() { Naziv = "Zona B", PozoristeId = 3, UkupanBrojSjedista = 30 });
                context.Zone.Add(new Zone() { Naziv = "Zona C", PozoristeId = 3, UkupanBrojSjedista = 40 });

                //#4 Pozoriste mladih Sarajevo
                context.Zone.Add(new Zone() { Naziv = "Zona A", PozoristeId = 4, UkupanBrojSjedista = 20 });
                context.Zone.Add(new Zone() { Naziv = "Zona A", PozoristeId = 4, UkupanBrojSjedista = 40 });
                context.Zone.Add(new Zone() { Naziv = "Zona A", PozoristeId = 4, UkupanBrojSjedista = 120 });

            }

            if (!context.Predstave.Any(x=>x.Naziv=="Helverova noc"))
            {
                //#1 Helverova noc
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Helverova noc",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId=1,
                    Slika= File.ReadAllBytes("Images/predstave/helverova_noc.jpg")                    
                });
                //#2 Mirna Bosna
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Mirna Bosna",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstave/mirna_bosna.jpg")
                });
                //#3 Knjiga mojih zivota
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Knjiga mojih zivota",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstave/knjiga_mojih_zivota.jpg")
                });
                //#4 Tajna dzema od malina
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Tajna dzema od malina",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstave/Tajna_dzema_od_malina.jpg")
                });
                //#5 Ay Carmela
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Ay, Carmela",
                    Opis = "...",
                    Status = false,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstave/ay_carmela.jpg")
                });
                //#6 Dogville
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Dogville",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstave/Dogville.jpg")
                });
                //#7 Snijeg
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Snijeg",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstave/Snijeg.jpg")
                });
                //#8 Princeza na zrnu graska
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Princeza na zrnu graska",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstave/Princeza_na_zrnu_graska.jpg")
                });
                //#9 Zaljubljeni krokodil
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Zaljubljeni krokodil",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstave/Zaljubljeni_krokodil.jpg")
                });
                //#10 Patkica Blatkica
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Patkica Blatkica",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 1,
                    Slika = File.ReadAllBytes("Images/predstave/Patkica_Blatkica.jpg")
                });
                //#11 Okovani prometej
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Okovani prometej",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 2,
                    Slika = File.ReadAllBytes("Images/predstave/Okovani_prometej.jpg")
                });
                //#12 Palcica
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Palcica",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 2,
                    Slika = File.ReadAllBytes("Images/predstave/Palcica.jpg")
                });
                //#13 Uspavana ljepotica
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Uspavana ljepotica",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 2,
                    Slika = File.ReadAllBytes("Images/predstave/Uspavana_ljepotica.jpg")
                });
                //#14 La Traviata
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "La Traviata",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 3,
                    Slika = File.ReadAllBytes("Images/predstave/La_Traviata.jpg")
                });
                //#15 Don Giovanni
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Don Giovanni",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 3,
                    Slika = File.ReadAllBytes("Images/predstave/Don_Giovanni.jpg")
                });
                //#16 Rigoletto
                context.Predstave.Add(new Predstave()
                {
                    Naziv = "Rigoletto",
                    Opis = "...",
                    Status = true,
                    TipPredstaveId = 3,
                    Slika = File.ReadAllBytes("Images/predstave/Rigoletto.jpg")
                });
            }

            if (!context.Djelatnici.Any(x=>x.Ime=="Dino"))
            {
                //#1 Dino Mustafic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Dino",
                    Prezime = "Mustafic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici/dino_mustafic.jpg")
                });
                //#2 Mirjana Karanovic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Mirjana",
                    Prezime = "Karanovic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/Mirjana_Karanovic.jpg")
                });
                //#3 Ermin Bravo
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Ermin",
                    Prezime = "Bravo",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/ermin_bravo.jpg")
                });
                //#4 Sasa Pesevski
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Sasa",
                    Prezime = "Pesevski",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici/sasa_pesevski.jpg")
                });
                //#5 Fedja Stukan
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Fedja",
                    Prezime = "Stukan",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#6 Gordana Boban
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Gordana",
                    Prezime = "Boban",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#7 Sabrina Begovic Coric
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Sabrina",
                    Prezime = "Begovic Coric",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici/sabrina_begovic_coric.jpg")
                });
                //#8 Boris Ler
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Boris",
                    Prezime = "Ler",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#9 Maja Izetbegovic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Maja",
                    Prezime = "Izetbegovic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#10 Selma Spahic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Selma",
                    Prezime = "Spahic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici/selma_spahic.jpg")
                });
                //#11 Snjezana Alic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Snjezana",
                    Prezime = "Alic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#12 Alban Ukaj
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Alban",
                    Prezime = "Ukaj",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#13 Robert Raponja
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Robert",
                    Prezime = "Raponja",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
                });
                //#14 Selma Alispahic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Selma",
                    Prezime = "Alispahic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#15 Dragan Jovicic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Dragan",
                    Prezime = "Jovicic",
                    Biografija = "...",
                    Status = false,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#16 Lajla Kaikcija
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Lajla",
                    Prezime = "Kaikcija",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
                });
                //#17 Amra Kapidzic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Amra",
                    Prezime = "Kapidzic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#18 Ermin Sijamija
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Ermin",
                    Prezime = "Sijamija",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#19 Aleksandar Seksan
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Aleksandar",
                    Prezime = "Seksan",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#20 Daniela Gogic 
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Daniela",
                    Prezime = "Gogic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
                });
                //#21 Mario Drmac
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Mario",
                    Prezime = "Drmac",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#22 Belma Lizde Kurt
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Belma",
                    Prezime = "Lizde Kurt",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#23  Irfan Avdic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Irfan",
                    Prezime = "Avdic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
                });
                //#24 Sanin Milavic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Sanin",
                    Prezime = "Milavic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#25 Semir Krivic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Semir",
                    Prezime = "Krivic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#26  Drago Buka 
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Drago",
                    Prezime = "Buka",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
                });
                //#27 Alma Merunka
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Alma",
                    Prezime = "Merunka",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#28 Ajla Cabrera
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Ajla",
                    Prezime = "Cabrera",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#29 Belma Ceco Bakrac
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Belma",
                    Prezime = "Ceco Bakrac",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 3,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
                });
                //#30 Milan Rus
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Milan",
                    Prezime = "Rus",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#31 Tamara Ljubičić
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Tamara",
                    Prezime = "Ljubicic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#32 Nermina Damian
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Nermina",
                    Prezime = "Damian",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 3,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
                });
                //#33 Natasa Gaponko
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Natasa",
                    Prezime = "Gaponko",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#34 Ekaterina Verescagina
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Ekaterina",
                    Prezime = "Verescagina",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#35 Dinko Bogdanic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Dinko",
                    Prezime = "Bogdanic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 3,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
                });
                //#36 Adnan Djindo
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Adnan",
                    Prezime = "Djindo",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#37 Dajana Zilic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Dajana",
                    Prezime = "Zilic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#38  Ognian Draganoff
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Ognian",
                    Prezime = "Draganoff",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
                });
                //#39 Martina Zadro
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Martina",
                    Prezime = "Zadro",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#40 Amir Saracevic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Amir",
                    Prezime = "Saracevic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#41 Aleksandar Nikolic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Aleksandar",
                    Prezime = "Nikolic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 1,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0reziseri.jpg")
                });
                //#42 Marko Kalajanovic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Marko",
                    Prezime = "Kalajanovic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#43 Leonardo Saric
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Leonardo",
                    Prezime = "Saric",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });
                //#44 Dragutin Matic
                context.Djelatnici.Add(new Djelatnici()
                {
                    Ime = "Dragutin",
                    Prezime = "Matic",
                    Biografija = "...",
                    Status = true,
                    VrstaDjelatnikaId = 2,
                    Slika = File.ReadAllBytes("Images/djelatnici/a0glumci.jpg")
                });

            }

            context.SaveChanges(); //trebaju idevi za ostale tabele

            if (!context.PredstaveDjelatnici.Any(x=>x.DjelatnikId==1))
            {
                //#1 Helverova noc
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 1, DjelatnikId = 1 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 1, DjelatnikId = 2 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 1, DjelatnikId = 3 });

                //#2 Mirna Bosna
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 2, DjelatnikId = 4 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 2, DjelatnikId = 5 });
                context.PredstaveDjelatnici.Add(new PredstaveDjelatnici() { PredstavaId = 2, DjelatnikId = 6 });

                //#3 Knjiga mojih zivota
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

            if (!context.Izvodjenja.Any(x=>x.PredstavaId==1))
            {
                //#1 Helverova noc 1/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 1,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 1, 20, 0, 0),                  
                });
                //#2 Helverova noc 8/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 1,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 8, 20, 0, 0),
                });
                //#3 Helverova noc 15/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 1,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 15, 20, 0, 0),
                });
                //#4 Helverova noc 22/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 1,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 22, 20, 0, 0),
                });
                //#5 Helverova noc 29/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 1,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 29, 20, 0, 0),
                });

                //#6 Mirna Bosna 3/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 2,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 3, 20, 0, 0),
                });
                //#7 Mirna Bosna 10/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 2,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 10, 20, 0, 0),
                });
                //#8 Mirna Bosna 17/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 2,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 17, 20, 0, 0),
                });
                //#9 Mirna Bosna 24/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 2,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 24, 20, 0, 0),
                });

                //#10 Knjiga mojih zivota 5/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 3,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 5, 20, 0, 0),
                });
                //#11 Knjiga mojih zivota 12/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 3,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 12, 20, 0, 0),
                });
                //#12 Knjiga mojih zivota 19/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 3,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 19, 20, 0, 0),
                });
                //#13 Knjiga mojih zivota 26/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 3,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 26, 20, 0, 0),
                });

                //#14 Tajna dzema od malina 2/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 4,
                    PozoristeId = 3,
                    Napomena = "",
                    KorisnikId = 3,
                    DatumVrijeme = new DateTime(2021, 6, 2, 20, 0, 0),
                });
                //#15 Tajna dzema od malina 9/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 4,
                    PozoristeId = 3,
                    Napomena = "",
                    KorisnikId = 3,
                    DatumVrijeme = new DateTime(2021, 6, 9, 20, 0, 0),
                });
                //#16 Tajna dzema od malina 16/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 4,
                    PozoristeId = 3,
                    Napomena = "",
                    KorisnikId = 3,
                    DatumVrijeme = new DateTime(2021, 6, 16, 20, 0, 0),
                });
                //#17 Tajna dzema od malina 23/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 4,
                    PozoristeId = 3,
                    Napomena = "",
                    KorisnikId = 3,
                    DatumVrijeme = new DateTime(2021, 6, 23, 20, 0, 0),
                });

                //#18 Ay Carmela 4/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 5,
                    PozoristeId = 3,
                    Napomena = "",
                    KorisnikId = 3,
                    DatumVrijeme = new DateTime(2021, 6, 4, 20, 0, 0),
                });

                //#19 Dogville 1/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 6,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 1, 20, 0, 0),
                });
                //#20 Dogville 15/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 6,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 15, 20, 0, 0),
                });
                //#21 Dogville 29/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 6,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 29, 20, 0, 0),
                });

                //#22 Snijeg 2/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 7,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 2, 20, 0, 0),
                });
                //#23 Snijeg 16/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 7,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 16, 20, 0, 0),
                });
                //#24 Snijeg 30/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 7,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 30, 20, 0, 0),
                });

                //#25 Princeza na zrnu graska 2/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 8,
                    PozoristeId = 4,
                    Napomena = "",
                    KorisnikId = 3,
                    DatumVrijeme = new DateTime(2021, 6, 2, 15, 0, 0),
                });
                //#26 Princeza na zrnu graska 16/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 8,
                    PozoristeId = 4,
                    Napomena = "",
                    KorisnikId = 3,
                    DatumVrijeme = new DateTime(2021, 6, 16, 15, 0, 0),
                });

                //#27 Zaljubljeni krokodil 3/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 9,
                    PozoristeId = 4,
                    Napomena = "",
                    KorisnikId = 3,
                    DatumVrijeme = new DateTime(2021, 6, 3, 15, 0, 0),
                });
                //#28 Zaljubljeni krokodil 17/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 9,
                    PozoristeId = 4,
                    Napomena = "",
                    KorisnikId = 3,
                    DatumVrijeme = new DateTime(2021, 6, 17, 15, 0, 0),
                });

                //#29 Patkica Blatkica 4/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 10,
                    PozoristeId = 4,
                    Napomena = "",
                    KorisnikId = 3,
                    DatumVrijeme = new DateTime(2021, 6, 4, 14, 0, 0),
                });
                //#30 Patkica Blatkica 18/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 10,
                    PozoristeId = 4,
                    Napomena = "",
                    KorisnikId = 3,
                    DatumVrijeme = new DateTime(2021, 6, 18, 14, 0, 0),
                });

                //#31 Okovani prometej 5/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 11,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 5, 20, 0, 0),
                });
                //#32 Okovani prometej 19/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 11,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 19, 20, 0, 0),
                });

                //#33 Palcica 12/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 12,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 12, 18, 0, 0),
                });
                //#34 Palcica 26/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 12,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 26, 18, 0, 0),
                });

                //#35 Uspavana ljepotica 12/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 13,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 12, 21, 0, 0),
                });
                //#36 Uspavana ljepotica 26/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 13,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 26, 21, 0, 0),
                });

                //#37 La Traviata 6/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 14,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 6, 21, 0, 0),
                });

                //#38 Don Giovanni 13/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 15,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 13, 21, 0, 0),
                });

                //#39 Rigoletto 20/6/21
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 16,
                    PozoristeId = 2,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme = new DateTime(2021, 6, 20, 21, 0, 0),
                });

            }

            context.SaveChanges(); //trebaju idevi za ostale tabele

            if (!context.IzvodjenjaZone.Any(x=>x.IzvodjenjeId==1))
            {
                //# Helverova noc
                context.IzvodjenjaZone.Add(new IzvodjenjaZone() 
                {
                    IzvodjenjeId=1,
                    ZonaId=1,
                    Cijena=20,
                    Popust=null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 1,
                    ZonaId = 2,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 1,
                    ZonaId = 3,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 2,
                    ZonaId = 1,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 2,
                    ZonaId = 2,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 2,
                    ZonaId = 3,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 3,
                    ZonaId = 1,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 3,
                    ZonaId = 2,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 3,
                    ZonaId = 3,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 4,
                    ZonaId = 1,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 4,
                    ZonaId = 2,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 4,
                    ZonaId = 3,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 5,
                    ZonaId = 1,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 5,
                    ZonaId = 2,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 5,
                    ZonaId = 3,
                    Cijena = 5,
                    Popust = null,
                });

                //# Mirna Bosna
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 6,
                    ZonaId = 1,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 6,
                    ZonaId = 2,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 6,
                    ZonaId = 3,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 7,
                    ZonaId = 1,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 7,
                    ZonaId = 2,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 7,
                    ZonaId = 3,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 8,
                    ZonaId = 1,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 8,
                    ZonaId = 2,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 8,
                    ZonaId = 3,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 9,
                    ZonaId = 1,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 9,
                    ZonaId = 2,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 9,
                    ZonaId = 3,
                    Cijena = 5,
                    Popust = null,
                });

                //# Knjiga mojih zivota
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 10,
                    ZonaId = 1,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 10,
                    ZonaId = 2,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 10,
                    ZonaId = 3,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 11,
                    ZonaId = 1,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 11,
                    ZonaId = 2,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 11,
                    ZonaId = 3,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 12,
                    ZonaId = 1,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 12,
                    ZonaId = 2,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 12,
                    ZonaId = 3,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 13,
                    ZonaId = 1,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 13,
                    ZonaId = 2,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 13,
                    ZonaId = 3,
                    Cijena = 5,
                    Popust = null,
                });

                //Tajna dzema od malina
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 14,
                    ZonaId = 8,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 14,
                    ZonaId = 9,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 14,
                    ZonaId = 10,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 15,
                    ZonaId = 8,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 15,
                    ZonaId = 9,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 15,
                    ZonaId = 10,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 16,
                    ZonaId = 8,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 16,
                    ZonaId = 9,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 16,
                    ZonaId = 10,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 17,
                    ZonaId = 8,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 17,
                    ZonaId = 9,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 17,
                    ZonaId = 10,
                    Cijena = 5,
                    Popust = null,
                });

                //Ay Carmela
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 18,
                    ZonaId = 8,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 18,
                    ZonaId = 9,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 18,
                    ZonaId = 10,
                    Cijena = 5,
                    Popust = null,
                });

                //Dogville
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 19,
                    ZonaId = 4,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 19,
                    ZonaId = 5,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 19,
                    ZonaId = 6,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 19,
                    ZonaId = 7,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 20,
                    ZonaId = 4,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 20,
                    ZonaId = 5,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 20,
                    ZonaId = 6,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 20,
                    ZonaId = 7,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 21,
                    ZonaId = 4,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 21,
                    ZonaId = 5,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 21,
                    ZonaId = 6,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 21,
                    ZonaId = 7,
                    Cijena = 5,
                    Popust = null,
                });

                //Snijeg 
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 22,
                    ZonaId = 4,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 22,
                    ZonaId = 5,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 22,
                    ZonaId = 6,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 22,
                    ZonaId = 7,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 23,
                    ZonaId = 4,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 23,
                    ZonaId = 5,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 23,
                    ZonaId = 6,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 23,
                    ZonaId = 7,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 24,
                    ZonaId = 4,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 24,
                    ZonaId = 5,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 24,
                    ZonaId = 6,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 24,
                    ZonaId = 7,
                    Cijena = 5,
                    Popust = null,
                });

                //Princeza na zrnu graska 
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 25,
                    ZonaId = 11,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 25,
                    ZonaId = 12,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 25,
                    ZonaId = 13,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 26,
                    ZonaId = 11,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 26,
                    ZonaId = 12,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 26,
                    ZonaId = 13,
                    Cijena = 5,
                    Popust = null,
                });

                //Zaljubljeni krokodil
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 27,
                    ZonaId = 11,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 27,
                    ZonaId = 12,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 27,
                    ZonaId = 13,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 28,
                    ZonaId = 11,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 28,
                    ZonaId = 12,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 28,
                    ZonaId = 13,
                    Cijena = 5,
                    Popust = null,
                });

                //Patkica Blatkica
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 29,
                    ZonaId = 11,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 29,
                    ZonaId = 12,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 29,
                    ZonaId = 13,
                    Cijena = 5,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 30,
                    ZonaId = 11,
                    Cijena = 15,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 30,
                    ZonaId = 12,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 30,
                    ZonaId = 13,
                    Cijena = 5,
                    Popust = null,
                });

                //Okovani prometej
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 31,
                    ZonaId = 4,
                    Cijena = 40,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 31,
                    ZonaId = 5,
                    Cijena = 30,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 31,
                    ZonaId = 6,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 32,
                    ZonaId = 7,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 31,
                    ZonaId = 4,
                    Cijena = 40,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 32,
                    ZonaId = 5,
                    Cijena = 30,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 32,
                    ZonaId = 6,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 32,
                    ZonaId = 7,
                    Cijena = 10,
                    Popust = null,
                });

                //Palcica
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 33,
                    ZonaId = 4,
                    Cijena = 40,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 33,
                    ZonaId = 5,
                    Cijena = 30,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 33,
                    ZonaId = 6,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 33,
                    ZonaId = 7,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 34,
                    ZonaId = 4,
                    Cijena = 40,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 34,
                    ZonaId = 5,
                    Cijena = 30,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 34,
                    ZonaId = 6,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 34,
                    ZonaId = 7,
                    Cijena = 10,
                    Popust = null,
                });

                //Uspavana ljepotica
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 35,
                    ZonaId = 4,
                    Cijena = 40,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 35,
                    ZonaId = 5,
                    Cijena = 30,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 35,
                    ZonaId = 6,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 35,
                    ZonaId = 7,
                    Cijena = 10,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 36,
                    ZonaId = 4,
                    Cijena = 40,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 36,
                    ZonaId = 5,
                    Cijena = 30,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 36,
                    ZonaId = 6,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 36,
                    ZonaId = 7,
                    Cijena = 10,
                    Popust = null,
                });

                //La Traviata
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 37,
                    ZonaId = 4,
                    Cijena = 40,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 37,
                    ZonaId = 5,
                    Cijena = 30,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 37,
                    ZonaId = 6,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 37,
                    ZonaId = 7,
                    Cijena = 10,
                    Popust = null,
                });

                //Don Giovanni
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 38,
                    ZonaId = 4,
                    Cijena = 40,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 38,
                    ZonaId = 5,
                    Cijena = 30,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 38,
                    ZonaId = 6,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 38,
                    ZonaId = 7,
                    Cijena = 10,
                    Popust = null,
                });

                //Rigoletto
                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 39,
                    ZonaId = 4,
                    Cijena = 40,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 39,
                    ZonaId = 5,
                    Cijena = 30,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 39,
                    ZonaId = 6,
                    Cijena = 20,
                    Popust = null,
                });

                context.IzvodjenjaZone.Add(new IzvodjenjaZone()
                {
                    IzvodjenjeId = 39,
                    ZonaId = 7,
                    Cijena = 10,
                    Popust = null,
                });
            }
           
            context.SaveChanges(); //trebaju idevi za ostale tabele

            if (!context.Karte.Any(x=>x.KupacId==1))
            {
                // Helverova noc, Izvodjenja 1-5 - Kupci 1,2,4,5,7,8,9,10
                context.Karte.Add(new Karte() { IzvodjenjeId = 1, KupacId = 1, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0001" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 1, KupacId = 1, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0002" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 1, KupacId = 2, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0003" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 1, KupacId = 2, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0004" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 1, KupacId = 2, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0005" });
                
                context.Karte.Add(new Karte() { IzvodjenjeId = 2, KupacId = 4, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0006" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 2, KupacId = 4, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0007" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 2, KupacId = 5, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0008" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 2, KupacId = 7, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0009" });
                
                context.Karte.Add(new Karte() { IzvodjenjeId = 3, KupacId = 8, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0010" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 3, KupacId = 8, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0011" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 3, KupacId = 8, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0012" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 3, KupacId = 8, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0013" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 4, KupacId = 9, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0014" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 4, KupacId = 9, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0015" });
                
                context.Karte.Add(new Karte() { IzvodjenjeId = 5, KupacId = 10, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0016" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 5, KupacId = 10, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0017" });

                // Mirna Bosna, Izvodjenja 6-9 - Kupci 1, 3, 5, 9, 
                context.Karte.Add(new Karte() { IzvodjenjeId = 6, KupacId = 1, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0018" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 6, KupacId = 1, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0019" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 7, KupacId = 3, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0020" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 7, KupacId = 3, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0021" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 8, KupacId = 5, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0022" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 8, KupacId = 5, IzvodjenjeZonaId = 3, Placeno = false, Sifra = "k0023" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 9, KupacId = 9, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0024" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 9, KupacId = 9, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0025" });

                //Knjiga mojih zivota, Izvodjenja 10 - 13 - Kupci 2, 6, 8, 10
                context.Karte.Add(new Karte() { IzvodjenjeId = 10, KupacId = 2, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0026" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 10, KupacId = 2, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0027" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 11, KupacId = 6, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0028" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 11, KupacId = 6, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0029" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 12, KupacId = 8, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0030" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 12, KupacId = 8, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0031" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 12, KupacId = 8, IzvodjenjeZonaId = 1, Placeno = false, Sifra = "k0032" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 13, KupacId = 10, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0033" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 13, KupacId = 10, IzvodjenjeZonaId = 2, Placeno = false, Sifra = "k0034" });

                //Tajna dzema od malina, Izvodjenja 14 - 17 - Kupci 1, 5, 7, 9
                context.Karte.Add(new Karte() { IzvodjenjeId = 14, KupacId = 1, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0035" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 14, KupacId = 1, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0036" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 15, KupacId = 5, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0037" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 15, KupacId = 5, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0038" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 16, KupacId = 7, IzvodjenjeZonaId = 9, Placeno = false, Sifra = "k0039" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 16, KupacId = 7, IzvodjenjeZonaId = 9, Placeno = false, Sifra = "k0040" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 17, KupacId = 9, IzvodjenjeZonaId = 10, Placeno = false, Sifra = "k0041" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 17, KupacId = 9, IzvodjenjeZonaId = 10, Placeno = false, Sifra = "k0042" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 17, KupacId = 9, IzvodjenjeZonaId = 10, Placeno = false, Sifra = "k0043" });

                //Ay Carmela, Izvodjenje 18 - Kupci 1,2,7,8,9
                context.Karte.Add(new Karte() { IzvodjenjeId = 18, KupacId = 1, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0044" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 18, KupacId = 2, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0045" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 18, KupacId = 7, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0046" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 18, KupacId = 8, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0047" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 18, KupacId = 9, IzvodjenjeZonaId = 8, Placeno = false, Sifra = "k0048" });

                // Dogville, Izvodjenja 19-21 - Kupci 3, 7, 5, 10
                context.Karte.Add(new Karte() { IzvodjenjeId = 19, KupacId = 3, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0049" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 19, KupacId = 3, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0050" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 19, KupacId = 7, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0051" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 19, KupacId = 7, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0052" });
               
                context.Karte.Add(new Karte() { IzvodjenjeId = 20, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0053" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 20, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0054" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 20, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0055" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 21, KupacId = 5, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0056" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 21, KupacId = 5, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0057" });


                // Snijeg, Izvodjenja 22-24 - Kupci 3,4,7
                context.Karte.Add(new Karte() { IzvodjenjeId = 22, KupacId = 3, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0058" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 22, KupacId = 3, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0059" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 22, KupacId = 3, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0060" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 23, KupacId = 4, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0061" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 23, KupacId = 4, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0062" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 24, KupacId = 7, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0063" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 24, KupacId = 7, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0064" });

                //Princeza na zrnu graska, Izvodjenja 25, 26 - Kupci 2,3,6
                context.Karte.Add(new Karte() { IzvodjenjeId = 25, KupacId = 2, IzvodjenjeZonaId = 11, Placeno = false, Sifra = "k0065" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 25, KupacId = 2, IzvodjenjeZonaId = 11, Placeno = false, Sifra = "k0066" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 25, KupacId = 3, IzvodjenjeZonaId = 12, Placeno = false, Sifra = "k0067" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 25, KupacId = 3, IzvodjenjeZonaId = 12, Placeno = false, Sifra = "k0068" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 26, KupacId = 6, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0069" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 26, KupacId = 6, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0070" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 26, KupacId = 6, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0071" });

                // Zaljubljeni krokodil, Izvodjenja 27,28 - Kupci 1,9,10
                context.Karte.Add(new Karte() { IzvodjenjeId = 27, KupacId = 1, IzvodjenjeZonaId = 11, Placeno = false, Sifra = "k0072" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 27, KupacId = 1, IzvodjenjeZonaId = 11, Placeno = false, Sifra = "k0073" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 27, KupacId = 9, IzvodjenjeZonaId = 12, Placeno = false, Sifra = "k0074" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 27, KupacId = 9, IzvodjenjeZonaId = 12, Placeno = false, Sifra = "k0075" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 28, KupacId = 10, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0076" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 28, KupacId = 10, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0077" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 28, KupacId = 10, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0078" });

                // Patkica Blatkica, Izvodjenja 29,30 - Kupci 3,6,10
                context.Karte.Add(new Karte() { IzvodjenjeId = 29, KupacId = 3, IzvodjenjeZonaId = 11, Placeno = false, Sifra = "k0079" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 29, KupacId = 3, IzvodjenjeZonaId = 11, Placeno = false, Sifra = "k0080" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 29, KupacId = 6, IzvodjenjeZonaId = 12, Placeno = false, Sifra = "k0081" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 29, KupacId = 6, IzvodjenjeZonaId = 12, Placeno = false, Sifra = "k0082" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 30, KupacId = 10, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0083" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 30, KupacId = 10, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0084" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 30, KupacId = 10, IzvodjenjeZonaId = 13, Placeno = false, Sifra = "k0085" });

                // Okovani prometej, Izvodjenja 31,32 - Kupci - 4,8,9,10
                context.Karte.Add(new Karte() { IzvodjenjeId = 31, KupacId = 4, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0086" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 31, KupacId = 4, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0087" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 31, KupacId = 8, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0088" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 31, KupacId = 8, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0089" });
               
                context.Karte.Add(new Karte() { IzvodjenjeId = 32, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0090" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 32, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0091" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 32, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0092" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 32, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0093" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 32, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0094" });


                // Palcica, Izvodjenja 33,34 - Kupci 5,8,9,10
                context.Karte.Add(new Karte() { IzvodjenjeId = 33, KupacId = 5, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0095" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 33, KupacId = 5, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0096" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 33, KupacId = 8, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0097" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 33, KupacId = 8, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0098" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 34, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0099" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 34, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0100" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 34, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0101" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 34, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0102" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 34, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0103" });

                // Uspavana ljepotica, Izvodjenja 35, 36 - Kupci - 2,3,9,10
                context.Karte.Add(new Karte() { IzvodjenjeId = 35, KupacId = 2, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0104" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 35, KupacId = 2, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0105" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 35, KupacId = 3, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0106" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 35, KupacId = 3, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0107" });

                context.Karte.Add(new Karte() { IzvodjenjeId = 36, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0108" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 36, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0109" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 36, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0110" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 36, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0111" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 36, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0112" });

                // La Traviata, Izvodjenje 37 - Kupci 7,9,10
                context.Karte.Add(new Karte() { IzvodjenjeId = 37, KupacId = 7, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0113" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 37, KupacId = 7, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0114" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 37, KupacId = 7, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0115" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 37, KupacId = 7, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0116" });                                                               
                context.Karte.Add(new Karte() { IzvodjenjeId = 37, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0117" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 37, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0118" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 37, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0119" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 37, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0120" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 37, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0121" });

                // Don Giovanni, Izvodjenje 38 - Kupci 6,9,8
                context.Karte.Add(new Karte() { IzvodjenjeId = 38, KupacId = 7, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0122" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 38, KupacId = 7, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0123" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 38, KupacId = 7, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0124" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 38, KupacId = 7, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0125" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 38, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0126" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 38, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0127" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 38, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0128" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 38, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0129" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 38, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0130" });

                // Rigoletto, Izvodjenje 39 - Kupci 5,6,9,10
                context.Karte.Add(new Karte() { IzvodjenjeId = 39, KupacId = 5, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0122" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 39, KupacId = 5, IzvodjenjeZonaId = 4, Placeno = false, Sifra = "k0123" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 39, KupacId = 6, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0124" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 39, KupacId = 6, IzvodjenjeZonaId = 5, Placeno = false, Sifra = "k0125" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 39, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0126" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 39, KupacId = 9, IzvodjenjeZonaId = 7, Placeno = false, Sifra = "k0127" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 39, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0128" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 39, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0129" });
                context.Karte.Add(new Karte() { IzvodjenjeId = 39, KupacId = 10, IzvodjenjeZonaId = 6, Placeno = false, Sifra = "k0130" });
            }

            context.SaveChanges();
        }
    }
}
