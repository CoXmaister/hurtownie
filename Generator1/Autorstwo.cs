using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator1
{
    class Autorstwo
    {
        public string Pesel { get; set; }
        public string S_ID { get; set; }

        public static Autorstwo GenerateAutorstwo(Author autor, Play play)
        {
            Autorstwo autorstwo = new Autorstwo();
            autorstwo.Pesel = autor.Pesel;
            autorstwo.S_ID = play.ID;
            return autorstwo;
        }

    }
}
