using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloCliente;

namespace ControleBar.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TelaMenuPrincipal telaMenuPrincipal = new TelaMenuPrincipal(new Notificador());

            while (true)
            {
                TelaBase telaSelecionada = telaMenuPrincipal.ObterTela();

                if (telaSelecionada is null)
                    break;

                string opcaoSelecionada = telaSelecionada.MostrarOpcoes();

                if (telaSelecionada is ITelaCadastravel)
                {
                    ITelaCadastravel telaCadastroBasico = (ITelaCadastravel)telaSelecionada;

                    if (opcaoSelecionada == "1")
                        telaCadastroBasico.Inserir();

                    if (opcaoSelecionada == "2")
                        telaCadastroBasico.Editar();

                    if (opcaoSelecionada == "3")
                        telaCadastroBasico.Excluir();

                    if (opcaoSelecionada == "4")
                        telaCadastroBasico.VisualizarRegistros("Tela");
                }
                else
                {
                    TelaCadastroConta telaCadastroConta = telaSelecionada as TelaCadastroConta;

                    if (telaCadastroConta is null)
                        return;

                    if (opcaoSelecionada == "1")
                        telaCadastroConta.Inserir();

                    if (opcaoSelecionada == "2")
                        telaCadastroConta.AdicionarPedido();

                    if (opcaoSelecionada == "3")
                        telaCadastroConta.FecharConta();

                    if (opcaoSelecionada == "4")
                        telaCadastroConta.VisualizarRegistros("Tela");
                }
            }
        }
    }
}
