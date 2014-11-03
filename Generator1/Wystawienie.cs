using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator1
{
    class Wystawienie
    {
        public string W_ID { get; set; }
        public string S_ID { get; set; }
        public string T_ID { get; set; }
        public string Data { get; set; }
        public string Godzina { get; set; }
        public string Sala { get; set; }

        public static Wystawienie GenerateWystawienie(int id, Play play, Teatr teatr,Random rand)
        {
            Wystawienie wystawienie = new Wystawienie();

            wystawienie.W_ID = id.ToString();
            wystawienie.S_ID = play.ID;
            wystawienie.T_ID = teatr.id;
            string[] godzina = {"15:", "18:", "12:", "14:", "20:", "16:", "17:", "19:"};
            string[] minuta = {"00", "15", "30", "45"};
            wystawienie.Godzina = godzina[rand.Next(godzina.Length)] + minuta[rand.Next(minuta.Length)];
            wystawienie.Sala = rand.Next(1, 6).ToString();
            //TODO To trzeba poprawić
            wystawienie.Data = RandomDay(rand).ToShortDateString();// To trzeba podreperować
            return wystawienie;
        }

        static DateTime RandomDay(Random gen)
        {
            DateTime start = new DateTime(1995, 1, 1);
            //Random gen = new Random();

            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

    }
}
