using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Models
{
    public class Clientes
    {
        [Key]
        public int ID_CLIENTE { get; set; }
        public int ID_PERSONA { get; set; }
        public string CONTRASEÑA { get; set; }

        public int ESTADO { get; set; }
    }
}
