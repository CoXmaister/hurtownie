using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator1
{
    class Ticket
    {
        public string id { get; set; }
        public string Ulga { get; set; }
        public string Cena { get; set; }
        public static Ticket GenerateTicket(Random rand, int basePrice, int id)
        {
            int ulga = rand.Next(0, 5) * 10;
            int price = basePrice - ulga;
            var bilet = new Ticket { id = id.ToString(), Ulga = ulga.ToString(), Cena = price.ToString() };
            return bilet;
        }
    }
}
