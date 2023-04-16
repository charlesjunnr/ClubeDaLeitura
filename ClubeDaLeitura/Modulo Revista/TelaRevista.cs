using ClubeDaLeitura.Modulo_Amigo;
using ClubeDaLeitura.Modulo_Caixa;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Modulo_Revista
{
    internal class TelaRevista
    {
        private RepositorioRevista repositorioRevista;
        private RepositorioCaixa repositorioCaixa;

        public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa)
        {
            this.repositorioRevista = repositorioRevista;
            this.repositorioCaixa = repositorioCaixa;
        }

        public void RegistrarRevista()
        {
            Revista revista = new Revista();

            Console.WriteLine("\n Nome da revista: ");
            revista.nome = Console.ReadLine();

            Console.WriteLine("\n Edição: ");
            revista.edicao = Console.ReadLine();

            Console.WriteLine("\n Ano: ");
            revista.ano = Convert.ToInt32(Console.ReadLine());
            VisualizarCaixasDisponiveis();
          
            Console.WriteLine("\n Id da Caixa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Caixa caixa = repositorioCaixa.BuscarPorId(id);
            if (caixa == null)
                return;

            revista.caixa = caixa;

            this.repositorioRevista.AdicionarNaLista(revista);
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
                Program.MostrarCabecalho("Revistas Disponíveis:");

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
        public void EditarRevista()
        {
            bool temRevistaRegistrada = VisualizarRevista(false);

            if (temRevistaRegistrada == false)
            {
                return;
            }

            Program.MostrarCabecalho("Escolha o número da revista que deseja editar:");

            int posicao = Convert.ToInt32(Console.ReadLine());

            Revista revista = repositorioRevista.BuscarPorId(posicao);
            if (revista == null)
            {
                return;
            }

            Console.WriteLine("\n Nome da revista: ");
            revista.nome = Console.ReadLine();

            Console.WriteLine("\n Edição: ");
            revista.edicao = Console.ReadLine();

            Console.WriteLine("\n Ano: ");
            revista.ano = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n Id da Caixa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Caixa caixa = repositorioCaixa.BuscarPorId(id);
            if (caixa == null)
                return;

            revista.caixa = caixa;

            Program.MostrarMensagem("Revista editado com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }
        public void ExcluirRevista()
        {
            bool temRevistaRegistrada = VisualizarRevista(false);

            if (temRevistaRegistrada == false)
            {
                return;
            }

            Program.MostrarCabecalho("Digite o ID da revista que deseja excluir");

            int posicao = Convert.ToInt32(Console.ReadLine());

            Revista revista = repositorioRevista.BuscarPorId(posicao);
            if (revista == null)
            {
                return;
            }

            this.repositorioRevista.ExcluirRevista(revista);

            Program.MostrarMensagem("Revista excluído com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }
        public void CadastrarRevistaAutomaticamente()
        {
            Revista revistaRegistrada = new Revista();
            revistaRegistrada.nome = "Turma da Mônica - As Aventuras de Cebolinha";
            revistaRegistrada.edicao = "1ªEdicão";
            revistaRegistrada.ano = 1988;
            revistaRegistrada.emprestada = true;

            Caixa revistaRegistro = repositorioCaixa.BuscarPorId(1);
            revistaRegistrada.caixa = revistaRegistro;

            this.repositorioRevista.AdicionarNaLista(revistaRegistrada);

            Revista revistaRegistrada2 = new Revista();
            revistaRegistrada2.nome = "Almanaque do Cascão";
            revistaRegistrada2.edicao = "3ªEdicão";
            revistaRegistrada2.ano = 1998;
            revistaRegistrada2.emprestada = false;

            Caixa revistaRegistro2 = repositorioCaixa.BuscarPorId(2);
            revistaRegistrada2.caixa = revistaRegistro2;

            this.repositorioRevista.AdicionarNaLista(revistaRegistrada2);
        }
        public void VisualizarCaixasDisponiveis()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ----------------------------------- ");
            Console.WriteLine(" | {0, -5} | {1, -10} | {2,-10} |", "ID", "Etiqueta", "Cor");
            Console.WriteLine(" ----------------------------------- ");
            Console.ResetColor();

            foreach (Caixa caixa in this.repositorioCaixa.listaRegistros)
            {
                Console.WriteLine(" | {0, -5} | {1, -10} | {2,-10} |", caixa.id, caixa.etiqueta, caixa.cor);
                Console.ResetColor();
                Console.WriteLine(" ----------------------------------- ");
            }
            Console.ReadLine();
    
        }
    }
    
}
