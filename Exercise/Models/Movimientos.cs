using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Models
{
    public class Movimientos
    {

        [Key]
        public int ID_MOV { get; set; }
        public int ID_CLIENTE { get; set; }
        public int ID_CUENTA { get; set; }
        public DateTime FECHA { get; set; }
        public decimal MOVIMIENTO { get; set; }
        public decimal SALDO { get; set; }
        public int ESTADO { get; set; }
    }
}
