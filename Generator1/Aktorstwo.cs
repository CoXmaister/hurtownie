using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator1
{
    class Aktorstwo
    {
        public string Pesel { get; set; }
        public string S_ID { get; set; }

        public static Aktorstwo GenerateAktorstwo(Aktor aktor, Play play)
        {
            Aktorstwo aktorstwo = new Aktorstwo();
            aktorstwo.Pesel = aktor.Pesel;
            aktorstwo.S_ID = play.ID;
            return aktorstwo;

        }

    }
}
