using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator1
{
    class Play
    {
        public static string[] names = System.IO.File.ReadAllLines(@"sztuki.txt");
        public static string[] generes = { "dramat", "komedia", "opera", "pantomima", "lalki" };
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public string Gatunek { get; set; }
        public List<Aktor> ListaAktorow { get; set; }
        public string Rezyser { get; set; }
        public string ID { get; set; }
        static string GeneratePlay(int amount)
        {
            StringBuilder play = new StringBuilder(100);
            Random rand = new Random();
            string name = GenerateName(rand, names, amount);
            string[] generes = { "dramat", "komedia", "opera", "pantomima", "lalki" };
            string genere = generes[rand.Next(generes.Length)];
            play.Append(name+',');
            play.Append(genere + ',');
            return play.ToString();
        }

        public static Play GeneratePlay(Random rand, int amount, List<Aktor> kolekcjaAktors, List<Author> kolekcjaAuthors, int id)
        {
            Play play = new Play();
            play.Tytul = GenerateName(rand, names, amount);
            Author author = kolekcjaAuthors[rand.Next(kolekcjaAuthors.Count)];
            play.Autor = author.Imie + " " + author.Nazwisko;
            play.Gatunek = generes[rand.Next(generes.Length)];
            author = kolekcjaAuthors[rand.Next(kolekcjaAuthors.Count)];
            play.Rezyser = author.Imie + " " + author.Nazwisko;
            List<Aktor> lista = new List<Aktor>();
            int count = rand.Next(5, 15);
            int random = rand.Next(kolekcjaAktors.Count-count-1);
            for (int i = 0; i < count; i++)
            {
                lista.Add(kolekcjaAktors[random+i]);
            }
            play.ListaAktorow = lista;
            play.ID = id.ToString();
            return play;
        }
        static string GenerateName(Random rand, string[] list, int amount)
        {
            int index = rand.Next(list.Length);
            while (list[index] =="")
            {
                index = rand.Next(list.Length);

            }
            string ret = list[index];
            list[index] = "";
            
            return ret;
        }

    }
}
