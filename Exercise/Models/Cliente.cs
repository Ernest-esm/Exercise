using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Models
{
    [NotMapped]
    public class Cliente:Persona
    {
        
        public int ID_CLIENTE { get; set; }
        
        public string CONTRASEÑA { get; set; }
        
        public int ESTADO { get; set; }
    }
}
