using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator1
{
    class Ticket
    {

        static string GenerateTicket(int basePrice)
        {
            StringBuilder ticket = new StringBuilder(100);
            Random rand = new Random();

            int ulga = rand.Next(0, 5) * 10;
            int price = basePrice - ulga;
            ticket.Append(ulga.ToString() + '%' + ',');
            ticket.Append(price.ToString() + ',');
            return ticket.ToString();
        }
    }
}
