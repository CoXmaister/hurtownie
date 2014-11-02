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
        public string Ulica_i_numer_domu{ get; set; }
        public string Kod_pocztowy { get; set; }
        public string Miasto { get; set; }
        public string Gaza { get; set; }
        public string Wiek { get; set; }

        public static Aktor GenerateAktor(out Aktor aktor)
        {
            Random rand = new Random();
            string name = Person.GenerateName(Person.names);
            string second_name = Person.GenerateName(Person.second_names);
            string PESEL = Person.GenerateNumber(rand, 11);

            aktor = new Aktor();
            aktor.Pesel = PESEL;
            aktor.Imie = name;
            aktor.Nazwisko = second_name;
        }
    }
}
