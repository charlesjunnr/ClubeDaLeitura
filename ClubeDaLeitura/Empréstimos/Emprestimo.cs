using ClubeDaLeitura.Modulo_Revista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Empréstimos
{
    internal class Emprestimo
    {
        public DateTime dataEmprestimo { get; set; } 
        public DateTime dataDevolucao { get; set; }
        public int id { get; set; }
        public bool finalizado { get; set; }

        public static int contadorId = 1;
        
        public Amigo amigo;

        public Revista revista;

        public void AdicionarId()
        {
            id = contadorId++;
        }
    }
}
