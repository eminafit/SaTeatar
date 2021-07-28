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
                context.KorisniciUloge.Add(new KorisniciUloge() { KorisnikId = 1, UlogaId = 1, DatumIzmjene = DateTime.Now });
                context.KorisniciUloge.Add(new KorisniciUloge() { KorisnikId = 2, UlogaId = 2, DatumIzmjene = DateTime.Now });
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

            // // 2015 - year, 12 - month, 25 – day, 10 – hour, 30 – minute, 50 - second  
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

            context.SaveChanges();
        }
    }
}
