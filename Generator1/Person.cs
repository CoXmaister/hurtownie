using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Generator1
{
    class Person
    {


        public static string[] names = System.IO.File.ReadAllLines(@"lista_polskich_imion.txt");
        public static string[] second_names = System.IO.File.ReadAllLines(@"nazwiska.txt");
        public static string[] nicknames = System.IO.File.ReadAllLines(@"pseudonimy.txt");
        public static string[] streets = System.IO.File.ReadAllLines(@"ulice.txt");
        public static string[] cities = System.IO.File.ReadAllLines(@"miasta.txt");

        public static string GeneratePerson()
        {
            StringBuilder person = new StringBuilder(100);
            Random rand = new Random();


            string name = GenerateName(names);
            string second_name = GenerateName(second_names);
            string nickname = GenerateName(nicknames);
            string PESEL = GenerateNumber(rand, 11);
            string PhoneNumber = GenerateNumber(rand, 9);
            string email = GenerateEmail(rand, name, second_name);
            


            person.Append(PESEL + ',');
            person.Append(name + ',');
            person.Append(second_name + ',');
            person.Append(nickname);
            person.Append(name);
            /*
            person.Append(PhoneNumber + ',');
            person.Append(email + ',');
            person.Append(adress + ',');
            */
            return person.ToString();
        }

        public static string GenerateNumber(Random rand, int n)
        {
            StringBuilder telNo = new StringBuilder(12);
            int number;
            for (int i = 0; i < n; i++)
            {
                number = rand.Next(0, 9);
                telNo = telNo.Append(number.ToString());
            }
            return telNo.ToString();
        }

        public static string GenerateName(string[] list)
        {
            Random rand = new Random();
            int index = rand.Next(list.Length);
            string ret = list[index];
            ret = ClearString(ret,"name");
            return ret;
        }

        /// <summary>
        /// Czyści stringi
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type">name, city lub street</param>
        /// <returns></returns>
        public static string ClearString(string str, string type)
        {
            string ret = str;

            for (int i = 0; i < ret.Length;)
            {
                if (type == "name" || type == "city")
                {
                    if (!Char.IsLetter(ret[i]) || ret[i] == ' ')
                    {
                        ret = ret.Remove(i, 1);
                    }
                    else
                    {
                        i++;
                    }
                }
                else if (type == "street")
                {
                    if (!Char.IsLetter(ret[i]))
                    {
                        ret = ret.Remove(i, 1);
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return ret;
        }

        public static string GenerateEmail(Random rand, string name, string surname)
        {

            string[] emails = { "gmail.com", "outlook.com", "yahoo.com", "o2.pl", "interia.pl", "onet.pl", "wp.pl" };

            string email = name.Substring(0, rand.Next(name.Length)) + surname;
            //wybierz domenę ze zbioru
            string ending = emails[rand.Next(emails.Length)];

            //dopisz losowe cyfry
            int digitCount = rand.Next(5);
            for (int i = 0; i < digitCount; i++)
            {
                email += "" + rand.Next(1000);
            }

            email += "@" + ending;

            //zwróć wynik
            return "'" + email + "'";
        }

        public static string GenerateAddress(Random rand, string[] cities, string[] streets, string kodPocz, string streetNumb, string city)
        {
            int index = rand.Next(cities.Length);
            int index2 = rand.Next(streets.Length);
            StringBuilder address = new StringBuilder(100);
            
            int Number1 = rand.Next(100);
            int Number2 = rand.Next(10, 99);
            int Number3 = rand.Next(100, 999);
            streetNumb = streets[index2] + " " + Number1;
            kodPocz = Number2 + "-" + Number3;
            city = ClearString(cities[index], "city");
            address.Append(streets[index2] + ' ');
            address.Append(Number1 + ",");
            address.Append(Number2 + "-");
            address.Append(Number3 + " ");
            address.Append(ClearString(cities[index],"city"));
            return address.ToString();

        }

    }
}
