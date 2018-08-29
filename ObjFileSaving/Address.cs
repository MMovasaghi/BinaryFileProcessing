using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ObjFileSaving
{
    [Serializable()]
    public class Address : ISerializable
    {
        public int Lot { get; set; }
        public int Lon { get; set; }

        public Address()
        {

        }
        public Address(SerializationInfo info, StreamingContext context)
        {
            this.Lon = (int)info.GetValue("Lon", typeof(int));
            this.Lot = (int)info.GetValue("Lot", typeof(int));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Lon", this.Lon);
            info.AddValue("Lot", this.Lot);
        }
    }
}
