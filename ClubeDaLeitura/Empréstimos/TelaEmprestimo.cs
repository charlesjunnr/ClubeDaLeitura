using ClubeDaLeitura.Modulo_Amigo;
using ClubeDaLeitura.Modulo_Caixa;
using ClubeDaLeitura.Modulo_Revista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Empréstimos
{
    internal class TelaEmprestimo
    {
        private RepositorioEmprestimo repositorioEmprestimo;
        private RepositorioAmigo repositorioAmigo;
        private RepositorioRevista repositorioRevista;

        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioRevista = repositorioRevista;
        }

        public void RegistrarEmprestimo()
        {
            Emprestimo emprestimo = new Emprestimo();

            VisualizarAmigo(true);

            Console.WriteLine("\nId do amigo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());
            Amigo amigo = repositorioAmigo.BuscarPorId(idAmigo);
            if (amigo == null)
                return;

            ArrayList emprestimosExecutados = this.repositorioEmprestimo.BuscarTodos();

            foreach (Emprestimo emprestimos in emprestimosExecutados)
            {
                if (emprestimos.amigo.id == amigo.id && emprestimos.finalizado == false)
                {
                    Program.MostrarMensagem("Você já tem um empréstimo no seu nome!", ConsoleColor.Red);
                    Console.ReadLine();
                    return;
                }
            }

            VisualizarRevista(true);
            Console.WriteLine("\nId da revista emprestada: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Revista revista = repositorioRevista.BuscarPorId(idRevista);
            if (revista == null)
                return;

            if (revista.emprestada == true)
            {
                Program.MostrarMensagem("Essa revista não está disponível!", ConsoleColor.Red);
                Console.ReadLine();
                return;
            }


            emprestimo.amigo = amigo;
            emprestimo.revista = revista;
            emprestimo.finalizado = false;

            DateTime dataHoje = DateTime.Today;
            emprestimo.dataEmprestimo = dataHoje;
            DateTime dataDevolucao = dataHoje.AddDays(7);
            emprestimo.dataDevolucao = dataDevolucao;

            this.repositorioEmprestimo.AdicionarNaLista(emprestimo);
            Program.MostrarMensagem("Empréstimo feito com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }
        public bool VisualizarEmprestimo(bool mostrarCabecalho)
        {

            if (this.repositorioEmprestimo.listaRegistros.Count == 0)
            {
                Program.MostrarMensagem("Nenhum empréstimo registrado!", ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            if (mostrarCabecalho)
                Program.MostrarCabecalho("Visualização de Empréstimos");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ------------------------------------------------------------------------------------------------------------------- ");
            Console.WriteLine(" | {0, -5} | {1, -55} | {2,-10} | {3,-15} | {4,-10} |", "ID", "Revista", "Amigo", "Data Empréstimo", "Data Devolução");
            Console.WriteLine(" ------------------------------------------------------------------------------------------------------------------- ");
            Console.ResetColor();

            foreach (Emprestimo emprestimo in this.repositorioEmprestimo.listaRegistros)
            {
                Console.WriteLine(" | {0, -5} | {1, -55} | {2,-10} | {3,-15} | {4,-10}     |", emprestimo.id, emprestimo.revista.nome, emprestimo.amigo.nome, emprestimo.dataEmprestimo.ToShortDateString(), emprestimo.dataDevolucao.ToShortDateString());
                Console.ResetColor();
                Console.WriteLine(" ------------------------------------------------------------------------------------------------------------------- ");
            }
            Console.ReadLine();
            return true;
        }
        public bool VisualizarEmprestimoEmAberto(bool mostrarCabecalho)
        {

            if (this.repositorioEmprestimo.listaRegistros.Count == 0)
            {
                Program.MostrarMensagem("Nenhum empréstimo registrado!", ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            if (mostrarCabecalho)
                Program.MostrarCabecalho("Empréstimos em Aberto: ");

            ArrayList emprestimosFeitos = this.repositorioEmprestimo.BuscarTodos();

            foreach (Emprestimo emprestimo in emprestimosFeitos)
            {
                if (emprestimo.finalizado == false)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" ------------------------------------------------------------------------------------------------------------------- ");
                    Console.WriteLine(" | {0, -5} | {1, -55} | {2,-10} | {3,-15} | {4,-10} |", "ID", "Revista", "Amigo", "Data Empréstimo", "Data Devolução");
                    Console.WriteLine(" ------------------------------------------------------------------------------------------------------------------- ");
                    Console.ResetColor();

                    Console.WriteLine(" | {0, -5} | {1, -55} | {2,-10} | {3,-15} | {4,-10}     |", emprestimo.id, emprestimo.revista.nome, emprestimo.amigo.nome, emprestimo.dataEmprestimo.ToShortDateString(), emprestimo.dataDevolucao.ToShortDateString());
                    Console.ResetColor();
                    Console.WriteLine(" ------------------------------------------------------------------------------------------------------------------- ");
                    Console.ReadLine();
                }
            }
            return true;
        }
        public bool VisualizarEmprestimoFechados(bool mostrarCabecalho)
        {

            if (this.repositorioEmprestimo.listaRegistros.Count == 0)
            {
                Program.MostrarMensagem("Nenhum empréstimo registrado!", ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            if (mostrarCabecalho)
                Program.MostrarCabecalho("Empréstimos Finalizados: ");

            ArrayList emprestimosFeitos = this.repositorioEmprestimo.BuscarTodos();

            foreach (Emprestimo emprestimo in emprestimosFeitos)
            {
                if (emprestimo.finalizado == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" ------------------------------------------------------------------------------------------------------------------- ");
                    Console.WriteLine(" | {0, -5} | {1, -55} | {2,-10} | {3,-15} | {4,-10} |", "ID", "Revista", "Amigo", "Data Empréstimo", "Data Devolução");
                    Console.WriteLine(" ------------------------------------------------------------------------------------------------------------------- ");
                    Console.ResetColor();

                    Console.WriteLine(" | {0, -5} | {1, -55} | {2,-10} | {3,-15} | {4,-10}     |", emprestimo.id, emprestimo.revista.nome, emprestimo.amigo.nome, emprestimo.dataEmprestimo.ToShortDateString(), emprestimo.dataDevolucao.ToShortDateString());
                    Console.ResetColor();
                    Console.WriteLine(" ------------------------------------------------------------------------------------------------------------------- ");
                    Console.ReadLine();
                }
            }
            return true;
        }
        public void CadastrarEmprestimoAutomaticamente()
        {
            Emprestimo emprestimoRegistrado = new Emprestimo();
            Amigo registroAmigo = repositorioAmigo.BuscarPorId(1);
            Revista registroRevista = repositorioRevista.BuscarPorId(1);

            DateTime dataHoje = DateTime.Today;
            emprestimoRegistrado.dataEmprestimo = dataHoje;
            DateTime dataDevolucao = dataHoje.AddDays(7);

            emprestimoRegistrado.amigo = registroAmigo;
            emprestimoRegistrado.revista = registroRevista;
            emprestimoRegistrado.dataEmprestimo = dataHoje;
            emprestimoRegistrado.dataDevolucao = dataDevolucao;
            emprestimoRegistrado.finalizado = false;

            this.repositorioEmprestimo.AdicionarNaLista(emprestimoRegistrado);

            Emprestimo emprestimoRegistrado2 = new Emprestimo();
            Amigo registroAmigo2 = repositorioAmigo.BuscarPorId(2);
            Revista registroRevista2 = repositorioRevista.BuscarPorId(2);

            DateTime dataHoje2 = DateTime.Today;
            emprestimoRegistrado.dataEmprestimo = dataHoje;
            DateTime dataDevolucao2 = dataHoje.AddDays(-7);

            emprestimoRegistrado2.amigo = registroAmigo2;
            emprestimoRegistrado2.revista = registroRevista2;
            emprestimoRegistrado2.dataEmprestimo = dataDevolucao2;
            emprestimoRegistrado2.dataDevolucao = dataHoje2;
            emprestimoRegistrado2.finalizado = true;
            this.repositorioEmprestimo.AdicionarNaLista(emprestimoRegistrado2);
        }
        public bool VisualizarRevista(bool mostrarCabecalho)
        {

            if (this.repositorioRevista.listaRegistros.Count == 0)
            {
                Program.MostrarMensagem("Nenhuma revista registrada!", ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            if (mostrarCabecalho)
                Program.MostrarCabecalho("Visualização de Revistas");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");
            Console.WriteLine(" | {0, -5} | {1, -55} | {2,-10} | {3,-10} | {4,-10} |", "ID", "Nome", "Edição", "Ano", "Caixa");
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");
            Console.ResetColor();

            foreach (Revista revista in this.repositorioRevista.listaRegistros)
            {
                Console.WriteLine(" | {0, -5} | {1, -55} | {2,-10} | {3,-10} | {4,-10} |", revista.id, revista.nome, revista.edicao, revista.ano, revista.caixa.etiqueta);
                Console.ResetColor();
                Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");
            }
            Console.ReadLine();
            return true;
        }
        public bool VisualizarAmigo(bool mostrarCabecalho)
        {

            if (this.repositorioAmigo.listaRegistros.Count == 0)
            {
                Program.MostrarMensagem("Nenhum amigo registrado!", ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }
            if (mostrarCabecalho)
                Program.MostrarCabecalho("Visualização de Amigos");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
            Console.WriteLine(" | {0, -5} | {1, -15} | {2,-15} | {3,-35} | {4,-10}  |", "ID", "Nome", "Nome do Responsável", "Endereço", "Telefone");
            Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
            Console.ResetColor();

            foreach (Amigo amigo in this.repositorioAmigo.listaRegistros)
            {
                Console.WriteLine(" | {0, -5} | {1, -15} | {2,-15} | {3,-35} | {4,-10}|", amigo.id, amigo.nome, amigo.nomeResponsavel, amigo.endereco, amigo.telefone);
                Console.ResetColor();
                Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
            }
            Console.ReadLine();
            return true;
        }



    }
}
