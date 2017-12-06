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
            string x;

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
                            Sees:
                            Console.WriteLine("\nSisestage funktsiooni järjekorranumber!\n1. Raha arvelt\n2. Raha arvele");
                            käsk = int.Parse(Console.ReadLine());
                            if (käsk == 1)
                            {
                                user.Withdraw();
                                Console.WriteLine("Soovite jätkata? (Y/N)");
                                x = Console.ReadLine();
                                if (x == "Y")
                                {
                                    goto Sees;
                                }
                                else break;
                            }
                            else if (käsk == 2)
                            {
                                user.Insert();
                                Console.WriteLine("Soovite jätkata? (Y/N)");
                                x = Console.ReadLine();
                                if (x == "Y")
                                {
                                    goto Sees;
                                }
                                else break;
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
                    Console.WriteLine("\nSisestage kasutajanimi");
                    user.Name = Console.ReadLine();
                    if (!File.Exists(folder + "\\" + user.Name + ".txt"))
                    {
                        Console.WriteLine("Sisestage PIN-kood");
                        Pin:
                        Console.WriteLine("PIN-kood peab olema 4 sümboline.");
                        user.Pin = int.Parse(Console.ReadLine());
                        if (Math.Floor(Math.Log10(user.Pin) + 1) != 4) goto Pin;
                        else
                        {
                            File.WriteAllText(folder + "\\" + user.Name + ".txt", user.Pin + "\n0");
                            Console.WriteLine("Kasutaja on loodud!");
                        }
                    }
                    else Console.WriteLine("Niisugune konto on juba olemas!");

                    Console.WriteLine("Soovite jätkata? (Y/N)");
                    x = Console.ReadLine();
                    if (x != "Y") break;
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
