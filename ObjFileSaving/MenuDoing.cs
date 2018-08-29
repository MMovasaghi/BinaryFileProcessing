using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjFileSaving
{
    class MenuDoing
    {
        ObjectToSeralize objectToSeralize = new ObjectToSeralize();
        Serialize serialize = new Serialize();
        public void AddDefault()
        {
            Console.WriteLine("[Your Choice] Add Default Users.");

            Address ad = new Address() { Lon = 20, Lot = 30 };

            Console.WriteLine("[*] Address object created.");

            List<Person> p1 = ReadAll();
            int n = FindLastIndex();
            p1.Add(new Person { ID = n, Username = "Ali", Password = "1234", address = ad });
            p1.Add(new Person { ID = n+1, Username = "Ali", Password = "1234", address = ad });
            p1.Add(new Person { ID = n+2, Username = "Ali", Password = "1234", address = ad });

            Console.WriteLine("[*] p1 object created.");
            Console.WriteLine("[*] object detail : ");
            foreach (var item in p1)
            {
                Console.WriteLine("-- [{0}] : Username = {1} , Password = {2} , Address : Lot = {3} , Lon = {4}", item.ID, item.Username, item.Password, item.address.Lot, item.address.Lon);
            }
            Console.WriteLine();
            //save the p1 list to the file
            
            objectToSeralize.persons = p1;

            Console.WriteLine("[*] ObjectToSeralize object created.");

            
            serialize.SerializeObj("Output.txt", objectToSeralize);

            Console.WriteLine("[*] p1 Object has been saved in the File.");
        }
        public void ShowAllUsers()
        {
            Console.WriteLine("[Your Choice] Read All Users.");
            //read from file
            objectToSeralize = serialize.DeSerialize("Output.txt");
            List<Person> p2 = new List<Person>();
            p2 = objectToSeralize.persons;
            Console.WriteLine("[*] object detail : ");
            foreach (var item in p2)
            {
                Console.WriteLine("-- [{0}] : Username = {1} , Password = {2} , Address : Lot = {3} , Lon = {4}", item.ID, item.Username, item.Password, item.address.Lot, item.address.Lon);
            }
        }
        public void DeleteAll()
        {
            Console.WriteLine("[Your Choice] Delete all data.");

            List<Person> p1 = new List<Person>();
            Console.WriteLine();
            //save the p1 list to the file

            objectToSeralize.persons = p1;

            serialize.SerializeObj("Output.txt", objectToSeralize);

            Console.WriteLine("[*] All Data has been Deleted from the File.");
        }
        public void AddNewPerson(Person person)
        {

            List<Person> p1 = ReadAll();
            int n = FindLastIndex();
            person.ID = n;
            p1.Add(person);
            //save the p1 list to the file

            objectToSeralize.persons = p1;

            Console.WriteLine("[*] ObjectToSeralize object created.");


            serialize.SerializeObj("Output.txt", objectToSeralize);

            Console.WriteLine("[*] New Person Added.");
        }
        public void DeleteOnePerson(string user)
        {
            List<Person> p1 = ReadAll();
            List<Person> p2 = new List<Person>();
            int n = 0;
            foreach (var item in p1)
            {                
                if (item.Username != user)
                {                    
                    item.ID = n;
                    p2.Add(item);
                    n++;
                }
            }
            
            
            //save the p1 list to the file

            objectToSeralize.persons = p2;

            Console.WriteLine("[*] ObjectToSeralize object created.");


            serialize.SerializeObj("Output.txt", objectToSeralize);

            Console.WriteLine("[*] {0} Deleted." , user);
        }
        private List<Person> ReadAll()
        {
            //read from file
            objectToSeralize = serialize.DeSerialize("Output.txt");
            List<Person> p2 = new List<Person>();
            p2 = objectToSeralize.persons;
            return p2;
        }
        private int FindLastIndex()
        {
            //read from file
            objectToSeralize = serialize.DeSerialize("Output.txt");
            List<Person> p2 = new List<Person>();
            p2 = objectToSeralize.persons;
            if (p2.Count != 0)
            {
                return p2[p2.Count - 1].ID + 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
