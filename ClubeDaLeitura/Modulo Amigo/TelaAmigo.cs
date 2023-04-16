using ClubeDaLeitura.Modulo_Amigo;
using ClubeDaLeitura.Modulo_Caixa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    public class TelaAmigo
    {
        private RepositorioAmigo repositorioAmigo;
        public TelaAmigo(RepositorioAmigo repositorioAmigo)
        {
            this.repositorioAmigo = repositorioAmigo;
        }

        public void RegistrarAmigo()
        {
            Amigo amigo = new Amigo();
            
            Console.WriteLine("\n Nome do amigo: ");
            amigo.nome = Console.ReadLine();
            Console.WriteLine("\n Nome do responsável: ");
            amigo.nomeResponsavel = Console.ReadLine();
            Console.WriteLine("\n Telefone: ");
            amigo.telefone = Console.ReadLine();
            Console.WriteLine("\n Endereço: ");
            amigo.endereco = Console.ReadLine();

            this.repositorioAmigo.AdicionarNaLista(amigo);
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
            Console.WriteLine(" | {0, -5} | {1, -15} | {2,-15} | {3,-35} | {4,-10}  |","ID","Nome","Nome do Responsável","Endereço","Telefone");
            Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
            Console.ResetColor();

            foreach (Amigo amigo in this.repositorioAmigo.listaRegistros)
            {
                Console.WriteLine(" | {0, -5} | {1, -15} | {2,-15} | {3,-35} | {4,-10}|", amigo.id, amigo.nome , amigo.nomeResponsavel, amigo.endereco, amigo.telefone);
                Console.ResetColor();
                Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
            }
            Console.ReadLine();
            return true;
        }
        public void EditarAmigo()
        {
            bool temAmigoRegistrada = VisualizarAmigo(false);

            if (temAmigoRegistrada == false)
            {
                return;
            }

            Program.MostrarCabecalho("Escolha o número do amigo que deseja editar:");

            int posicao = Convert.ToInt32(Console.ReadLine());

            Amigo amigo = repositorioAmigo.BuscarPorId(posicao);
            if (amigo == null)
            {
                return;
            }

            Console.WriteLine("\n Nome do amigo: ");
            amigo.nome = Console.ReadLine();
            Console.WriteLine("\n Nome do responsável: ");
            amigo.nomeResponsavel = Console.ReadLine();
            Console.WriteLine("\n Telefone: ");
            amigo.telefone = Console.ReadLine();
            Console.WriteLine("\n Endereço: ");
            amigo.endereco = Console.ReadLine();

            Program.MostrarMensagem("Amigo editado com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }
        public void ExcluirAmigo()
        {
            bool temAmigoRegistrado = VisualizarAmigo(false);

            if (temAmigoRegistrado == false)
            {
                return;
            }

            Program.MostrarCabecalho("Digite o ID do amigo que deseja excluir");

            int posicao = Convert.ToInt32(Console.ReadLine());

            Amigo amigo = repositorioAmigo.BuscarPorId(posicao);
            if (amigo == null)
            {
                return;
            }

            this.repositorioAmigo.ExcluirAmigo(amigo);

            Program.MostrarMensagem("Amigo excluído com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }
        public void CadastrarAmigoAutomaticamente()
        {
            Amigo amigoRegistrado = new Amigo();
            
            amigoRegistrado.nome = "Juca";
            amigoRegistrado.nomeResponsavel = "João Carlos Silva";
            amigoRegistrado.telefone = "(49) 999400611";
            amigoRegistrado.endereco = "Rua Jose Lehman, 12 Getal, Lages-SC";

            this.repositorioAmigo.AdicionarNaLista(amigoRegistrado);
            
            Amigo amigoRegistrado2 = new Amigo();

            amigoRegistrado2.nome = "Mimi";
            amigoRegistrado2.nomeResponsavel = "Mariana Silva";
            amigoRegistrado2.telefone = "(49) 98824432";
            amigoRegistrado2.endereco = "Rua das Hortaliças, 12";

            this.repositorioAmigo.AdicionarNaLista(amigoRegistrado2);
        }
    }
}
