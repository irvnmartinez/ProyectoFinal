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
    [Serializable()]
    public class Banco
    {
        public string nombre_banco { get; set; }
        public int modo_dispensacion { get; set; }
    }
}