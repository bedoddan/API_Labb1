using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Labb1.Models
{
    public class Betesmodell
    {
        
        [Key]
        public int Betenr { get; set; }
        public string Typ { get; set; }
        public string Color { get; set; }
    }
}
