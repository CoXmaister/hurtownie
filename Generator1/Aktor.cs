using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator1
{
    class Aktor
    {
        public string Pesel { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Numer { get; set; }
        public string Ulica_i_numer_domu{ get; set; }
        public string Kod_pocztowy { get; set; }
        public string Miasto { get; set; }
        public string Gaza { get; set; }
        public string Wiek { get; set; }
        public string Rola { get; set; }
        public string nickname { get; set; }
        public static Aktor GenerateAktor(Random rand)
        {
            
            string name = Person.GenerateName(Person.names,rand);
            string second_name = Person.GenerateName(Person.second_names,rand);
            string PESEL = Person.GenerateNumber(rand, 11);
            string kod, ulica, misto;
            Person.GenerateAddress(rand, Person.cities, Person.streets, out kod, out ulica, out misto);
            var aktor = new Aktor {Pesel = PESEL, Imie = name, Nazwisko = second_name,Ulica_i_numer_domu = ulica,Kod_pocztowy = kod,Miasto = misto};

            aktor.Numer = Person.GenerateNumber(rand, 9);
            aktor.Gaza = rand.Next(3000, 10000).ToString();
            //aktor.Wiek = rand.Next(23, 60).ToString();

            int w = Convert.ToInt32(PESEL.Substring(0, 2));
            w = 100 - w + 14;
            aktor.Wiek = w.ToString();
            aktor.Rola = Person.GenerateRole(rand);
            aktor.nickname = Person.GenerateName(Person.nicknames,rand);
            return aktor;
        }
    }
}
