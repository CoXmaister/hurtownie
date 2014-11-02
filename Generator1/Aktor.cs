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

        public static Aktor GenerateAktor()
        {
            Random rand = new Random();
            string name = Person.GenerateName(Person.names);
            string second_name = Person.GenerateName(Person.second_names);
            string PESEL = Person.GenerateNumber(rand, 11);
            
            var aktor = new Aktor {Pesel = PESEL, Imie = name, Nazwisko = second_name};
            string adress = Person.GenerateAddress(rand, Person.cities, Person.streets,aktor.Kod_pocztowy,aktor.Ulica_i_numer_domu,aktor.Miasto);
            return aktor;
        }
    }
}
