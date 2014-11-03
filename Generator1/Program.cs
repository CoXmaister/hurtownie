using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator1
{
    class Program
    {
        static Teatr teatr = new Teatr();
        static List<Aktor>kolekcjaAktors = new List<Aktor>();
        static Aktor aktor = new Aktor();
        static List<Author>kolekcjaAuthors = new List<Author>();
        static Author author = new Author();
        static List<Ticket> kolekcjaTickets = new List<Ticket>();
        static Ticket bilet = new Ticket();
        static List<Autorstwo> kolekcjaAutorstwo = new List<Autorstwo>();
        static Autorstwo autorstwo = new Autorstwo();
        static List<Aktorstwo> kolekcjaAktorstwo = new List<Aktorstwo>();
        static Aktorstwo aktorstwo = new Aktorstwo();
        static List<Wystawienie> kolekcjaWystawienie = new List<Wystawienie>();
        static Wystawienie wystawienie = new Wystawienie();
        static List<Sprzedaz> kolekcjaSprzedaz = new List<Sprzedaz>();
        static Sprzedaz sprzedaz = new Sprzedaz();
        static List<Play> kolekcjaPlay = new List<Play>();
        static Play play = new Play();
            
        [STAThread] 
        static void Main()
        {
            teatr = Teatr.GenerateTeatr();

            int ilosc = 20;
            var strWriterAktor = new StreamWriter("daneAktor.bulk");
            var strWriterAuthor = new StreamWriter("daneAutor.bulk");
            var strWriterTicket = new StreamWriter("daneBilet.bulk");
            var strWriterPlay = new StreamWriter("daneSztuka.bulk");
            var strWriterAutorstwo = new StreamWriter("daneAutorstwo.bulk");
            var strWriterAktorstwo = new StreamWriter("daneAktorstwo.bulk");
            var strWriterWystawienie = new StreamWriter("daneWystawienie.bulk");
            var strWriterSprzedaz = new StreamWriter("daneSprzedaz.bulk");
            StringBuilder aktorStr = new StringBuilder(100);
            StringBuilder authorStr = new StringBuilder(100);
            StringBuilder ticketStr = new StringBuilder(100); 
            StringBuilder playStr = new StringBuilder(100);
            StringBuilder autorstwoStr = new StringBuilder(100);
            StringBuilder aktorstwoStr = new StringBuilder(100);
            StringBuilder wystawienieStr = new StringBuilder(100);
            StringBuilder sprzedazStr = new StringBuilder(100);
            Random rand = new Random();
            for (int i = 0; i < ilosc; i++)
            {
                aktor = Aktor.GenerateAktor(rand);// generowanie pojedynczego aktora
                kolekcjaAktors.Add(aktor);//dodanie doi kolekcji
                
                //string do pliku
                aktorStr.Append(aktor.Pesel + ',');
                aktorStr.Append(aktor.Imie + ',');
                aktorStr.Append(aktor.Nazwisko + ',');
                aktorStr.Append(aktor.nickname);

                author = Author.GenerateAuthor(rand);
                kolekcjaAuthors.Add(author);
                authorStr.Append(author.Pesel + ',');
                authorStr.Append(author.Imie + ',');
                authorStr.Append(author.Nazwisko + ',');
                authorStr.Append(author.nickname);

                if (i < ilosc - 1)
                {
                    strWriterAktor.WriteLine(aktorStr);
                    strWriterAuthor.WriteLine(authorStr);
                }
                else
                {
                    strWriterAktor.Write(aktorStr);    
                    strWriterAuthor.Write(authorStr);
                }

                strWriterAktor.Flush();
                strWriterAuthor.Flush();
                aktorStr.Clear();
                authorStr.Clear();
            }

            for (int i = 0; i < ilosc/4; i++)
            {
                play = Play.GeneratePlay(rand, ilosc/4, kolekcjaAktors, kolekcjaAuthors, i);
                kolekcjaPlay.Add(play);

                playStr.Append(play.ID + ",");
                playStr.Append(play.Tytul + ",");
                playStr.Append(play.Gatunek);

                if (i < (ilosc/4) - 1)
                {
                    strWriterPlay.WriteLine(playStr);
                }
                else
                {
                    strWriterPlay.Write(playStr);
                }

                strWriterPlay.Flush();
                playStr.Clear();
            }

            for (int i = 0; i < ilosc*100; i++)
            {
                bilet = Ticket.GenerateTicket(rand, 100, i);// generowanie pojedynczego biletu
                kolekcjaTickets.Add(bilet);//dodanie do kolekcji

                ticketStr.Append(bilet.id + ",");
                ticketStr.Append(bilet.Ulga + ",");
                ticketStr.Append(bilet.Cena);

                if (i < ilosc * 100 - 1)
                {
                    strWriterTicket.WriteLine(ticketStr);
                }
                else
                {
                    strWriterTicket.Write(ticketStr);
                }

                strWriterTicket.Flush();
                ticketStr.Clear();
            }
            int count = kolekcjaPlay.Count;
            foreach (Play sztukaPlay in kolekcjaPlay)
            {
                count --;
                List<Author> tmp = new List<Author>(kolekcjaAuthors);
                int random = rand.Next(1, 3);
                for (int i = 0; i < random; i++)
                {
                    Author autor = tmp[rand.Next(tmp.Count)];
                    autorstwo = Autorstwo.GenerateAutorstwo(autor, sztukaPlay);
                    tmp.Remove(autor);
                    kolekcjaAutorstwo.Add(autorstwo);
                    autorstwoStr.Append(autorstwo.Pesel + ",");
                    autorstwoStr.Append(autorstwo.S_ID);

                    if (count != 0)
                    {
                        strWriterAutorstwo.WriteLine(autorstwoStr);
                    }
                    else if(i < random-1)
                    {
                        strWriterAutorstwo.WriteLine(autorstwoStr);
                    }
                    else
                    {
                        strWriterAutorstwo.Write(autorstwoStr);
                    }

                    strWriterAutorstwo.Flush();
                    autorstwoStr.Clear();
                }
            }

            int count2 = kolekcjaPlay.Count;
            foreach (Play sztukaPlay in kolekcjaPlay)
            {
                count2--;
                List<Aktor> tmp = new List<Aktor>(kolekcjaAktors);
                
                int random = rand.Next(5, 15);
                for (int i = 0; i < random; i++)
                {
                    Aktor aktor = tmp[rand.Next(tmp.Count)];
                    aktorstwo = Aktorstwo.GenerateAktorstwo(aktor, sztukaPlay);
                    tmp.Remove(aktor);
                    kolekcjaAktorstwo.Add(aktorstwo);
                    aktorstwoStr.Append(aktorstwo.Pesel + ",");
                    aktorstwoStr.Append(aktorstwo.S_ID);

                    if (count2 != 0)
                    {
                        strWriterAktorstwo.WriteLine(aktorstwoStr);
                    }
                    else if (i < random - 1)
                    {
                        strWriterAktorstwo.WriteLine(aktorstwoStr);
                    }
                    else
                    {
                        strWriterAktorstwo.Write(aktorstwoStr);
                    }

                    strWriterAktorstwo.Flush();
                    aktorstwoStr.Clear();
                }
            }

            int count3 = kolekcjaPlay.Count;
            int counetID = 0;
            foreach (Play sztuka in kolekcjaPlay)
            {
                count3--;
                int random = rand.Next(10, 15);
                for (int i = 0; i < random; i++)
                {
                    counetID ++;
                    wystawienie = Wystawienie.GenerateWystawienie(counetID, sztuka, teatr, rand);
                    kolekcjaWystawienie.Add(wystawienie);

                    wystawienieStr.Append(wystawienie.W_ID + ",");
                    wystawienieStr.Append(wystawienie.S_ID + ",");
                    wystawienieStr.Append(wystawienie.T_ID + ",");
                    wystawienieStr.Append(wystawienie.Data + ",");
                    wystawienieStr.Append(wystawienie.Godzina + ",");
                    wystawienieStr.Append(wystawienie.Sala);

                    if (count3 != 0)
                    {
                        strWriterWystawienie.WriteLine(wystawienieStr);
                    }
                    else if (i < random - 1)
                    {
                        strWriterWystawienie.WriteLine(wystawienieStr);
                    }
                    else
                    {
                        strWriterWystawienie.Write(wystawienieStr);
                    }

                    strWriterWystawienie.Flush();
                    wystawienieStr.Clear();
                }
            }

            //TODO nie wiem czy to nie jest błąd w projekcie bazy, ale połączenie n:1 dla sprzedazy i biletu to chyba sredniuo, bo bilet sprzedajemy tylko raz i jest on tylko na jedna sztuke?
            //TODO tak mi sie wydaje, dlatego robie tytaj oreacha po kazdym bilecie i dobieram mu jedna sztuke
            count = kolekcjaTickets.Count;
            List<Wystawienie> tmpWystawienie = new List<Wystawienie>(kolekcjaWystawienie);
            foreach (Ticket ticket in kolekcjaTickets)
            {
                count--;
                if (tmpWystawienie.Count == 1)
                {
                    tmpWystawienie = new List<Wystawienie>(kolekcjaWystawienie);
                }


                int random = rand.Next(tmpWystawienie.Count);
                Wystawienie wyst = tmpWystawienie[random];
                sprzedaz = Sprzedaz.GenerateSprzedaz(wyst, ticket, rand);
                kolekcjaSprzedaz.Add(sprzedaz);
                tmpWystawienie.Remove(wyst);
                sprzedazStr.Append(sprzedaz.W_ID + ",");
                sprzedazStr.Append(sprzedaz.B_ID + ",");
                sprzedazStr.Append(sprzedaz.FirstTime);
                if (count > 0)
                {
                    strWriterSprzedaz.WriteLine(sprzedazStr);
                }
                else
                {
                    strWriterSprzedaz.Write(sprzedazStr);
                }
                strWriterSprzedaz.Flush();
                sprzedazStr.Clear();
            }


            // Excel1.generateExcel(kolekcjaAktors,kolekcjaAuthors);
            Console.ReadLine();
        }
    }
}
