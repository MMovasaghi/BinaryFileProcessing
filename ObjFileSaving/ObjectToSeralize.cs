using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ObjFileSaving
{
    [Serializable()]
    public class ObjectToSeralize : ISerializable
    {
        private List<Person> _persons;
        public List<Person> persons
        {
            get { return _persons; }
            set { _persons = value; }
        }

        public ObjectToSeralize()
        {

        }
        public ObjectToSeralize(SerializationInfo info, StreamingContext context)
        {
            this._persons = (List<Person>)info.GetValue("persons", typeof(List<Person>));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("persons", this._persons);
        }
    }
}
