using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertAutomation;
using AdvertAutomation.SiteParsers;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BrowserDriver.InitDriver("chrome");
            ThreeNine threeNine = new ThreeNine(ThreeNine.Languages.RO);

            //get 999 category
            /*List<string> cat = threeNine.GetCategory();
            foreach (var el in cat)
            {
                Console.WriteLine(el);
            }*/

            //999 login
            threeNine.LogIn("onofrei.igor.mail.ru@mail.ru", "7394igor");

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
