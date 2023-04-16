using ClubeDaLeitura.RepositórioMãe;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Modulo_Revista
{
    internal class RepositorioRevista : RepositorioMae
    {
        public void AdicionarNaLista(Revista revista)
        {
            revista.AdicionarId();
            listaRegistros.Add(revista);
        }
        public ArrayList BuscarTodos()
        {
            return listaRegistros;
        }
        public Revista BuscarPorId(int id)
        {
            foreach (Revista revista in listaRegistros)
            {
                if (revista.id == id)
                {
                    return revista;
                }
            }
            return null!;
        }
        public void ExcluirRevista(Revista revista)
        {
            listaRegistros.Remove(revista);
        }
    }
}


