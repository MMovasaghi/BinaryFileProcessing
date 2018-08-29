using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjFileSaving
{
    class Program
    {
        static void Main(string[] args)
        {
            bool WhileTrue = true;

            while (WhileTrue)
            {
                Console.Clear();
                Console.WriteLine("Chose from the Menu : ");
                Console.WriteLine("1) Show All Data");
                Console.WriteLine("2) Add Defaults");
                Console.WriteLine("3) Add Some Person");
                Console.WriteLine("4) Delete Some Person");
                Console.WriteLine("5) Delete All Data");
                Console.WriteLine("0) Exit");
                Console.Write("Your Choise : ");
                string input = Console.ReadLine();
                MenuDoing menuDoing = new MenuDoing();
                switch (input)
                {
                    case "1":
                        menuDoing.ShowAllUsers();
                        break;
                    case "2":
                        menuDoing.AddDefault();
                        break;
                    case "3":

                        Console.WriteLine("[Your Choice] Add New User.");
                        Console.Write("--- [input] Username : ");
                        string User = Console.ReadLine();
                        Console.Write("--- [input] Password : ");
                        string Pass = Console.ReadLine();
                        Console.Write("--- [input] Address lon : ");
                        string lon = Console.ReadLine();
                        Console.Write("--- [input] Address lot : ");
                        string lot = Console.ReadLine();
                        Address ad = new Address()
                        {
                            Lon = Int32.Parse(lon),
                            Lot = Int32.Parse(lot)
                        };
                        Person p = new Person()
                        {
                            ID = 0,
                            Username = User,
                            Password = Pass,
                            address = ad,
                        };
                        menuDoing.AddNewPerson(p);
                        break;
                    case "4":
                        Console.WriteLine("[Your Choice] Delete One User.");
                        Console.Write("--- [input] Username : ");
                        string User1 = Console.ReadLine();
                        menuDoing.DeleteOnePerson(User1);
                        break;
                    case "5":
                        menuDoing.DeleteAll();
                        break;
                    case "0":
                        WhileTrue = false;
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            }            
        }
    }
}
