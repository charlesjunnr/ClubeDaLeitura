using ClubeDaLeitura.RepositórioMãe;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Empréstimos
{
    internal class RepositorioEmprestimo : RepositorioMae
    {
        public void AdicionarNaLista(Emprestimo emprestimo)
        {
            emprestimo.AdicionarId();
            listaRegistros.Add(emprestimo);
        }
        public ArrayList BuscarTodos()
        {
            return listaRegistros;
        }
        public Emprestimo BuscarPorId(int id)
        {
            foreach (Emprestimo emprestimo in listaRegistros)
            {
                if (emprestimo.id == id)
                {
                    return emprestimo;
                }
            }
            return null!;
        }
        public void ExcluirEmprestimo(Emprestimo emprestimo)
        {
            listaRegistros.Remove(emprestimo);
        }

    }
}
