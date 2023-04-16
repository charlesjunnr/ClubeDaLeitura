using ClubeDaLeitura.Modulo_Caixa;
using ClubeDaLeitura.RepositórioMãe;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Modulo_Amigo
{
    public class RepositorioAmigo : RepositorioMae
    {
     
        public void AdicionarNaLista(Amigo amigo)
        {
            amigo.AdicionarId();
            listaRegistros.Add(amigo);
        }
        public ArrayList BuscarTodos()
        {
            return listaRegistros;
        }
        public Amigo BuscarPorId(int id)
        {
            foreach (Amigo amigo in listaRegistros)
            {
                if (amigo.id == id)
                {
                    return amigo;
                }
            }
            return null!;
        }
        public void ExcluirAmigo(Amigo amigo)
        {
            listaRegistros.Remove(amigo);
        }
        
    }
}
