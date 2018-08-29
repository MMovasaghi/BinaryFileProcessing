using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ObjFileSaving
{
    public class Serialize
    {
        public Serialize()
        {

        }
        public void SerializeObj(string FileName,ObjectToSeralize objectToSeralize)
        {
            using (Stream stream = File.Open(FileName, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToSeralize);
            }           
        }
        public ObjectToSeralize DeSerialize(string FileName)
        {
            ObjectToSeralize ObjectResult;
            using (Stream stream = File.Open(FileName,FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                ObjectResult = (ObjectToSeralize)binaryFormatter.Deserialize(stream);
            }
            return ObjectResult;
        }
    }
}
