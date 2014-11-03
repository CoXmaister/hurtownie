using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator1
{
    class Sprzedaz
    {
        public string W_ID { get; set; }
        public string B_ID { get; set; }
        public bool FirstTime { get; set; }

        public static Sprzedaz GenerateSprzedaz(Wystawienie wystawienie, Ticket ticket, Random rand)
        {
            Sprzedaz sprzedaz = new Sprzedaz();

            sprzedaz.W_ID = wystawienie.W_ID;
            sprzedaz.B_ID = ticket.id;
            int score = rand.Next(0, 100);
            sprzedaz.FirstTime = score < 30;

            return sprzedaz;
        }
    }
}
