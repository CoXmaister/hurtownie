using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator1
{
    class Teatr
    {
        public string Nazwa { get; set; }
        public string Adres { get; set; }
        public static Teatr GenerateTeatr()
        {
            var teatr = new Teatr { Nazwa = "Theater", Adres = "Kwiatowa 15, 80-226 Gdansk" };
            return teatr;
        }
    }
}
