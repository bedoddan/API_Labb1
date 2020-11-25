using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Labb1.Models
{
    public class Personmodell
    {
        [Key]
        public long Persnr { get; set; }
        public string Namn { get; set; }
        public string Telnr { get; set; }
    }
}
