using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    public class Amigo
    {
        public string nome { get; set; }
        public string nomeResponsavel { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public int id { get; set; }

        public static int contadorId = 1;
        
        public void AdicionarId()
        {
            id = contadorId++;
        }
    }
}
