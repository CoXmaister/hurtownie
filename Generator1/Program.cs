using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator1
{
    class Program
    {
        List<Aktor>kolekcjaAktors = new List<Aktor>();
        
        
        [STAThread] 
        static void Main()
        {
            int ilosc = 20;
            var strWriter = new StreamWriter("daneTeatr.bulk");
            for (int i = 0; i < ilosc; i++)
            {
                string person = Person.GeneratePerson();
                if (i < ilosc - 1)
                {
                    strWriter.WriteLine(person);
                }
                else
                {
                    strWriter.Write(person);    
                }

                strWriter.Flush();
            }

            Excel1.generateExcel();
            Console.ReadLine();
        }
    }
}
