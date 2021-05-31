using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTata.Models
{
    public class ContadordePalabras
    {
        public string palabra { get; set; }
        public int frecuencia { get; set; }

        public ContadordePalabras(string palabra, int frecuencia)
        {
            this.palabra = palabra;
            this.frecuencia = frecuencia;
        }
    }
}
