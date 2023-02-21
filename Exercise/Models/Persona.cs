using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Models
{
    public class Persona
    {

        [Key]
        public int ID_PERSONA { get; set; }
        public string NOMBRE { get; set; }
        public string GENERO { get; set; }
        public string EDAD { get; set; }
        public string IDENTIFICACION { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }

        
       /* public  Persona(int pID_PERSONA, string pNOMBRE, string pGENERO, string pEDAD, string pIDENTIFICACION, string pDIRECCION, string pTELEFONO)
        {
            
            ID_PERSONA = pID_PERSONA;
            NOMBRE = pNOMBRE;
            GENERO = pGENERO;
            EDAD = pEDAD;
            IDENTIFICACION = pIDENTIFICACION;
            DIRECCION = pDIRECCION;
            TELEFONO = pTELEFONO;
        }*/
    }
}
