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
        
        [STAThread] 
        static void Main()
        {
            int ilosc = 20;
            var strWriter = new StreamWriter("daneAktor.bulk");
            StringBuilder person = new StringBuilder(100);
            Random rand = new Random();
            for (int i = 0; i < ilosc; i++)
            {
                aktor = Aktor.GenerateAktor(rand);// generowanie pojedynczego aktora
                kolekcjaAktors.Add(aktor);//dodanie doi kolekcji
                //string do pliku
                person.Append(aktor.Pesel + ',');
                person.Append(aktor.Imie + ',');
                person.Append(aktor.Nazwisko + ',');
                person.Append(aktor.nickname);

                if (i < ilosc - 1)
                {
                    strWriter.WriteLine(person);
                }
                else
                {
                    strWriter.Write(person);    
                }

                strWriter.Flush();
                person.Clear();
            }

            Excel1.generateExcel(kolekcjaAktors);
            Console.ReadLine();
        }
    }
}
