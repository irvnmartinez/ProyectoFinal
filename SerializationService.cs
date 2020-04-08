using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PROYECTO___FINAL
{
    class SerializationService
    {
        public void Serialize(object obj, string directory, string filename)
        {
            CreateDirectory(directory);

            IFormatter format = new BinaryFormatter();
            Stream stream = new FileStream("@ ~/" + directory, FileMode.Create, FileAccess.Write);

            format.Serialize(stream, obj);
            stream.Close();
        }

        public void CreateDirectory(string directory)
        {
            if (!Directory.Exists("@ ~/" + directory))
            {
                Directory.CreateDirectory("@ ~/" + directory);
                IFormatter formatter = new BinaryFormatter();
            }
        }
        public object Deserialize(string directory, string filename)
        {
            CreateDirectory(directory);

            IFormatter format = new BinaryFormatter();
            Stream stream = new FileStream("@ ~/" + directory + "/" + filename, FileMode.Open, FileAccess.Read);
            object retorno = format.Deserialize(stream);
            stream.Close();
            return retorno;
        }
    }
}