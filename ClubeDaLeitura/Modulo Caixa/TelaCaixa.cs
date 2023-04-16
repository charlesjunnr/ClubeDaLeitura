using ClubeDaLeitura.Modulo_Caixa;
using System.Collections;

namespace ClubeDaLeitura
{
    public class TelaCaixa
    {
        private RepositorioCaixa repositorioCaixa;
        public TelaCaixa(RepositorioCaixa repositorioCaixa)
        {
            this.repositorioCaixa = repositorioCaixa;
        }
        
        public void RegistrarCaixa()
        {
            Caixa caixaNova = new Caixa();
            
            Console.WriteLine("\n Digite a cor da caixa: ");
            caixaNova.cor = Console.ReadLine();

            Console.WriteLine("\n Digite a etiqueta de identificação da caixa: ");
            caixaNova.etiqueta = Console.ReadLine();
            
            this.repositorioCaixa.AdicionarNaLista(caixaNova);
        }

        public bool VisualizarCaixa(bool mostrarCabecalho)
        {
            if (this.repositorioCaixa.listaRegistros.Count == 0)
            {
                Program.MostrarMensagem("Nenhuma caixa registrada!", ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }
            if (mostrarCabecalho)
                Program.MostrarCabecalho("Caixas:");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ----------------------------------- ");
            Console.WriteLine(" | {0, -5} | {1, -10} | {2,-10} |", "ID" , "Etiqueta", "Cor");
            Console.WriteLine(" ----------------------------------- ");
            Console.ResetColor();

            foreach (Caixa caixa in this.repositorioCaixa.listaRegistros)
            {
                Console.WriteLine(" | {0, -5} | {1, -10} | {2,-10} |", caixa.id, caixa.etiqueta, caixa.cor);
                Console.ResetColor();
                Console.WriteLine(" ----------------------------------- ");
            }
            Console.ReadLine();
            return true;
        }

        public void EditarCaixa()
        {   
            bool temCaixaRegistrada = VisualizarCaixa(false);

            if (temCaixaRegistrada == false)
            {
                return;
            }
            
            
            Program.MostrarCabecalho("Escolha o número da caixa que deseja editar:");

            int posicao = Convert.ToInt32(Console.ReadLine());
            
            Caixa caixa = repositorioCaixa.BuscarPorId(posicao);
            if(caixa == null)
            {
                return;
            }

            Console.WriteLine("\n Digite a cor da caixa: ");
            caixa.cor = Console.ReadLine();

            Console.WriteLine("\n Digite a etiqueta de identificação da caixa: ");
            caixa.etiqueta = Console.ReadLine();

            Program.MostrarMensagem("Caixa editada com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public void ExcluirCaixa()
        {
            bool temCaixaRegistrada = VisualizarCaixa(false);

            if (temCaixaRegistrada == false)
            {
                return;
            }

            Program.MostrarCabecalho("Digite o ID da caixa que deseja excluir");
           
            int posicao = Convert.ToInt32(Console.ReadLine());
            
            Caixa caixa = repositorioCaixa.BuscarPorId(posicao);
            if (caixa == null)
            {
                return;
            }

            this.repositorioCaixa.ExcluirCaixa(caixa);

            Program.MostrarMensagem("Caixa excluída com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public void CadastrarCaixaAutomaticamente()
        {
            Caixa caixaRegistrada = new Caixa();
            caixaRegistrada.cor = "Vermelho";
            caixaRegistrada.etiqueta = "Mônica";

            this.repositorioCaixa.AdicionarNaLista(caixaRegistrada);

            Caixa caixaRegistrada2 = new Caixa();
            caixaRegistrada2.cor = "Amarelo";
            caixaRegistrada2.etiqueta = "Magali";

            this.repositorioCaixa.AdicionarNaLista(caixaRegistrada2);

        }
    }
}
