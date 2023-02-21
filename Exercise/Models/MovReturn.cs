using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Models
{
    public class MovReturn
    {
        public string FECHA { get; set; }
        public string CLIENTE { get; set; }
        public string NUMERO_CUENTA { get; set; }
        public string TIPO_CUENTA { get; set; }
        public decimal SALDO_INICIAL { get; set; }
        public string ESTADO { get; set; }
        public decimal MOVIMIENTO { get; set; }
        public decimal SALDO_DISPONIBLE { get; set; }

    }
}
