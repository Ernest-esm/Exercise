using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Models
{
    public class Mensajes
    {
        [Key]
        public int ID_MSG { get; set; }
        public string MESSAGE { get; set; }
    }
}
