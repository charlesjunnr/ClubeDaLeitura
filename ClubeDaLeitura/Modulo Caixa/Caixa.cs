using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    public class Caixa
    {
        public string cor { get ; set; }
        public string etiqueta { get; set; }
        public int id { get; set; }

        public static int contadorId = 1;

        public void AdicionarId()
        {
            id = contadorId++;
        }

        public Caixa()
        {

        }

        
        
    }
}
