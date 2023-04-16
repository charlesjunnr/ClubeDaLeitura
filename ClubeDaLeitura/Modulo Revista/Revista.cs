using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Modulo_Revista
{
    internal class Revista
    {
        public string nome { get ; set; }
        public string edicao { get; set; }
        public int ano { get; set; }
        public Caixa caixa { get; set; }
        public bool emprestada { get; set; }
        public int id;
        public static int contadorId = 1;

        public void AdicionarId()
        {
            id = contadorId++;
        }
    }
}
