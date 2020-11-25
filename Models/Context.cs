using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Labb1.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
           : base(options)
        {
        }

        public DbSet<Fiskmodell> Fiskar { get; set; }
        public DbSet<Personmodell> Personer { get; set; }
        public DbSet<Betesmodell> Beten {get;set;}
    }
}
