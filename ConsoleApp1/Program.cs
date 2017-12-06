using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Kontod");
            bool run = true;

            while (run == true)
            {
                Console.WriteLine("Sisestage funktsiooni järjekorranumber.\n1. Sisselogimine\n2. Registreerumine");
                int käsk = int.Parse(Console.ReadLine());

                var user = new AccInfo();

                if (käsk == 1)
                {
                    Console.WriteLine("\nSisestage kasutajanimi.");
                    user.Name = Console.ReadLine();
                    if (File.Exists(folder + "\\" + user.Name + ".txt"))
                    {
                        Console.WriteLine("Sisestage PIN-kood");
                        user.Pin = int.Parse(Console.ReadLine());
                        string[] InfoLines = System.IO.File.ReadAllLines(folder + "\\" + user.Name + ".txt");
                        if (user.Pin == int.Parse(InfoLines[0]))
                        {
                            user.Balance = int.Parse(InfoLines[1]);
                            Console.WriteLine("Sisestasite õige PIN-koodi.\nTeie arvel on " + user.Balance + " eurot.");
                            Console.WriteLine("\nSisestage funktsiooni järjekorranumber!\n1. Raha arvelt\n2. Raha arvele");
                            käsk = int.Parse(Console.ReadLine());
                            if (käsk == 1)
                            {
                                //AccInfo.Withdraw();
                            }
                            else if (käsk == 2)
                            {
                                //AccInfo.Insert();
                            }
                            else
                            {
                                Console.WriteLine("Sisestasite vale käsu. Peate uuesti sisselogima!\n");
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("\nSisestasite vale kasutajanime. Proovige uuesti\n");
                    }

                }
                else if (käsk == 2)
                {
                    //Account register
                }
                else
                {
                    Console.WriteLine("Sisestasite vale käsu. Proovige uuesti");
                }
            }
            Console.WriteLine("Programm lõpetas töö");
        }
    }
}
