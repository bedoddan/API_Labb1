using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Labb1.Models
{
    public class Fiskmodell
    {
        [Key]
        public int FiskID { get; set; }
        public string Art { get; set; }
        public int Vikt { get; set; }
        public string Vatten { get; set; }
    }
}
