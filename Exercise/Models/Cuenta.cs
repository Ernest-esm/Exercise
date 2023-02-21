using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Models
{
    public class Cuenta
    {
        [Key]
        public int ID_CUENTA { get; set; }
        public int ID_CLIENTE { get; set; }
        public string NUMERO_CUENTA { get; set; }
        public string TIPO_CUENTA { get; set; }
        public decimal SALDO_INI { get; set; }
        public int ESTADO { get; set; }
        

    }
}
