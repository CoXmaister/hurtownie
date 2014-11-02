using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator1
{
    class Program
    {
        static List<Aktor>kolekcjaAktors = new List<Aktor>();
        static Aktor aktor = new Aktor();
        static List<Author>kolekcjaAuthors = new List<Author>();
        static Author author = new Author();
        static List<Ticket> kolekcjaTickets = new List<Ticket>();
        static Ticket bilet = new Ticket();
            
        [STAThread] 
        static void Main()
        {
            int ilosc = 20;
            var strWriterAktor = new StreamWriter("daneAktor.bulk");
            var strWriterAuthor = new StreamWriter("daneAutor.bulk");
            StringBuilder aktorStr = new StringBuilder(100);
            StringBuilder authorStr = new StringBuilder(100);
            Random rand = new Random();
            for (int i = 0; i < ilosc; i++)
            {
                aktor = Aktor.GenerateAktor(rand);// generowanie pojedynczego aktora
                kolekcjaAktors.Add(aktor);//dodanie doi kolekcji

                bilet = Ticket.GenerateTicket(rand, 100, i);// generowanie pojedynczego biletu
                kolekcjaTickets.Add(bilet);//dodanie doi kolekcji
                
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

            Excel1.generateExcel(kolekcjaAktors,kolekcjaAuthors);
            Console.ReadLine();
        }
    }
}
