using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator1
{
    class Author
    {
        public string Pesel { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Numer { get; set; }
        public string Ulica_i_numer_domu { get; set; }
        public string Kod_pocztowy { get; set; }
        public string Miasto { get; set; }
        public string Gaza { get; set; }
        public string Rola { get; set; }
        public string Wiek { get; set; }
        public string nickname { get; set; }

        public static Author GenerateAuthor(Random rand)
        {
            string name = Person.GenerateName(Person.names, rand);
            string second_name = Person.GenerateName(Person.second_names, rand);
            string PESEL = Person.GenerateNumber(rand, 11);
            string kod, ulica, misto;
            Person.GenerateAddress(rand, Person.cities, Person.streets, out kod, out ulica, out misto);
            var author = new Author { Pesel = PESEL, Imie = name, Nazwisko = second_name, Ulica_i_numer_domu = ulica, Kod_pocztowy = kod, Miasto = misto };

            author.Numer = Person.GenerateNumber(rand, 9);
            author.Gaza = rand.Next(3000, 10000).ToString();
            author.Rola = "autor";
            author.Wiek = rand.Next(23, 60).ToString();
            author.nickname = Person.GenerateName(Person.nicknames, rand);
            return author;
        }
    }
}
