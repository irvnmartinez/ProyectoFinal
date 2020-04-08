using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO___FINAL
{
    public class Transacciones
    {
        public string NumeroTarjeta { get; set; }
        public string TipoTransaccion { get; set; }
        public double monto_transaccion { get; set; }
        public double balance_anterior { get; set; }
        public double balance_nuevo { get; set; }
    }
}