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
                context.Zone.Add(new Zone() { Naziv = "Zona A", PozoristeId = 1, UkupanBrojSjedista = 15 });
                context.Zone.Add(new Zone() { Naziv = "Zona B", PozoristeId = 1, UkupanBrojSjedista = 45 });
                context.Zone.Add(new Zone() { Naziv = "Zona C", PozoristeId = 1, UkupanBrojSjedista = 135 });

                context.Zone.Add(new Zone() { Naziv = "VIP", PozoristeId = 2, UkupanBrojSjedista = 15 });
                context.Zone.Add(new Zone() { Naziv = "Zona A", PozoristeId = 2, UkupanBrojSjedista = 30 });
                context.Zone.Add(new Zone() { Naziv = "Zona B", PozoristeId = 2, UkupanBrojSjedista = 90 });
                context.Zone.Add(new Zone() { Naziv = "Zona C", PozoristeId = 2, UkupanBrojSjedista = 180 });

                context.Zone.Add(new Zone() { Naziv = "Zona A", PozoristeId = 3, UkupanBrojSjedista = 10 });
                context.Zone.Add(new Zone() { Naziv = "Zona B", PozoristeId = 3, UkupanBrojSjedista = 30 });
                context.Zone.Add(new Zone() { Naziv = "Zona C", PozoristeId = 3, UkupanBrojSjedista = 40 });

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
                context.Izvodjenja.Add(new Izvodjenja()
                {
                    PredstavaId = 1,
                    PozoristeId = 1,
                    Napomena = "",
                    KorisnikId = 2,
                    DatumVrijeme=DateTime.Now,//


                });
            }

            context.SaveChanges();
        }
    }
}
