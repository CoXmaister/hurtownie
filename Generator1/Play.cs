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
