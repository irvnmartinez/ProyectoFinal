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
    public class Usuario_cliente
    {
        public string cardnumber { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string Password { get; set; }
        public double balance { get; set; }
        public string Status { get; set; }
    }
}