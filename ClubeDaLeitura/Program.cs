using ClubeDaLeitura.Empréstimos;
using ClubeDaLeitura.Modulo_Amigo;
using ClubeDaLeitura.Modulo_Caixa;
using ClubeDaLeitura.Modulo_Revista;

namespace ClubeDaLeitura
{
    public class Program
    {
        public static void Main(string[] args)
        {
 
            string opcaoMenuPrincipal="";
            string opcaoMenu="";

            RepositorioCaixa repositor = new RepositorioCaixa();
            TelaCaixa caixa = new TelaCaixa(repositor);

            RepositorioAmigo repositorAmigo = new RepositorioAmigo();
            TelaAmigo amigoNovo = new TelaAmigo(repositorAmigo);
            
            RepositorioRevista repositorRevista = new RepositorioRevista();
            TelaRevista revistaNova = new TelaRevista(repositorRevista, repositor);

            RepositorioEmprestimo repositorEmprestimo = new RepositorioEmprestimo();
            TelaEmprestimo emprestimoNovo = new TelaEmprestimo(repositorEmprestimo, repositorAmigo, repositorRevista);

            caixa.CadastrarCaixaAutomaticamente();
            amigoNovo.CadastrarAmigoAutomaticamente();
            revistaNova.CadastrarRevistaAutomaticamente();
            emprestimoNovo.CadastrarEmprestimoAutomaticamente();


            while(true)
            {
                string opcao = ApresentarMenuPrincipal(opcaoMenuPrincipal);
                if (opcao == "5")
                {
                    break;
                }
                {
                    if (opcao == "1")
                    {
                        string opcaoMenu2 = ApresentarMenuCaixas(opcaoMenu);
                        if (opcaoMenu2 == "5")
                        {
                            //voltar ao menu anterior
                            continue;
                        }
                        {
                            if (opcaoMenu2 == "1")
                            {
                                caixa.RegistrarCaixa();
                            }
                            else if (opcaoMenu2 == "2")
                            {
                                bool temCaixa = caixa.VisualizarCaixa(true);
                                if (temCaixa)
                                {
                                    Console.ReadLine();
                                }
                            }
                            else if (opcaoMenu2 == "3")
                            {
                                caixa.EditarCaixa();
                            }
                            else if (opcaoMenu2 == "4")
                            {
                                caixa.ExcluirCaixa();
                            }
                        }
                    }
                    else if (opcao == "2")
                    {
                        string opcaoMenu3 = ApresentarMenuAmigo(opcaoMenu);
                        if (opcaoMenu3 == "5")
                        {
                            continue;
                        }
                        else if (opcaoMenu3 == "1")
                        {
                            amigoNovo.RegistrarAmigo();
                        }
                        else if (opcaoMenu3 == "2")
                        {
                            bool temAmigo = amigoNovo.VisualizarAmigo(true);
                            if (temAmigo)
                            {

                            }
                        }
                        else if (opcaoMenu3 == "3")
                        {
                            amigoNovo.EditarAmigo();
                        }
                        else if (opcaoMenu3 == "4")
                        {
                            amigoNovo.ExcluirAmigo();
                        }
                    }
                    else if (opcao == "3")
                    {
                        string opcaoMenu4 = ApresentarMenuRevistas(opcaoMenu);
                        if (opcaoMenu4 == "5")
                        {
                            continue;
                        }
                        else if (opcaoMenu4 == "1")
                        {
                            revistaNova.RegistrarRevista();
                        }
                        else if (opcaoMenu4 == "2")
                        {
                            bool temRevista = revistaNova.VisualizarRevista(true);
                            if (temRevista)
                            {

                            }
                        }
                        else if (opcaoMenu4 == "3")
                        {
                            revistaNova.EditarRevista();
                        }
                        else if (opcaoMenu4 == "4")
                        {
                            revistaNova.ExcluirRevista();
                        }
                    }
                    else if (opcao == "4")
                    {
                        string opcaoMenu5 = ApresentarMenuEmprestimos(opcaoMenu);
                        if (opcaoMenu5 == "5")
                        {
                            continue;
                        }else if(opcaoMenu5 == "1")
                        {
                            emprestimoNovo.RegistrarEmprestimo();
                        }else if(opcaoMenu5 == "2")
                        {
                            bool temEmprestimo = emprestimoNovo.VisualizarEmprestimo(true);
                            if (temEmprestimo)
                            {

                            }
                        }else if(opcaoMenu5 == "3")
                        {
                            emprestimoNovo.VisualizarEmprestimoEmAberto(true);
                        }else if( opcaoMenu5 == "4")
                        {
                            emprestimoNovo.VisualizarEmprestimoFechados(true);
                        }
                    }
                }
            } 
        }
        static string ApresentarMenuPrincipal(string opcao)
        {
            Console.Clear();
            Console.WriteLine("******** CLUBE DOS CINCO - CLUBE DE LEITURA ********");
            Console.WriteLine("****************************************************");
            Console.WriteLine("* Escolha de acordo com as opções: ");
            Console.WriteLine("* [1] - Caixas  ");
            Console.WriteLine("* [2] - Amigos ");
            Console.WriteLine("* [3] - Revistas ");
            Console.WriteLine("* [4] - Empréstimos ");
            Console.WriteLine("* [5] - Sair ");
            Console.WriteLine("****************************************************");

            return opcao = Console.ReadLine();
        }
        static string ApresentarMenuAmigo(string opcao)
        {
            Console.Clear();
            Console.WriteLine("***************   Menu de Amigo   ******************");
            Console.WriteLine("****************************************************");
            Console.WriteLine("* [1] - Registrar nova amigo  ");
            Console.WriteLine("* [2] - Visualizar amigo ");
            Console.WriteLine("* [3] - Editar amigo ");
            Console.WriteLine("* [4] - Excluir amigo ");
            Console.WriteLine("* [5] - Voltar ao menu anterior ");
            Console.WriteLine("****************************************************");
            return opcao = Console.ReadLine();
        }
        static string ApresentarMenuCaixas(string opcao)
        {   
            Console.Clear();
            Console.WriteLine("***************   Menu de Caixas   *****************");
            Console.WriteLine("****************************************************");
            Console.WriteLine("* [1] - Registrar nova caixa  ");
            Console.WriteLine("* [2] - Visualizar caixas ");
            Console.WriteLine("* [3] - Editar caixas ");
            Console.WriteLine("* [4] - Excluir caixas ");
            Console.WriteLine("* [5] - Voltar ao menu anterior ");
            Console.WriteLine("****************************************************");
            return opcao = Console.ReadLine();
        }
        static string ApresentarMenuRevistas(string opcao)
        {
            Console.Clear();
            Console.WriteLine("**************   Menu de Revistas   ****************");
            Console.WriteLine("****************************************************");
            Console.WriteLine("* [1] - Registrar nova revista  ");
            Console.WriteLine("* [2] - Visualizar revistas ");
            Console.WriteLine("* [3] - Editar revistas ");
            Console.WriteLine("* [4] - Excluir revistas ");
            Console.WriteLine("* [5] - Voltar ao menu anterior ");
            Console.WriteLine("****************************************************");
            return opcao = Console.ReadLine();
        }
        static string ApresentarMenuEmprestimos(string opcao)
        {
            Console.Clear();
            Console.WriteLine("*************   Menu de Empréstimos   **************");
            Console.WriteLine("****************************************************");
            Console.WriteLine("* [1] - Registrar novo empréstimo  ");
            Console.WriteLine("* [2] - Visualizar empréstimos ");
            Console.WriteLine("* [3] - Empréstimos em aberto ");
            Console.WriteLine("* [4] - Empréstimos fechados ");
            Console.WriteLine("* [5] - Voltar ao menu anterior ");
            Console.WriteLine("****************************************************");
            return opcao = Console.ReadLine();
        }
        public static void MostrarCabecalho(string titulo)
        {
            
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(titulo);
            Console.ResetColor();

        }
        public static void MostrarMensagem(string mensagem, ConsoleColor cor)
        {
            
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem); 
            Console.ResetColor();
        }
    }
}