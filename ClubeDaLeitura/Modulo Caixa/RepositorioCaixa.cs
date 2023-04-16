using ClubeDaLeitura.RepositórioMãe;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Modulo_Caixa
{
    public class RepositorioCaixa : RepositorioMae
    {
        public void AdicionarNaLista(Caixa caixa)
        {
            caixa.AdicionarId();
            listaRegistros.Add(caixa);
        }
        public ArrayList BuscarTodos()
        {
            return listaRegistros;
        }
        public Caixa BuscarPorId(int id)
        {
            foreach(Caixa caixa in listaRegistros)
            {
                if(caixa.id == id)
                {
                    return caixa;
                }
            }
            return null!;
        }

        public void ExcluirCaixa(Caixa caixa)
        {
            listaRegistros.Remove(caixa);
        }
    }
}
