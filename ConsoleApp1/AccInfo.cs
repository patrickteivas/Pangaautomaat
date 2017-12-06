using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class AccInfo
    {
        string folder = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Kontod");

        public string Name { get; set; }
        public int Pin { get; set; }
        public int Balance { get; set; }

        public void Insert()
        {
            Console.WriteLine("Kui palju Te tahate arvele panna? (Ainult täisarvud)");
            Balance = int.Parse(Console.ReadLine()) + Balance;
            File.WriteAllText(folder + "\\" + Name + ".txt", Pin + "\n" + Balance);
            Console.WriteLine("Teie uus balanss: " + Balance);
        }

        public void Withdraw()
        {
            //TODO
        }
    }
}
