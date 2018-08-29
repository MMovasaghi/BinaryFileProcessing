using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ObjFileSaving
{
    [Serializable()]
    public class Person : ISerializable
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Address address { get; set; }
        public Person()
        {

        }
        public Person(SerializationInfo info, StreamingContext context)
        {
            this.ID = (int)info.GetValue("ID", typeof(int));
            this.Username = (string)info.GetValue("Username", typeof(string));
            this.Password = (string)info.GetValue("Password", typeof(string));
            this.address = (Address)info.GetValue("address", typeof(Address));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", this.ID);
            info.AddValue("Username",this.Username);
            info.AddValue("Password", this.Password);
            info.AddValue("address", this.address);
        }
    }
}
